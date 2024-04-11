using Microsoft.AspNetCore.Mvc;
using TrainingFPTCo.Models.Queries;
using TrainingFPTCo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingFPTCo.Helpers;
using Microsoft.Data.SqlClient;

namespace TrainingFPTCo.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            AccountViewModel account = new AccountViewModel();
            account.AccountDetailList = new List<AccountDetail>();
            var dataAccount = new AccountQuery().GetAllDataAccount();
            foreach (var data in dataAccount)
            {
                account.AccountDetailList.Add(new AccountDetail
                {
                    Id = data.Id,
                    RoleId=data.RoleId,
                    UserName = data.UserName,
                    Password =data.Password,
                    ExtraCode = data.ExtraCode,
                    Email = data.Email,
                    Phone = data.Phone,
                    Address = data.Address,
                    FullName = data.FullName,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    BirthDay = data.BirthDay,
                    Gender = data.Gender,
                });
            }
                return View(account);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AccountDetail account = new AccountDetail();

            List<SelectListItem> itemRole = new List<SelectListItem>();
            var dataRole = new RoleQuery().GetAllDataRole();
            foreach (var item in dataRole)
            {
                itemRole.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }
            ViewBag.Roles = itemRole;
            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AccountDetail account)
        {
            if (ModelState.IsValid)
            {
                // xu ly insert course vao database
                try
                {
                    int idAccount = new AccountQuery().InsertAccount(
                        account.RoleId,
                        account.UserName,
                        account.Password,
                        account.ExtraCode,
                        account.Email,
                        account.Phone,
                        account.Address,
                        account.FullName,
                        account.FirstName,
                        account.LastName,
                        account.BirthDay,
                        account.Gender
                    );
                    if (idAccount > 0)
                    {
                        TempData["saveStatus"] = true;
                    }
                    else
                    {
                        TempData["saveStatus"] = false;
                    }
                   
                    return RedirectToAction(nameof(AccountController.Index), "Account");
                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
            }

            List<SelectListItem> itemRole = new List<SelectListItem>();
            var dataRole = new RoleQuery().GetAllDataRole();
            foreach (var item in dataRole)
            {
                itemRole.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }
            ViewBag.Roles = itemRole;
            return View(account);
        }
        public JsonResult Delete(int id = 0)
        {
            bool deleteCourse = new AccountQuery().DeleteCourseById(id);
            if (deleteCourse)
            {
                return Json(new { cod = 200, message = "Successfully" });
            }
            return Json(new { cod = 500, message = "Failure" });
        }

        [HttpGet]
        public IActionResult Update(int id = 0)
        {
            AccountDetail detail = new AccountQuery().GetDetailAccountById(id);
            List<SelectListItem> itemRoles = new List<SelectListItem>();
            var dataCategory = new RoleQuery().GetAllDataRole();
            foreach (var item in dataCategory)
            {
                itemRoles.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }
            ViewBag.Roles = itemRoles;
            return View(detail);
        }

        [HttpPost]
        public IActionResult Update(AccountDetail accountDetail)
        {
            try
            {
                var infoAccount = new AccountQuery().GetDetailAccountById(accountDetail.Id);
              
                // check xem nguoi co thay anh hay ko?
               
                bool update = new AccountQuery().UpdateAccountById(
                        accountDetail.Id,
                        accountDetail.RoleId,
                        accountDetail.UserName,
                        accountDetail.Password,
                        accountDetail.ExtraCode,
                        accountDetail.Email,
                        accountDetail.Phone,
                        accountDetail.Address,
                        accountDetail.FullName,
                        accountDetail.FirstName,
                        accountDetail.LastName,
                        accountDetail.BirthDay,
                        accountDetail.Gender
                        );
                if (update)
                {
                    TempData["saveUpdate"] = true;
                }
                else
                {
                    TempData["saveUpdate"] = false;
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            List<SelectListItem> itemRoles = new List<SelectListItem>();
            var dataCategory = new RoleQuery().GetAllDataRole();
            foreach (var item in dataCategory)
            {
                itemRoles.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }
            ViewBag.Roles = itemRoles;
            return View(accountDetail);
        }

    }
}
