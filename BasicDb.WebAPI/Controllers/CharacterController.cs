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
        //returns a list of all characters as CharListItem
        public IHttpActionResult Get()
        {
            CharacterService characterService = CreateCharService();
            var characterList = characterService.GetCharacters();

            return Ok(characterList);
        }

        //Get character by CharId (returns as CharDetail)
        public IHttpActionResult Get(int charId)
        {
            //init services for queries
            CharacterService characterService = CreateCharService();
            CharItemService charItemService = CreateCharItemService();
            CharMediaService charMediaService = CreateCharMediaService();

            CharDetail character = characterService.GetCharById(charId); //grabs char by id and sets up new character as CharDetail

            var charItems = charItemService.GetCharItemList(charId);    //gets list of items from CharItemService
            character.Items = charItems.ToList();

            var charMedia = charMediaService.GetCharMediaList(charId);
            character.Media = charMedia.ToList();
            
            return Ok(character);
        }

        //Edit/Update character, takes a CharEdit and uses UpdateCharacter service
        public IHttpActionResult Put(CharEdit character)
        {
            if (ModelState.IsValid == false) return BadRequest(ModelState);
            var service = CreateCharService();
            if (service.UpdateCharacter(character) == false) return InternalServerError();
            return Ok();
        }

        //Create Character, takes a Character and uses CreateCharacter service
        public IHttpActionResult Post(CharCreate character)
        {
            if (ModelState.IsValid == false) return BadRequest(ModelState);
            var service = CreateCharService();
            if (service.CreateCharacter(character) == false) return InternalServerError();
            return Ok();
        }
        
        //Deletes a character by CharId, using DeleteCharacter
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCharService();
            if (!service.DeleteCharacter(id)) return InternalServerError();
            return Ok();
        }

        //creates services for the above actions
        [Authorize]
        private CharacterService CreateCharService()
        {
            var userId = User.Identity.GetUserId();
            var characterService = new CharacterService(userId); 
            
            return characterService; 
        }

        private CharItemService CreateCharItemService()
        { var service = new CharItemService(); return service; }

        private CharMediaService CreateCharMediaService()
        { var service = new CharMediaService(); return service; }
    }
}
