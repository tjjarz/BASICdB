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
    public class CharacterController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            CharacterService characterService = CreateCharService();
            var characters = characterService.GetCharacters();

            return Ok(characters);
        }
        
        public IHttpActionResult Get(int id)
        {
            CharacterService characterService = CreateCharService();
            var character = characterService.GetCharById(id);
            CharItemService charItemService = CreateCharItemService();
            var charItems = charItemService.GetCharItemsByCharId(id);
            character.Items = charItems.ToList();
            /*  media listing stuff
            MediaService mediaService = CreateMediaService();
            var charMedia = mediaService.GetCharMediaByCharId();
            character.Media = charMedia.ToList();
            */
            return Ok(character);
        }/*
        public IHttpActionResult Put(NoteEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.UpdateNote(note))
                return InternalServerError();

            return Ok();
        }*/

        public IHttpActionResult Post(CharCreate character)
        {
            if (ModelState.IsValid == false) return BadRequest(ModelState);
            var service = CreateCharService();

            //service.CreateCharacter()
            if (service.CreateCharacter(character) == false) return InternalServerError();
            return Ok();
        }
        
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCharService();

            if (!service.DeleteChar(id))
                return InternalServerError();

            return Ok();
        }

        private CharacterService CreateCharService()
        {
            /*var userId = User.Identity.GetUserId;
            //var userId = User.Identity.Name;
            var userId = Guid.Parse(User.Identity.GetUserId());

            var characterService = new CharacterService(userId);*/
            var characterService = new CharacterService(); 

            return characterService;
        }

        private CharItemService CreateCharItemService()
        {
            var charItemService = new CharItemService();

            return charItemService;
        }

        private MediaService CreateMediaService()
        {
            var service = new MediaService();

            return service;
        }
    }
}
