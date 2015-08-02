using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CareFit.Portal.Models.Menu
{
    public class GetAutorizedMenuVM
    {
        public List<Domain.Repository.Menus> Menus { get; set; }

        public string MakeMenu()
        {
            StringBuilder strMenu = new StringBuilder();
            if (Menus != null)
            {
                if (Menus.Count > 0)
                {

                    foreach (var menu in Menus)
                    {
                        strMenu.Append("<li >");
                                       
                        strMenu.Append("<a href='#'><i class='" + menu.Icon + "'></i><i class='fa fa-angle-double-down i-right'></i> " + menu.Titulo + "</a>");
                        strMenu.Append("   <ul class=''>");
                        strMenu.Append("         " + MakeChildMenu(menu.Menus1));
                        strMenu.Append("   </ul>");
                        strMenu.Append("</li>");
                    }
                }
            }
            return strMenu.ToString();
        }
        public string MakeChildMenu(ICollection<Domain.Repository.Menus> childMenus)
        {
            StringBuilder strChildMenu = new StringBuilder();
            foreach (var childMenu in childMenus)
            {
                if (childMenu.Menus1 == null || childMenu.Menus1.Count == 0)
                {                                         
                    strChildMenu.Append(@"<li><a href='#' onclick='OpenContent(""" + childMenu.Controller + @""",""" + childMenu.Action + @""",null)'><i class='fa fa-angle-right'></i>" + childMenu.Titulo + "</a></li>");
                }
                else
                {
                    //strChildMenu.Append("<li>");
                    //strChildMenu.Append("<a href='#'><i class='" + childMenu.Icon + "'></i><i class='fa fa-angle-double-down i-right'></i> " + childMenu.Titulo + "<span class='fa arrow'></span></a>");
                    ////<a href='#'><i class='" + childMenu.Icon + "'></i><i class='fa fa-angle-double-down i-right'></i>" + childMenu.Titulo + "<span class='fa arrow'></span></a>");
                    //strChildMenu.Append("   <ul>");
                    //strChildMenu.Append("         " + MakeChildMenu(childMenu.Menus1));
                    //strChildMenu.Append("   </ul>");
                    //strChildMenu.Append("</li>");
                }
            }
            return strChildMenu.ToString();
        }
    }
}