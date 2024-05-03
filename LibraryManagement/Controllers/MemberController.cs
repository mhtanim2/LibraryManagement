using LibraryManagement.Interface;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class MemberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Member> MemberList = await GetAllMember();
            if (MemberList == null)
                return RedirectToAction("Index", "Home");
            return View(MemberList);
        }
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Action = "create";
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Member obj)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Input field is not correct";
                ViewBag.Action = "create";
                return View(obj);
            }

            IEnumerable<Member> MemberList = await GetAllMember();

            if (!CheckUniqueness(MemberList, obj))
            {
                ViewBag.Action = "create";
                return View(obj);
            }
            
            await _unitOfWork.MemberRepo.Add(obj);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Villa Added Successfully";
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> Update(int MemberId)
        {
            Member Member = await GetMember(MemberId);
            ViewBag.Action = "update";
            if (Member == null)
            {
                TempData["warning"] = "No member founded";
                return RedirectToAction("Index", "Member");
            }
            return View(Member);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(Member obj)
        {
            if (ModelState.IsValid && obj.MemberId > 0)
            {
                _unitOfWork.MemberRepo.Update(obj);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Member Updated Successfully";
                ViewBag.Action = "update";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [Authorize]
        public async Task<IActionResult> Delete(int MemberId)
        {
            Member Member = await _unitOfWork.MemberRepo.Get(x => x.MemberId == MemberId);
            if (Member is null)
                return RedirectToAction("Error", "Home");
            ViewBag.Action = "delete";

            return View(Member);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(Member obj)
        {
            if (obj == null)
                return RedirectToAction("Error", "Home");
            var association = await _unitOfWork.BorrowedBookRepo.Get(u => u.MemberId == obj.MemberId);
            if (association is not null)
            {
                TempData["warning"] = "Can't Delete, This Member is associated with others";
                return RedirectToAction(nameof(Index));
            }
            _unitOfWork.MemberRepo.Delete(obj);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Member Deleted successfully";
            return RedirectToAction("Index");

        }


        private async Task<IEnumerable<Member>> GetAllMember()
        {
            return await _unitOfWork.MemberRepo.GetAll();
        }
        private bool CheckUniqueness(IEnumerable<Member> MemberList,Member obj) 
        {
            foreach (var member in MemberList)
            {
                if (member.PhoneNumber == obj.PhoneNumber)
                {
                    TempData["warning"] = "This phone number is already Inserted";
                    return false;
                }
                if (member.Email == obj.Email)
                {
                    TempData["warning"] = "This email is already Inserted";
                    return false;
                }
            }
            return true;

        }
        private async Task<Member> GetMember(int MemberId)
        {
            return await _unitOfWork.MemberRepo.Get(i => i.MemberId == MemberId);
        }
    }
}
