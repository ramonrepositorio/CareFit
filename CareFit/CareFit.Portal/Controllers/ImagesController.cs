using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareFit.Portal.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    namespace EasyTech.Erp.Web.Controllers
    {
        public class ImagesController : Controller
        {
            //
            // GET: /Image/

            public ActionResult Index()
            {
                return View();
            }
            public ActionResult Edit(int imageId)
            {
                var model = new Models.Images.PeopleAvatarVM();
                var imageBll = new Domain.BLL.ImagesBLL();
                model.Image = imageBll.Get(imageId);
                if (model.Image == null)
                {
                    model.Image = new Domain.Repository.Imagens
                    {
                        Url = "/Uploads/Images/no-image.png"
                    };
                }
                return View(model);
            }

            public string Upload(HttpPostedFileBase file)
            {
                // Verify that the user selected a file
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/Uploads/Temp"), fileName);
                    var WorkingImageId = Guid.NewGuid();
                    Image image = ProcessUploadedImage(file);

                    var WorkingImageExtension = Path.GetExtension(file.FileName).ToLower();
                    var imagePath = Server.MapPath("/Uploads/Temp") + @"\" + WorkingImageId + WorkingImageExtension;
                    image.Save(imagePath);

                    return WorkingImageId + WorkingImageExtension;
                }
                // redirect back to the index action to show the form once again
                return "";
            }


            [HttpPost]
            public string CropImage(int x, int y, int w, int h, string imagePath)
            {


                var pathImage = Server.MapPath(imagePath);
                Image img = Image.FromFile(pathImage);
                Bitmap newBitmap = null;
                using (System.Drawing.Bitmap _bitmap = new System.Drawing.Bitmap(w, h))
                {
                    _bitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                    using (Graphics _graphic = Graphics.FromImage(_bitmap))
                    {
                        _graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        _graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        _graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                        _graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;


                        _graphic.DrawImage(img, 0, 0, w, h);
                        _graphic.DrawImage(img, new Rectangle(0, 0, w, h), x, y, w, h, GraphicsUnit.Pixel);
                    }
                    var objImg = _bitmap.Clone();
                    newBitmap = (Bitmap)objImg;

                }
                var fileName = Path.GetFileNameWithoutExtension(imagePath) + "_Cropped" + Path.GetExtension(imagePath);
                newBitmap.Save(Server.MapPath("/Uploads/Temp/") + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                return fileName;
            }


            private Image ProcessUploadedImage(HttpPostedFileBase file)
            {
                var WorkingImageExtension = Path.GetExtension(file.FileName).ToLower();
                string[] allowedExtensions = { ".png", ".jpeg", ".jpg", ".gif" }; // Make sure it is an image that can be processed
                if (allowedExtensions.Contains(WorkingImageExtension))
                {

                    Image workingImage = new Bitmap(file.InputStream);

                    workingImage = ResizeImage(workingImage);


                    return workingImage;
                }
                else
                {
                    throw new Exception("Cannot process files of this type.");
                }
            }

            public long SaveImage(string fileName)
            {
                var imageBLL = new Domain.BLL.ImagesBLL();
                var image = new Domain.Repository.Imagens();
                image.Url = fileName;
                image.Cadastro = DateTime.Now;                                
                image = imageBLL.Save(image);
                return image.ID;
            }


            private Image ResizeImage(Image imgPhoto)
            {
                int logoSize = 800;

                float sourceWidth = imgPhoto.Width;
                float sourceHeight = imgPhoto.Height;
                float destHeight = 0;
                float destWidth = 0;
                int sourceX = 0;
                int sourceY = 0;
                int destX = 0;
                int destY = 0;

                // Resize Image to have the height = logoSize/2 or width = logoSize.
                // Height is greater than width, set Height = logoSize and resize width accordingly
                if (sourceWidth > (2 * sourceHeight))
                {
                    destWidth = logoSize;
                    destHeight = (float)(sourceHeight * logoSize / sourceWidth);
                }
                else
                {
                    int h = logoSize / 2;
                    destHeight = h;
                    destWidth = (float)(sourceWidth * h / sourceHeight);
                }
                // Width is greater than height, set Width = logoSize and resize height accordingly

                Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight,
                                            PixelFormat.Format32bppPArgb);
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

                grPhoto.DrawImage(imgPhoto,
                    new Rectangle(destX, destY, (int)destWidth, (int)destHeight),
                    new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight),
                    GraphicsUnit.Pixel);

                grPhoto.Dispose();

                return bmPhoto;

            }


        }
    }
}
