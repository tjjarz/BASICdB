using BasicDb.Data;
using BasicDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Services
{
    public class CharMediaService
    {
        public CharMediaService()
        {
        }

        public string CreateCharMedia(PostCharMedia model)
        {
            var entity =
                new CharMedia()
                {
                    CharId = model.CharId,
                    MediaId = model.MediaId
                };
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.CharMedia.Count(e => e.Character.CharId == model.CharId && e.Media.MediaId == model.MediaId)
                    > 0)
                {
                    return "Combination already exists";
                }
                if (ctx.Media.Count(e => e.MediaId == model.MediaId)
                    == 0)
                {
                    return $"Invalid Media ID - Media ID {model.MediaId} doesn't exist";
                }
                if (ctx.Characters.Count(e => e.CharId == model.CharId)
                    == 0)
                {
                    return $"Invalid Character ID - Character ID {model.CharId} doesn't exist";
                }
                ctx.CharMedia.Add(entity);
                if (ctx.SaveChanges() == 1)
                    return "Character/Media Combination created";

                return "Character/Media Combination NOT created - unknown error";
            }
        }

        public string UpdateCharMediaById(EditCharMedia model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.CharMedia.Count(e => e.CharMediaId == model.CharMediaId) == 0)
                {
                    return "Record not found in table";
                }
                if (ctx.CharMedia.Count(e => e.CharId == model.CharId && e.MediaId == model.MediaId) != 0)
                {
                    return "Combination already exists in table";
                }
                if (ctx.Media.Count(e => e.MediaId == model.MediaId)
                    == 0)
                {
                    return $"Invalid Media ID - Media ID {model.MediaId} doesn't exist";
                }
                if (ctx.Characters.Count(e => e.CharId == model.CharId)
                    == 0)
                {
                    return $"Invalid Character ID - Character ID {model.CharId} doesn't exist";
                }
                var entity =
                    ctx
                        .CharMedia
                        .Single(e => e.CharMediaId == model.CharMediaId);

                entity.CharId = model.CharId;
                entity.MediaId = model.MediaId;

                if (ctx.SaveChanges() == 1)
                    return "Update completed";

                return "Update failed - unknown error";
            }
        }

        public string DeleteCharMediaById(int charMediaId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.CharMedia.Count(e => e.CharMediaId == charMediaId) == 0)
                {
                    return "No record found to delete";
                }
                var entity =
                    ctx
                    .CharMedia
                    .Single(e => e.CharMediaId == charMediaId);

                ctx.CharMedia.Remove(entity);
                if (ctx.SaveChanges() == 1)
                    return "Record Deleted";

                return "Delete failed - unknown error";
            }
        }

        public IEnumerable<GetCharMedia> getCharMediaByCharId(int charId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharMedia
                    .Where(e => e.Character.CharId == charId)
                    .Select
                    (e => new GetCharMedia
                    {
                        CharId = e.Character.CharId,
                        Name = e.Character.Name,
                        ShortDescription = e.Character.ShortDescription,
                        Description = e.Character.Description,
                        MediaId = e.Media.MediaId,
                        Title = e.Media.Title,
                        MediaType = e.Media.MediaType,
                        MediaDescription = e.Media.Description
                        //CharItems = e.Character.Item
                    });
                return entity.ToArray();
            }
        }
    }
}
