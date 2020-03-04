using BasicDb.Data;
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

        public bool CreateMedia(MediaCreate media)
        {
            var entity =
                new MediaCreate()
                {
                    MediaId = media.MediaId,
                    Title = media.Title,
                    Medium = media.Medium,
                    Description = media.Description,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Media.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}