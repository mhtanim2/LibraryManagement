using LibraryManagement.Interface;
using LibraryManagement.Models;
using LibraryManagement.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Author> authorList= await _unitOfWork.AuthorRepo.GetAll();
            if (authorList == null)
                return RedirectToAction("Index", "Home");
            return View(authorList);
        }
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Action = "create";
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Author obj)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Input field is not correct";
                ViewBag.Action = "create";
                return View(obj);
            }
            await _unitOfWork.AuthorRepo.Add(obj);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Author Added Successfully";
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> Update(int AuthorId)
        {
            Author author = await _unitOfWork.AuthorRepo.Get(i=>i.AuthorId==AuthorId);
            ViewBag.Action = "update";
            if (author == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(author);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(Author obj)
        {
            if (ModelState.IsValid && obj.AuthorId > 0)
            {
                _unitOfWork.AuthorRepo.Update(obj);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Author Updated Successfully";
                ViewBag.Action = "update";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [Authorize]
        public async Task<IActionResult> Delete(int AuthorId)
        {
            Author author = await _unitOfWork.AuthorRepo.Get(x=>x.AuthorId==AuthorId);
            if (author is null)
                return RedirectToAction("Error", "Home");
            ViewBag.Action = "delete";

            return View(author);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(Author obj)
        {
            if (obj == null)
                return RedirectToAction("Error", "Home");
            var assocication = await _unitOfWork.BookRepo.Get(u=>u.AuthorId==obj.AuthorId);
            
            if (assocication is not null) { 
                TempData["warning"] = "Failed,This Author already associate with Books";
                return RedirectToAction("Index","Book");
            }
            _unitOfWork.AuthorRepo.Delete(obj);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Author Deleted successfully";
            return RedirectToAction("Index");
            
        }
    }
}
