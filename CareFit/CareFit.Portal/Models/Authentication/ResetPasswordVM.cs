using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Authentication
{
    public class ResetPasswordVM
    {
        public Domain.Repository.Pessoas People { get; set; }
        public string Error { get; set; }
    }
}