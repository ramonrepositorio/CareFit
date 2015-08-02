using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CareFit.Api.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/

        public JsonResult Login(string mail, string pass)
        {
            var authBll = new Domain.BLL.AuthenticationBLL();
            var people = authBll.Authorize(mail);
            if (people == null)
            {
                return Json(new { success = false, error = "Email inválido" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (people.Senha == new Utils.Cryptography.EncryptMd5().GetHash(pass))
                {
                    var token = authBll.GetToken(people.ID, 15);
                    //FormsAuthentication.SetAuthCookie(mail, false);
                    //Session.SetLoggedUser(people);
                    return Json(new
                    {
                        success = true,
                        user = new
                        {
                            id = people.ID,
                            token = token.Token,
                            name = people.Nome,
                            lastName = people.Sobrenome
                        }

                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, error = "Senha inválida" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        public JsonResult ReLogin(string token, string mail)
        {
            var authBll = new Domain.BLL.AuthenticationBLL();
            var peopleToken = authBll.ReLogin(token, mail);
            if (peopleToken != null)
            {
                var people = new Domain.BLL.PeopleBLL().GetPeople(mail);
                FormsAuthentication.SetAuthCookie(people.Email, false);
                Session.SetLoggedUser(people);
                return Json(new
                {
                    success = true,
                    token = new
                    {
                        expiration = peopleToken.Vencimento.ToString("dd/MM/yyyy HH:mm:ss"),
                    }

                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                success = false,
                error = "Token não encontrado ou vencido"
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult VerifyAccess()
        {
            var loggedUser = Session.GetLoggedUser();
            var verified = false;
            if (loggedUser != null)
            {
                verified = true;
            }
            return Json(new
            {
                success = true,
                access = new
                {
                    verified = verified
                }

            }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult VerifyDotNetAccess()
        {
            var loggedUser = Session.GetLoggedUser();
            return Json(new
            {
                success = true,
                user = new
                {
                    id = loggedUser.ID,
                    name = loggedUser.Nome,
                    lastName = loggedUser.Sobrenome
                }
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
