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
            if (errorText == null)
            {
                return Ok("Character/Media Combination created");
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
            if (errorText == null)
            {
                return Ok("Update completed");
            }

            return BadRequest(errorText);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCharMediaById(int charMediaId)
        {
            var service = CreateCharMediaService();
            string errorText = (service.DeleteCharMediaById(charMediaId));
            if (errorText == null)
            {
                return Ok("Record Deleted");
            }
            return BadRequest(errorText);
        }

        [HttpGet]
        public IHttpActionResult GetCharMedia(int charId)
        {
            CharMediaService charMediaService = CreateCharMediaService();
            var charMedia = charMediaService.GetCharMediaByCharId(charId);
            return Ok(charMedia);
        }
    }
}