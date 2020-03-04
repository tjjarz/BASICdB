using BasicDb.Models;
using BasicDb.Services;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicDb.WebAPI.Controllers
{
    public class ItemController : ApiController
    {
        private ItemService CreateItemService()
        {
            var userId = User.Identity.GetUserId();
            var itemService = new ItemService(userId);

            return itemService;
        }

        [HttpPost]
        public IHttpActionResult Post(ItemCreate item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(ModelState == null)
            {
                return BadRequest("Model must not be null");
            }

            var service = CreateItemService();

            if (!service.CreateItem(item))
            {
                return InternalServerError();
            }

            return Ok(item);
        }
    }
}
