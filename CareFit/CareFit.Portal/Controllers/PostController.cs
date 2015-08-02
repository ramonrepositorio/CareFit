using CareFit.Domain.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareFit.Portal.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Timeline()
        {
            var imageBll = new Domain.BLL.ImagesBLL();
            var model = new Models.Post.TimelineVM();
            var postBll = new Domain.BLL.PostBLL();
            var loggedUser = Session.GetLoggedUser();
            model.Posts = postBll.GetTimelinePosts(loggedUser.ID);
            foreach (var post in model.Posts)
            {
                if (post.Pessoas.Imagens == null)
                {
                    post.Pessoas.Imagens = imageBll.GetNoImage();
                }
            }
            return View(model);
        }
        [HttpPost]
        public void AddNew(string postText)
        {
            var loggedUser = Session.GetLoggedUser();
            var postBll = new Domain.BLL.PostBLL();
            var newPost = new Domain.Repository.PessoaPosts();
            newPost.PessoaId = loggedUser.ID;
            newPost.PessoaPostTipoId = (int)PostTypes.PeoplePost;
            newPost.DataPost = DateTime.Now;
            newPost.Post = postText;
            postBll.Save(newPost);
        }

    }
}
