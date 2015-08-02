using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareFit.Portal.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        //
        // GET: /Chat/

        public ActionResult Index()
        {
            var model = new Models.Chat.indexVM();
            var loggedUser = Session.GetLoggedUser();
            var peopleBll = new Domain.BLL.PeopleBLL();
            var chatBll = new Domain.BLL.ChatBLL();
            model.Friends = peopleBll.GetPeopleFriends(loggedUser.ID);

            model.FriendsChat = chatBll.GetFriendsWithMessage(loggedUser.ID);
            return View(model);
        }
        public ActionResult Chat(long peopleFromId)
        {
            var model = new Models.Chat.ChatVM();
            var loggedUser = Session.GetLoggedUser();
            var chatBll = new Domain.BLL.ChatBLL();
            var imageBll = new Domain.BLL.ImagesBLL();
            model.Messages = chatBll.GetMessages(peopleFromId, loggedUser.ID);
            model.PeopleId = loggedUser.ID;
            model.PeopleFromId = peopleFromId;
            model.ImagePeopleFrom = imageBll.GetPeopleAvatar(peopleFromId);
            model.ImagePeople = imageBll.GetPeopleAvatar(loggedUser.ID);
            return View(model);
        }
        [HttpPost]
        public void Post(long friendId, string message)
        {
            var loggedUser = Session.GetLoggedUser();
            var chatBll = new Domain.BLL.ChatBLL();
            var peopleMessage = new Domain.Repository.PessoaMensagens();
            peopleMessage.PessoaDestinatarioId = friendId;
            peopleMessage.PessoaRemetenteId = loggedUser.ID;
            peopleMessage.Mensagem = message;
            peopleMessage.DataEnvio = DateTime.Now;
            chatBll.PeopleMessageSave(peopleMessage);
        }
        [HttpPost]
        public JsonResult GetNewChats(string lastUpdate)
        {
            DateTime? dateLastUpdate = null;
            if (!string.IsNullOrEmpty(lastUpdate))
            {
                var format = "dd/MM/yyyy"; // your datetime format
                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
                dateLastUpdate = JsonConvert.DeserializeObject<DateTime>(lastUpdate, dateTimeConverter).AddHours(-3);
            }


            var loggedUser = Session.GetLoggedUser();
            var chatBll = new Domain.BLL.ChatBLL();
            var newMessages = chatBll.GetNewMessages(loggedUser.ID, dateLastUpdate).Select(pm => new
            {
                friendId = pm.PessoaRemetenteId,
                message = pm.Mensagem,
                imageUrl = pm.Pessoas1.Imagens.Url,
                fullName = pm.Pessoas1.Nome + " " + pm.Pessoas1.Sobrenome,
                sendDate = pm.DataEnvio.ToString("dd/mm/yyyy HH:mm:ss")
            }).ToList();
            return Json(new
            {
                lastUpdate = DateTime.Now,
                newMessages = newMessages,
                countNewMessages = chatBll.GetNewMessagesCount(loggedUser.ID)
            }, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public void ReadyMessages(long friendId)
        {
            var loggedUser = Session.GetLoggedUser();
            var chatBll = new Domain.BLL.ChatBLL();
            chatBll.ReadyMessages(loggedUser.ID, friendId);
        }
    }
}
