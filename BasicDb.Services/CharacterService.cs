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
                        //will need lists and user here too eventually
                    });
            return entity;
        }

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

        public bool UpdateCharacter(CharEdit character)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Characters.Single(e => e.CharId == character.CharId);
                entity.Name = character.Name;
                entity.ShortDescription = character.ShortDescription;
                entity.Description = character.Description;
                entity.ModifiedOn = DateTime.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCharacter(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharId == id);

                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
