using BasicDb.Data;
using BasicDb.Models;
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
        //POST
        public IHttpActionResult Post(MediaCreate media)
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

        //GET
        public IHttpActionResult Get()
        {
            MediaService mediaService = CreateMediaService();
            var medias = mediaService.GetMedia();
            return Ok(medias);
        }

        //UPDATE
        public IHttpActionResult Update(MediaUpdate media)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMediaService();

            if (!service.UpdateMedia(media))
                return InternalServerError();

            return Ok();
        }

        //DELETE
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMediaService();

            if (!service.DeleteMedia(id))
                return InternalServerError();

            return Ok();
        }
    }

}

