using BasicDb.Models;
using BasicDb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BasicDb.WebAPI.Controllers
{
    public class CharMediaController : ApiController
    {
        private CharMediaService CreateCharMediaService()
        {
            var charMediaService = new CharMediaService();
            return charMediaService;
        }

        [HttpPost]
        public IHttpActionResult PostCharMedia(PostCharMedia charMedia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCharMediaService();
            string errorText = service.CreateCharMedia(charMedia);
            if (errorText == "Character/Media Combination created")
            {
                return Ok();
            }
            return BadRequest(errorText);
        }

        [HttpPut]
        public IHttpActionResult UpdateCharMediaById(EditCharMedia editCharMedia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCharMediaService();
            string errorText = service.UpdateCharMediaById(editCharMedia);
            if (errorText == "Update completed")
            {
                return Ok();
            }

            return BadRequest(errorText);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCharMediaById(int charMediaId)
        {
            var service = CreateCharMediaService();
            string errorText = (service.DeleteCharMediaById(charMediaId));
            if (errorText == "Record Deleted")
            {
                return Ok();
            }
            return BadRequest(errorText);
        }

        [HttpGet]
        public IHttpActionResult GetCharMedia(int charId)
        {
            CharMediaService charMediaService = CreateCharMediaService();
            var charMedia = charMediaService.getCharMediaByCharId(charId);
            return Ok(charMedia);
        }
    }
}