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
        private readonly Guid _userId;
        public CharacterService(Guid userId)
        {
            _userId = userId;
        }
        public CharacterService() { }

        public bool CreateCharacter(CharacterCreate character)
        {
            var entity =
                new Character()
                {
                    Name = character.Name,
                    ShortDescription = character.ShortDescription,
                    Description = character.Description,
                    UserId = _userId
                    //CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Character> GetCharacters()
        {
            var ctx = new ApplicationDbContext();
            return ctx.Characters.ToArray();

            /*
            using (var ctx = new ApplicationDbContext()) 
            {
                return ctx.Characters.ToArray();
            }*/
        }

        public bool UpdateCharacter(CharacterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Notes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
