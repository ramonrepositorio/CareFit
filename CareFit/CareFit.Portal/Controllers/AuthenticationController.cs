using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace CareFit.Portal.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        [HttpGet]
        public ActionResult Index(string customerKey = "", string ReturnUrl = "", string error = "")
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            var model = new Models.Authentication.IndexVM();
            model.CustomerName = "CareFit";
            model.Error = error;
            if (!string.IsNullOrEmpty(customerKey))
            {
                var customerBll = new Domain.BLL.CustomerBLL();
                var customer = customerBll.GetCustomerByKey(customerKey);
                customer.Imagens = customerBll.GetImageByKey(customerKey);
                model.Image = customer.Imagens;
                new Models.GlobalCode.CookieExtension().SetLocalCustomer(customer);
                model.CustomerName = customer.Nome;
            }
            if (model.Image == null)
            {
                model.Image = new Domain.Repository.Imagens { Url = "/Content/Laceng/assets/img/logo.png" };
                var customer = new Models.GlobalCode.CookieExtension().GetLocalCustomer();
                if (customer != null)
                {
                    if (customer.Imagens != null)
                    {
                        model.Image = customer.Imagens;
                    }
                }
                if (customer != null)
                {
                    if (!string.IsNullOrEmpty(customer.Nome))
                    {
                        model.CustomerName = customer.Nome;
                    }

                }

            }


            model.ReturnUrl = ReturnUrl;
            return View(model);
        }

        [HttpPost]
        public bool ResetPassword(string mail)
        {
            return new Domain.BLL.AuthenticationBLL().ResetPassword(mail);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(string newPassword)
        {
            var loggedUser = Session.GetLoggedUser();


            loggedUser.Senha = new Utils.Cryptography.EncryptMd5().GetHash(newPassword);
            loggedUser = new Domain.BLL.PeopleBLL().Save(loggedUser);
            Session.SetLoggedUser(loggedUser);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ResetPassword(string mail, string token)
        {
            var model = new Models.Authentication.ResetPasswordVM();
            if (!string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(token))
            {
                model.People = new Domain.BLL.PeopleBLL().Get(mail, token);
                Session.SetLoggedUser(model.People);
                FormsAuthentication.SetAuthCookie(mail, false);
            }
            else
            {
                model.People = Session.GetLoggedUser();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Autorize(string mail, string pass, string returnUrl)
        {
            var model = new Models.Authentication.IndexVM();

            model.UserMail = mail;
            var authBll = new Domain.BLL.AuthenticationBLL();
            var user = authBll.Authorize(mail);
            if (user != null)
            {
                if (user.Senha == new Utils.Cryptography.EncryptMd5().GetHash(pass))
                {
                    var peopleBll = new Domain.BLL.PeopleBLL();
                    user.PessoaEmpresas = peopleBll.GetPeopleCustomers(user.ID);
                    var customerBll = new Domain.BLL.CustomerBLL();
                    foreach (var peopleCustomer in user.PessoaEmpresas)
                    {
                        peopleCustomer.Empresas = customerBll.GetCustomer(peopleCustomer.EmpresaId);
                    }
                    Session.SetLoggedUser(user);
                    //Let us now set the authentication cookie so that we can use that later.
                    FormsAuthentication.SetAuthCookie(mail, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    model.Error = "Senha Inválida";
                }
            }
            else
            {
                model.Error = "Email não encontrado";
            }
            return RedirectToAction("Index", new { error = model.Error });
        }

        [HttpPost]
        public bool VerifySection()
        {
            var loggedUser = Session.GetLoggedUser();
            if (loggedUser == null)
            {
                return false;
            }
            return true;
        }
    }
}
