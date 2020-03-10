using BasicDb.Data;
using BasicDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Services
{
    public class MediaService
    {
        private readonly string _userId;
        public MediaService(string userId)
        {
            _userId = userId;
        }
        public MediaService() { }

        //POST
        public string CreateMedia(MediaCreate media)
        {
            var entity =
                new Media()
                {
                    AddedBy = _userId,
                    Title = media.Title,
                    MediaType = media.MediaType,
                    Description = media.Description
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Media.Add(entity);
                return ctx.SaveChanges() == 1 ? "Media has been created": "Media was not able to be created";
            }
        }

        //GET
        public List<Media> GetMedia()
        {
            var ctx = new ApplicationDbContext();
            return ctx.Media.ToList();
        }

        public MediaDetail GetMediaById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Media.Count(e => e.MediaId == id) > 0)
                {
                    var entity = ctx.Media.Single(e => e.MediaId == id);

                    return new MediaDetail
                    {
                        MediaId = entity.MediaId,
                        Title = entity.Title,
                        MediaType = entity.MediaType,
                        Description = entity.Description,
                    };
                }

                return new MediaDetail();
            }
        }

        //UPDATE
        public string UpdateMedia(MediaUpdate media)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Media.Single(e => e.MediaId == media.MediaId);
                entity.MediaId = media.MediaId;
                entity.Title = media.Title;
                entity.MediaType = media.MediaType;
                entity.Description = media.Description;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1 ? "Media has been updated ": "Media was not updated";
            }
        }

        //DELETE
        public string DeleteMedia(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Media
                        .Single(e => e.MediaId == Id);

                ctx.Media.Remove(entity);

                return ctx.SaveChanges() == 1 ? "Successfully deleted media": "Unsuccessful deletion of media";
            }
        }
    }
}
