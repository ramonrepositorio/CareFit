using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CareFit.Api
{
    public static class SessionExtension
    {
        public static Domain.Repository.Pessoas GetLoggedUser(this HttpSessionStateBase session)
        {
            Domain.Repository.Pessoas user = null;
            if (session["LoggedUser"] == null)
            {
                FormsAuthentication.SignOut();
                session.Abandon();                
            }
            else
            {
                string json = session["LoggedUser"].ToString();
                user = JsonConvert.DeserializeObject<Domain.Repository.Pessoas>(json);
            }
            return user;
        }
        public static void SetLoggedUser(this HttpSessionStateBase session, Domain.Repository.Pessoas user)
        {
            user.Pessoas2 = null;
            user.Pessoas1 = null;
            session.Add("LoggedUser", JsonConvert.SerializeObject(user));
        }
    }
}