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

            if (!service.CreateMedia(media))
                return InternalServerError();

            return Ok();
        }

        private MediaService CreateMediaService()
        {
            var mediaService = new MediaService();
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

        //UPDATE
        [HttpPut]
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
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMediaService();

            if (!service.DeleteMedia(id))
                return InternalServerError();

            return Ok();
        }
    }

}

