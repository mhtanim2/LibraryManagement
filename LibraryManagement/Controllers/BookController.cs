using LibraryManagement.Interface;
using LibraryManagement.Models;
using LibraryManagement.Util;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Book> books= await GetAllBook(SD.Author);
            if (books == null)
            {
                TempData["warning"] = "No Books is available";
                return RedirectToAction("Index", "Home");
            }
            return View(books);
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var authorList = await GetAuthorListAsync();

            BookVM bookVM = new()
            {
                AuthorList = authorList
            };
            ViewBag.Action = "create";
            return View(bookVM);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(BookVM obj)
        {
            if (obj?.Book?.TotalCopies< obj?.Book?.AvailableCopies)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);

                // Log or handle the validation errors
                foreach (var error in errors)
                {
                    // Log the error or handle it as needed
                    Console.WriteLine($"Validation Error: {error}");
                }

                TempData["error"] = "The input is not valid";
                ViewBag.Action = "create";
                return View(obj);
            }
            await _unitOfWork.BookRepo.Add(obj.Book);
            await _unitOfWork.SaveAsync();
            obj.AuthorList = await GetAuthorListAsync();
            TempData["success"] = "Book Created Successfully";
            ViewBag.Action = "create";
            return View(obj);
        }
        [Authorize]
        public async Task<IActionResult> Update(int BookId)
        {
            var authorList = await GetAuthorListAsync();

            BookVM bookVM = new()
            {
                AuthorList = authorList,
                Book= await GetBook(BookId,SD.Author)
            };
            if (bookVM == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.Action = "update";
            return View(bookVM);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(BookVM obj)
        {
            if (!ModelState.IsValid || obj?.Book?.TotalCopies < obj?.Book?.AvailableCopies)
            {
                TempData["error"] = "The input is not valid";
                ViewBag.Action = "update";
                return View(obj);
            }
            _unitOfWork.BookRepo.Update(obj.Book);
            await _unitOfWork.SaveAsync();
            obj.AuthorList = await GetAuthorListAsync();
            TempData["success"] = "Book Update Successfully";
            
            return RedirectToAction("Index","Book");
        }
        [Authorize]
        public async Task<IActionResult> Delete(int BookId)
        {
            var authorList = await GetAuthorListAsync();

            BookVM bookVM = new()
            {
                AuthorList = authorList,
                Book = await GetBook(BookId, SD.Author)
            };

            if (bookVM == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.Action = "delete";
            return View(bookVM);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(BookVM obj)
        {
            Book? book = await GetBook(obj.Book.BookId,SD.Author);
            var association= await _unitOfWork.BorrowedBookRepo.Get(u=>u.BookId==book.BookId);
            if (association is not null)
            {
                TempData["warning"] = "Can't Delete, This Book is associated with others";
                return RedirectToAction(nameof(Index));
            }
            if (book is not null)
            {
                _unitOfWork.BookRepo.Delete(book);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Book Deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["warning"] = "can't delete the book no";
            ViewBag.Action="delete"; 
            return View(obj);
        }

        private async Task<List<SelectListItem>> GetAuthorListAsync()
        {
            var authors = await _unitOfWork.AuthorRepo.GetAll();
            return await SD.GetItemListAsync(authors, a => a.AuthorName, a => a.AuthorId.ToString());
        }
        private async Task<IEnumerable<Book>> GetAllBook(string author)
        {
            return await _unitOfWork.BookRepo.GetAll(includeProperties:author);
        }
        
        private async Task<Book> GetBook(int BookId, string author)
        {
            return await _unitOfWork.BookRepo.Get(i => i.BookId==BookId,includeProperties: author);
        }

        
    }
}
