using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public class ImagesBLL:BaseBLL
    {
        public Repository.Imagens GetPeopleAvatar(long peopleId)
        {
            var avatar = (from p in _ctx.Pessoas
                    join i in _ctx.Imagens
                        on p.ImagemId equals i.ID
                    where p.ID == peopleId
                    select i).FirstOrDefault();
            if (avatar == null)
            {
                avatar = GetNoImage();
            }
            return avatar;
        }


        public Repository.Imagens Save(Repository.Imagens image)
        {
            if (image.ID == 0)
            {
                _ctx.Imagens.Add(image);
            }
            else
            {
                _ctx.Imagens.Attach(image);
                _ctx.Entry(image).State = System.Data.EntityState.Modified;
            }
            _ctx.SaveChanges();
            return image;
        }

        public Repository.Imagens Get(long imageId)
        {
            return _ctx.Imagens.Where(i => i.ID == imageId).FirstOrDefault();
        }

        public Repository.Imagens GetNoImage()
        {
            return new Repository.Imagens { Url = "/Uploads/Images/no-image.png" };
        }
    }
}
