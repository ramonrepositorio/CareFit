using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.GlobalCode
{
    public  class CookieExtension
    {
        public  Domain.Repository.Empresas GetLocalCustomer()
        {
            var customerDataCookie = HttpContext.Current.Request.Cookies["CustomerLocalData"];
            Domain.Repository.Empresas customer = null;
            if (customerDataCookie != null)
            {
                var jsonCookie = customerDataCookie.Value;
                if (jsonCookie != null)
                {
                    customer = JsonConvert.DeserializeObject<Domain.Repository.Empresas>(jsonCookie);
                }
            }
            
            return customer;
        }
        public  void SetLocalCustomer(Domain.Repository.Empresas customer)
        {
            var customerDataCookie = new System.Web.HttpCookie("CustomerLocalData");
            customer.Imagens.Empresas = null;
            customerDataCookie.Value = JsonConvert.SerializeObject(customer);
            //Time para expiração (1min)

            DateTime dtNow = DateTime.Now;

            TimeSpan tsMinute = new TimeSpan(30,0,0,0);

            customerDataCookie.Expires = dtNow + tsMinute;
                
            //Adiciona o cookie
            HttpContext.Current.Response.Cookies.Add(customerDataCookie);
        }
    }
}