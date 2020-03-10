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
        public bool CreateMedia(MediaCreate media)
        {
            var entity =
                new Media()
                {
                    MediaId = media.MediaId,
                    Title = media.Title,
                    MediaType = media.MediaType,
                    Description = media.Description
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Media.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET
        public List<Media> GetMedia()
        {
            var ctx = new ApplicationDbContext();
            return ctx.Media.ToList();
        }

        //UPDATE
        public bool UpdateMedia(MediaUpdate media)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Media.Single(e => e.MediaId == media.MediaId);
                entity.MediaId = media.MediaId;
                entity.Title = media.Title;
                entity.MediaType = media.MediaType;
                entity.Description = media.Description;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteMedia(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Media
                        .Single(e => e.MediaId == Id);

                ctx.Media.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
