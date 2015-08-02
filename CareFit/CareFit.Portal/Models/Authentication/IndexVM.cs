using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Authentication
{
    public class IndexVM
    {
        public string Error { get; set; }
        public string UserMail { get; set; }
        public string ReturnUrl { get; set; }
        public string CustomerName { get; set; }
        public Domain.Repository.Imagens Image { get; set; }
    }
}