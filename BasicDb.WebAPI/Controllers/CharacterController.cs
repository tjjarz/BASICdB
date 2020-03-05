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
            CharacterService characterService = CreateCharacterService();
            var characters = characterService.GetCharacters();
            return Ok(characters);
        }
        /*
        public IHttpActionResult Get(int id)
        {
            CharacterService characterService = CreateNoteService();
            var characters = characterService.GetNoteById(id);
            return Ok(note);
        }
        public IHttpActionResult Put(NoteEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.UpdateNote(note))
                return InternalServerError();

            return Ok();
        }*/

        public IHttpActionResult Post(CharacterCreate character)
        {
            if (ModelState.IsValid == false) return BadRequest(ModelState);
            var service = CreateCharacterService();

            //service.CreateCharacter()
            if (service.CreateCharacter(character) == false) return InternalServerError();
            return Ok();
        }
        /*
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCharacterService();

            if (!service.DeleteNote(id))
                return InternalServerError();

            return Ok();
        }*/

        private CharacterService CreateCharacterService()
        {
            /*var userId = User.Identity.GetUserId;
            //var userId = User.Identity.Name;
            var userId = Guid.Parse(User.Identity.GetUserId());

            var characterService = new CharacterService(userId);*/
            var characterService = new CharacterService(); 

            return characterService;
        }
    }
}
