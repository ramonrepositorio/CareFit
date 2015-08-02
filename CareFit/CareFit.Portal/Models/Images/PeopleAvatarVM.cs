using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Images
{
    public class PeopleAvatarVM
    {
        public Domain.Repository.Pessoas People { get; set; }
        public Domain.Repository.Imagens Avatar { get; set; }
        public Domain.Repository.Imagens Image {get;set;}
    }
}