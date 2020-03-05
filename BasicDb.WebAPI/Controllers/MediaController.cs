using BasicDb.Data;
using BasicDb.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BasicDb.WebAPI.Controllers
{
    public class MediaController : ApiController
    {
        public IHttpActionResult Post(Media media)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMediaService();

            if (!service.CreateMedia(media))
                return InternalServerError();

            return Ok();
        }

        private MediaService CreateMediaService()
        {
            var userId = User.Identity.GetUserId();
            var mediaService = new MediaService(userId);
            return mediaService;
        }
    }
}
