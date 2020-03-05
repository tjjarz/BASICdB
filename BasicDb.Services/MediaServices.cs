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

        public bool CreateMedia(Media model)
        {
            var entity =
                new Media()
                {
                    Title = model.Title,
                    Medium = model.Medium,
                    Description = model.Description,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Media.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}