using BasicDb.Data;
using BasicDb.Models;
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
    public class CharItemController : ApiController
    {
        private CharItemService CreateCharItemService()
        {
            //string userId = Guid.Parse(User.Identity.GetUserId());
            var charItemService = new CharItemService();
            return charItemService;
        }

        [HttpPost]
        public IHttpActionResult PostCharItem(PostCharItem charItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCharItemService();
            if (!service.CreateCharItem(charItem))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateCharItemById(EditCharItem editCharItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCharItemService();
            string errorText = service.UpdateCharItemById(editCharItem);
            if (errorText == "Update completed")
            {
                return Ok();
            }

            return BadRequest(errorText);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCharItemById(int charItemId)
        {
            var service = CreateCharItemService();
            string errorText = (service.DeleteCharItemById(charItemId));
            if (errorText == "Record Deleted")
            {
                return Ok();
            }
            return BadRequest(errorText);
        }

        [HttpGet]
        public IHttpActionResult GetCharItems(int charId)
        {
            CharItemService charItemService = CreateCharItemService();
            var charItems = charItemService.getCharItemsByCharId(charId);
            return Ok(charItems);
        }
    }
}