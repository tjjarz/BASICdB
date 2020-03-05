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

        //POST
        public bool CreateMedia(MediaCreate media)
        {
            var entity =
                new Media()
                {
                    MediaId = media.MediaId,
                    Title = media.Title,
                    Medium = media.Medium,
                    Description = media.Description
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Medias.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //GET
        public IEnumerable<Media> GetMedia()
        {
            var ctx = new ApplicationDbContext();
            return ctx.Medias.ToList();
        }
    }
}
