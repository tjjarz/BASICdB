using BasicDb.Models;
using BasicDb.Services;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BasicDb.Data;

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

            if (service.CreateItem(item) == "Something Went Wrong")
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
            var item = service.GetItemById(id);
            if (item.Name == "pbtd")
                return NotFound();

            return Ok(item);
        }

        //Get item by Name (returns as ItemDetail)
        public IHttpActionResult GetName(string name)
        {
            ItemService service = CreateItemService();
            var items = service.GetItemByName(name);

            return Ok(items);
        }

        [HttpPut]
        public IHttpActionResult Put(ItemEdit item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (item == null)
                return BadRequest("Model must not be null");

            var service = CreateItemService();

            string updateMessage = service.UpdateItem(item);

            if (updateMessage == "Something Went Wrong")
                return InternalServerError();
            else if (updateMessage == "Item Not Found")
                return NotFound();

            return Ok(item);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateItemService();

            string deleteMessage = service.DeleteItem(id);

            if (deleteMessage == "Something Went Wrong")
                return InternalServerError();

            // REPLACE THESE WITH BAD REQUEST TO SEND MESSAGE BACK?
            if (deleteMessage == "Not Found")
                return NotFound();

            return Ok("Successfully Deleted Item");
        }
    }
}
