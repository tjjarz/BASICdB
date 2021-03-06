﻿using BasicDb.Data;
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
        public string CreateMedia(MediaCreate media)
        {
            var entity =
                new Media()
                {
                    AddedBy = _userId,
                    Name = media.Name,
                    MediaType = media.MediaType,
                    Description = media.Description,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Media.Add(entity);
                return ctx.SaveChanges() == 1 ? "Media has been created" : "Media was not able to be created";
            }
        }

        //GET
        public IEnumerable<MediaGet> GetMedia()
        {
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query = ctx.Media.Select(e => new MediaGet { MediaId = e.MediaId, Title = e.Name, MediaType = e.MediaType, Description = e.Description, AddedBy = e.User.UserName });
                    return query.ToArray();
                }
            }
        }

        public MediaGet GetMediaById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Media.Count(e => e.MediaId == id) > 0)
                {
                    var entity = ctx.Media.Single(e => e.MediaId == id);

                    return new MediaGet
                    {
                        MediaId = entity.MediaId,
                        Title = entity.Name,
                        MediaType = entity.MediaType,
                        Description = entity.Description,
                        AddedBy = entity.User.UserName
                    };
                }

                return new MediaGet();
            }
        }

        public IEnumerable<MediaGet> GetMediaByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Media
                        .Where(e => e.Name.Contains(name))
                        .Select
                        (e => new MediaGet
                        {
                            MediaId = e.MediaId,
                            Title = e.Name,
                            MediaType = e.MediaType,
                            Description = e.Description,
                            AddedBy = e.User.UserName
                        });
                var asArray = entity.ToArray();
                return asArray;
            }
        }

        //UPDATE
        public string UpdateMedia(MediaUpdate media)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Media.Count(e => e.MediaId == media.MediaId) == 0)
                {
                    return $"Media ID {media.MediaId} NOT found in table";
                }
                var entity = ctx.Media.Single(e => e.MediaId == media.MediaId && e.AddedBy == _userId);
                entity.MediaId = media.MediaId;
                entity.Name = media.Title;
                entity.MediaType = media.MediaType;
                entity.Description = media.Description;
                entity.AddedBy = media.AddedBy;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1 ? null : "Media was not updated";
            }
        }

        //DELETE
        public string DeleteMedia(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Media.Count(e => e.MediaId == Id) == 0)
                {
                    return $"Media ID {Id} NOT found in table";
                }
                var entity =
                    ctx
                        .Media
                        .Single(e => e.MediaId == Id);

                ctx.Media.Remove(entity);

                return ctx.SaveChanges() == 1 ? null : "Unsuccessful deletion of media";
            }
        }
    }
}
