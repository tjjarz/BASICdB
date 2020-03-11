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
        [HttpPost]
        public IHttpActionResult Post(MediaCreate media)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (ModelState == null)
            {
                return BadRequest("Could not post");
            }

            var service = CreateMediaService();

            if (service.CreateMedia(media) == "Successfully posted")
            {
                return InternalServerError();
            }

            return Ok(media);
        }

        [Authorize]
        private MediaService CreateMediaService()
        {
            var userId = User.Identity.GetUserId();
            var mediaService = new MediaService(userId);
            return mediaService;
        }

        //GET
        [HttpGet]
        public IHttpActionResult Get()
        {
            MediaService mediaService = CreateMediaService();
            var medias = mediaService.GetMedia();
            return Ok(medias);
        }

        [HttpGet]
        public IHttpActionResult GetMediaById(int id)
        {
            MediaService mediaService = CreateMediaService();
            var mediaById = mediaService.GetMediaById(id);
            return Ok(mediaById);
        }

        //UPDATE
        [HttpPut]
        public IHttpActionResult Update(MediaUpdate media)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (media == null)
                return BadRequest("Must not be null");

            var service = CreateMediaService();

            string updateMessage = service.UpdateMedia(media);

            if (updateMessage == "Something did not go right")
                return InternalServerError();
            else if (updateMessage == "Media not found")
                return NotFound();

            return Ok(media);
        }

        //DELETE
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMediaService();

            string deleteMessage = service.DeleteMedia(id);

            if (deleteMessage == "Error")
                return InternalServerError();

            if (deleteMessage == "Not Found")
                return NotFound();

            return Ok("Media was successfully deleted");
        }
    }
}

