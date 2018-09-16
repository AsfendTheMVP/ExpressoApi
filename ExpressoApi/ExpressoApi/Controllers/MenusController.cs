using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExpressoApi.Data;

namespace ExpressoApi.Controllers
{
    public class MenusController : ApiController
    {
        ExpressoDbContext expressoDbContext = new ExpressoDbContext();

        public IHttpActionResult GetMenus()
        {
            var menus = expressoDbContext.Menus.Include("SubMenus");
            return Ok(menus);
        }

        public IHttpActionResult GetMenu(int id)
        {
            var menu = expressoDbContext.Menus.Include("SubMenus").FirstOrDefault(m=>m.Id==id);
            if (menu==null)
            {
                return NotFound();
            }

            return Ok(menu);
        }
    }
}
