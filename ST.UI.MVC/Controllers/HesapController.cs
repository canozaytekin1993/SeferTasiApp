using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ST.Models.ViewModels;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ST.BLL.Account;
using ST.Models.IdentityModels;
using static ST.BLL.Account.MembershipTools;

namespace ST.UI.MVC.Controllers
{
    public class HesapController : Controller
    {
        // GET: Hesap
        [HttpGet]
        public ActionResult Kayıt()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Kayıt(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            var userManager = MembershipTools.NewUserManager();
            var checkUser = userManager.FindByEmail(model.Email);
            if (checkUser != null)
            {
                ModelState.AddModelError("","Bu email adresi kullanılmaktadır.");
                return View(model);
            }
            checkUser = await userManager.FindByNameAsync(model.Username);
            if (checkUser != null)
            {
                ModelState.AddModelError("","Bu kullanıcı adı kullanılmaktadır.");
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.Phone,
                Surname = model.Surname,
                UserName = model.Surname,
                
            };

            bool adminMi = userManager.Users.Count() == 0;
            var sonuc = await userManager.CreateAsync(user, model.ConfirmPassword);
            if (sonuc.Succeeded)
            {
                if (adminMi)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
                else
                {
                    if (model.FirmaMi)
                        userManager.AddToRole(user.Id, "Firma");
                    else
                        userManager.AddToRole(user.Id, "Musteri");
                }

                return  RedirectToAction("Index","Ana")
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı kayıt işleminde hata oluştu!");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Giris(LoginViewModel model)
        {

            return View();
        }
    }
}