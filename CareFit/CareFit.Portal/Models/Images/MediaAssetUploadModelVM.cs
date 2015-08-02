using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Images
{
    public class MediaAssetUploadModelVM
    {
        public HttpPostedFileBase fileData { get; set; }
        public string SecurityToken { get; set; }
        public string Filename { get; set; }
    }
}