using BasicDb.Data;
using BasicDb.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicDb.WebAPI.Controllers
{
    [Authorize]
    public class CharItemController : ApiController
    {
        private CharItemService CreateCharItemService()
        {
            //string userId = Guid.Parse(User.Identity.GetUserId());
            var charItemService = new CharItemService();
            return charItemService;
        }

        public IHttpActionResult GetCharItems(int charId)
        {
            CharItemService charItemService = CreateCharItemService();
            var charItem = charItemService.getCharItemsByCharId(charId);
            return Ok(charItem);
        }
    }
}
