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

        private CharItemService CreateCharItemService()
        { var service = new CharItemService(); return service; }

        [HttpPost]
        public IHttpActionResult Post(ItemCreate item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ModelState == null)
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
            CharItemService charItemService = CreateCharItemService();
            var item = service.GetItemById(id);
            if (item.Name == "pbtd")
                return NotFound();

            var charItemChars = charItemService.GetCharsFromCharItemList(id);    //gets list of items from CharItemService
            item.Characters = charItemChars.ToList();

            return Ok(item);
        }

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

            if (updateMessage == null)
                return Ok(item);

            return BadRequest(updateMessage);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateItemService();

            string deleteMessage = service.DeleteItem(id);

            if (deleteMessage == null)
                return Ok("Successfully Deleted Item");

            return BadRequest(deleteMessage);
        }
    }
}
