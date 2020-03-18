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
        //creates services for the below actions
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



        //Create Character, takes a Character and uses CreateCharacter service
        public IHttpActionResult Post(CharCreate character)
        {
            if (ModelState.IsValid == false) return BadRequest(ModelState);
            var service = CreateCharService();
            if (service.CreateCharacter(character) == false) return InternalServerError();
            return Ok();
        }

        //Edit/Update character, takes a CharEdit and uses UpdateCharacter service
        public IHttpActionResult Put(CharEdit character)
        {
            if (ModelState.IsValid == false) return BadRequest(ModelState);
            var service = CreateCharService();
            string error = (service.UpdateCharacter(character));
            if (error != null) 
                return BadRequest(error);

            return Ok();
        }

        //Deletes a character by CharId, using DeleteCharacter
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCharService();
            string error = (service.DeleteCharacter(id));
            if (error != null)
                return BadRequest(error);

            return Ok();
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

        //returns an enumerable of all characters as CharListItem
        public IHttpActionResult GetCharacters()
        {
            CharacterService characterService = CreateCharService();
            var allCharacters = characterService.GetCharacters();

            return Ok(allCharacters);
        }

        //returns an enumerable of characters by Name as CharListItem
        public IHttpActionResult GetCharacters(string name)
        {
            CharacterService characterService = CreateCharService();
            var characters = characterService.GetCharByName(name);

            return Ok(characters);
        }
//<<<<<<< kerry9
//            if (ModelState.IsValid == false) return BadRequest(ModelState);
//            var service = CreateCharService();
//            string error = (service.UpdateCharacter(character));
//            if (error != null) 
//                return BadRequest(error);
//
//            return Ok();
//        }
//
//        //Create Character, takes a Character and uses CreateCharacter service
//        public IHttpActionResult Post(CharCreate character)
//        {
//            if (ModelState.IsValid == false) return BadRequest(ModelState);
//            var service = CreateCharService();
//            if (service.CreateCharacter(character) == false) return InternalServerError();
//            return Ok();
//        }
//        
//        //Deletes a character by CharId, using DeleteCharacter
//        public IHttpActionResult Delete(int id)
//        {
//            var service = CreateCharService();
//            string error = (service.DeleteCharacter(id));
//            if (error != null)
//                return BadRequest(error);
//
//            return Ok();
//=======
//            CharacterService characterService = CreateCharService();
//            var characters = characterService.GetCharacters(name);
//
//            return Ok(characters);
//>>>>>>> dev
    }
}
