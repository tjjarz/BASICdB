using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicDb.Data;
using BasicDb.Models;

namespace BasicDb.Services
{
    public class CharacterService
    {
        private readonly string _userId;
        public CharacterService(string userId)
        {
            _userId = userId;
        }
        public CharacterService() { }

        public bool CreateCharacter(CharCreate character)
        {
            var entity =
                new Character()
                {
                    Name = character.Name,
                    ShortDescription = character.ShortDescription,
                    Description = character.Description,
                    AddedBy = _userId,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                    //CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

//        public bool UpdateCharacter(CharEdit character)
//        {
//            using (var ctx = new ApplicationDbContext())
//            {
//                var entity = ctx.Characters.Single(e => e.CharId == character.CharId);
//                entity.Name = character.Name;
//                entity.ShortDescription = character.ShortDescription;
//                entity.Description = character.Description;
//                entity.ModifiedOn = DateTime.Now;
//
//                return ctx.SaveChanges() == 1;
//            }
//        }
//        public bool DeleteCharacter(int id)
//        {
//            using (var ctx = new ApplicationDbContext())
//            {
//                var entity =
//                    ctx
//                        .Characters
//                        .Single(e => e.CharId == id);
//
//                ctx.Characters.Remove(entity);
//
//                return ctx.SaveChanges() == 1;
//            }
//        }

        public CharDetail GetCharById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharId == id);
                return
                    new CharDetail
                    {
                        CharId = entity.CharId,
                        Name = entity.Name,
                        ShortDescription = entity.ShortDescription,
                        Description = entity.Description,
                        CreatedOn = entity.CreatedOn,
                        ModifiedOn = entity.ModifiedOn,
                        AddedBy = entity.User.UserName

                        //will need lists and user here too eventually
                    };
            }
        }

//<<<<<<< kerry9
        public IEnumerable<CharListItem> GetCharByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Where(e => e.Name.Contains(name))
                        .Select
                        (e => new CharListItem
                        {
                            CharId = e.CharId,
                            Name = e.Name,
                            ShortDescription = e.ShortDescription
                            //will need lists and user here too eventually
                        });
                var asArray = entity.ToArray();
                return asArray;
            }
        }

        public string UpdateCharacter(CharEdit character)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Characters.Count(e => e.CharId == character.CharId) == 0)
                {
                    return $"Character {character.CharId} NOT found in table";
                }
                var entity = ctx.Characters.Single(e => e.CharId == character.CharId);
                entity.Name = character.Name;
                entity.ShortDescription = character.ShortDescription;
                entity.Description = character.Description;
                entity.ModifiedOn = DateTime.Now;

                if (ctx.SaveChanges() == 1)
                    return null;

                return $"Character {character.CharId} NOT updated - unknown error";
            }
        }
//        public string DeleteCharacter(int id)
//=======
        public IEnumerable<CharListItem> GetCharacters()
        {
            var ctx = new ApplicationDbContext();

            var entity =
                ctx
                .Characters
                .Select(e =>
                new CharListItem
                {
                    CharId = e.CharId,
                    Name = e.Name,
                    ShortDescription = e.ShortDescription
                });
            return entity;
        }

//        public IEnumerable<CharListItem> GetCharacters(string name)
        public string DeleteCharacter(int id)
//>>>>>>> dev
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Characters.Count(e => e.CharId == id) == 0)
                {
                    return $"Character {id} NOT found in table";
                }
                //if (ctx.CharItems.Count(e => e.CharId == id) != 0)
                //{
                //    return $"Character {id} is still associated with Items. Delete the association before deleting the Character";
                //}
                //if (ctx.CharMedia.Count(e => e.CharId == id) != 0)
                //{
                //    return $"Character {id} is still associated with Media. Delete the association before deleting the Character";
                //}
                var entity =
                    ctx
//<<<<<<< kerry9
                        .Characters
                        .Single(e => e.CharId == id);

                ctx.Characters.Remove(entity);

                if (ctx.SaveChanges() == 1)
                    return null;

                return $"Character {id} not found in Character Table";
//=======
//                    .Characters
//                    .Where(e => e.Name.Contains(name))
//                    .Select
//                    (e => new CharListItem
//                    {
//                        CharId = e.CharId,
//                        Name = e.Name,
//                        ShortDescription = e.ShortDescription
//                    });
//                    //var asArray = entity.ToArray();
//                return entity;
//>>>>>>> dev
            }
        }


    }
}
