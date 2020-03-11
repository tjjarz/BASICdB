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

        public IEnumerable<GetCharMedia> GetCharMediaByCharId(int charId)
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
                        Title = e.Media.Name,
                        Medium = e.Media.Medium.ToString(),
                        MediaDescription = e.Media.Description
                        //CharItems = e.Character.Item
                    });
                return entity.ToArray();
            }
        }

        public IEnumerable<MediaShort> GetCharMediaList(int charId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharMedia
                    .Where(e => e.Character.CharId == charId)
                    .Select
                    (e => new MediaShort
                    {
                        MediaId = e.Media.MediaId,
                        Title = e.Media.Name,    //leaving this difference to illustrate we could have data "labeled" differently with models
                        //Description = e.Media.Description,
                        MediaType = e.Media.Medium
                    });
                return entity.ToArray();
            }
        }
    }
}
