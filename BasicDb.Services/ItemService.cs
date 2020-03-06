using BasicDb.Data;
using BasicDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Services
{
    public class ItemService
    {
        private readonly string _userId;
        public ItemService(string userId)
        {
            _userId = userId;
        }

        public bool CreateItem(ItemCreate model)
        {
            var entity = new Item()
            {
                AddedBy = _userId,
                Type = model.Type,
                Name = model.Name,
                Description = model.Description
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ItemGetAll> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Items.Select(e => new ItemGetAll { Description = e.Description, Name = e.Name, AddedBy = e.User.UserName, Type = e.Type, ItemId = e.ItemId });
                return query.ToArray();
            }
        }

        public bool UpdateItem(ItemEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Items.Single(e => e.ItemId == model.ItemId && e.AddedBy == _userId);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Type = model.Type;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteItem(int itemId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Items.Single(e => e.ItemId == itemId && e.AddedBy == _userId);

                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public ItemDetail GetItemById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Items.Single(e => e.ItemId == id);

                return new ItemDetail
                {
                    ItemId = entity.ItemId,
                    Name = entity.Name,
                    Type = entity.Type,
                    Description = entity.Description,
                    AddedBy = entity.User.UserName
                };
            }
        }
    }
}
