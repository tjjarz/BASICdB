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
        [Authorize]
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

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ItemService itemService = CreateItemService();
            var items = itemService.GetItems();
            return Ok(items);
        }

        [HttpGet]
        public IHttpActionResult GetItemById(int id)
        {
            ItemService service = CreateItemService();
            var item = service.GerItemById(id);
            return Ok(item);
        }

        [HttpPut]
        public IHttpActionResult Put(ItemEdit item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (item == null)
                return BadRequest("Model must not be null");

            var service = CreateItemService();

            if (!service.UpdateItem(item))
                return InternalServerError();

            return Ok(item);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateItemService();

            if (!service.DeleteItem(id))
                return InternalServerError();

            return Ok("Successfully Deleted Item");
        }
    }
}
