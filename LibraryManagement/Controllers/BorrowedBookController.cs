using LibraryManagement.Interface;
using LibraryManagement.Models;
using LibraryManagement.Util;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.Controllers
{
    [Authorize]
    public class BorrowedBookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BorrowedBookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<BorrowedBook> borrow = await GetAll(SD.Status,SD.Member,SD.Book);
            if (borrow == null)
            {
                TempData["warning"] = "No Borrowed list is available";
                return RedirectToAction("Index", "Home");
            }
            return View(borrow);
        }

        public async Task<IActionResult> Create()
        {
            var memberList = await GetMemberListAsync();
            var statusList = await GetStatusListAsync();
            var bookList = await GetBookListAsync();
            if (memberList is null|| statusList is null||bookList is null)
            {
                TempData["warning"] = "Validation Error";
                return RedirectToAction("Error", "Home");
            }
            BorrowedBookVM borrowedVM = new()
            {
                StatusList= statusList,
                MemberList= memberList,
                BookList= bookList
            };
            ViewBag.Action = "create";
            return View(borrowedVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BorrowedBookVM obj)
        {
  
            _unitOfWork.BeginTransaction();

            try
            {
                await _unitOfWork.BorrowedBookRepo.Add(obj.BorrowedBook);
                await _unitOfWork.SaveAsync();

                Book book = await _unitOfWork.BookRepo.Get(b => b.BookId == obj.BorrowedBook.BookId);
                HandleAvailability(obj,book);
                _unitOfWork.BookRepo.Update(book);
                await _unitOfWork.SaveAsync();

                await _unitOfWork.CommitTransactionAsync();

                obj.MemberList = await GetMemberListAsync();
                obj.StatusList = await GetStatusListAsync();
                obj.BookList = await GetBookListAsync();
                TempData["success"] = "Book Created Successfully";
                ViewBag.Action = "create";
                return View(obj);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();

                TempData["error"] = "An error occurred while processing the request.";
                ViewBag.Action = "create";
                return View(obj);
            }
        }
        
        public async Task<IActionResult> Update(int BorrowedId)
        {
            
            BorrowedBookVM VM = await GetBorrowBookVM(BorrowedId);
            if (VM == null || VM.MemberList is null
                || VM.StatusList is null || VM.BookList is null)
            {
                TempData["warning"] = "Can't Delete";
                return RedirectToAction("Error", "Home");
            }
            ViewBag.Action = "update";
            return View(VM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BorrowedBookVM obj)
        {
            
            _unitOfWork.BeginTransaction();
            try {
                if (obj.BorrowedBook==null|| (obj?.BorrowedBook.Book?.TotalCopies < obj?.BorrowedBook.Book?.AvailableCopies))
                {
                    TempData["error"] = "Borrowed Book not founded";
                    ViewBag.Action = "update";
                    return View(obj);
                }
                _unitOfWork.BorrowedBookRepo.Update(obj.BorrowedBook);
                await _unitOfWork.SaveAsync();
                Book book = await _unitOfWork.BookRepo.Get(b => b.BookId == obj.BorrowedBook.BookId);
                HandleAvailability(obj, book);
                _unitOfWork.BookRepo.Update(book);
                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitTransactionAsync();

                TempData["success"] = "Book Update Successfully";

                return RedirectToAction("Index", "Book");
            }
            catch(Exception ex) {

                await _unitOfWork.RollbackTransactionAsync();

                TempData["error"] = "An error occurred while processing the request.";
                ViewBag.Action = "create";
                return View(obj);
            }
        }

        public async Task<IActionResult> Delete(int BorrowedId)
        {

            BorrowedBookVM VM = await GetBorrowBookVM(BorrowedId);
            
            if (VM == null|| VM.MemberList is null 
                || VM.StatusList is null || VM.BookList is null)
            {
                TempData["warning"] = "Can't Delete";
                return RedirectToAction("Error", "Home");
            }
            ViewBag.Action = "delete";
            return View(VM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BorrowedBookVM obj)
        {
            if (obj==null)
            {
                TempData["error"] = "Failed..!";
                return RedirectToAction(nameof(Index));
            }
            var book = await GetBorrowedBookAsync(obj.BorrowedBook.BorrowId);
            if (book is not null)
            {
                _unitOfWork.BorrowedBookRepo.Delete(book);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Book Deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["warning"] = "can't delete the book no";
            ViewBag.Action = "delete";
            return View(obj);
        }




        //Pirvate method
        private async Task<BorrowedBookVM> GetBorrowBookVM(int id) 
        {
            var memberList = await GetMemberListAsync();
            var statusList = await GetStatusListAsync();
            var bookList = await GetBookListAsync();
            
            return new()
            {
                MemberList = memberList,
                StatusList = statusList,
                BookList = bookList,
                BorrowedBook = await GetBorrowedBookAsync(id)
            };
        }

        private async Task<IEnumerable<BorrowedBook>> GetAll(string status,string member,string book)
        {
            return await _unitOfWork.BorrowedBookRepo.GetAll(includeProperties: $"{status},{member},{book}");
        }
        private async Task<List<SelectListItem>> GetMemberListAsync()
        {
            var members = await _unitOfWork.MemberRepo.GetAll();
            return await SD.GetItemListAsync(members, a => $"{a.FirstName} {a.LastName}", a => a.MemberId.ToString());
        }
        private async Task<List<SelectListItem>> GetStatusListAsync()
        {
            var status = await _unitOfWork.StatusRepo.GetAll();
            return await SD.GetItemListAsync(status, a => a.Type, a => a.Id.ToString());
        }
        private async Task<List<SelectListItem>> GetBookListAsync()
        {
            var books = await _unitOfWork.BookRepo.GetAll();
            return await SD.GetItemListAsync(books, a => a.Title, a => a.BookId.ToString());
        }
        private void HandleAvailability(BorrowedBookVM obj,Book book) {

            if (obj.BorrowedBook.StatusId == 1 && book.AvailableCopies > 0)
                book.AvailableCopies -= 1;
            else if (book.AvailableCopies >= 0 && book.AvailableCopies < book.TotalCopies)
                book.AvailableCopies += 1;
            else
                throw new Exception("This Book in not Available to borrow");
        }
        private async Task<BorrowedBook> GetBorrowedBookAsync(int BorrowedId)
        {
            return await _unitOfWork.BorrowedBookRepo.Get(i => i.BorrowId == BorrowedId);
        }
    }
}
