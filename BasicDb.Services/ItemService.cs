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

        public string CreateItem(ItemCreate model)
        {
            var entity = new Item()
            {
                AddedBy = _userId,
                Type = model.Type,
                Name = model.Name,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1 ? "Item Created Successfully" : "Something Went Wrong";
            }
        }

        public IEnumerable<ItemGetAll> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Items.Select(e => new ItemGetAll { Name = e.Name, AddedBy = e.User.UserName, Type = e.Type, ItemId = e.ItemId });
                return query.ToArray();
            }
        }

        public string UpdateItem(ItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Items.Count(e => e.ItemId == model.ItemId) == 0)
                {
                    return $"Media ID {model.ItemId} NOT found in table";
                }
                int test = ctx.Items.Count(e => e.ItemId == model.ItemId && e.AddedBy == _userId);
                if (ctx.Items.Count(e => e.ItemId == model.ItemId && e.AddedBy == _userId) > 0)
                {
                    var entity = ctx.Items.Single(e => e.ItemId == model.ItemId && e.AddedBy == _userId);

                    // maybe check here to see if the entity has a name/description/type value and return the not found here if it doesnt?

                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    entity.Type = model.Type;

                    return ctx.SaveChanges() == 1 ? null : "Something Went Wrong";
                }
                // find out why this doesnt work later but for now it's fine
                return "Item Not Found";
            }
        }

        public string DeleteItem(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Items.Count(e => e.ItemId == itemId) == 0)
                {
                    return $"Media ID {itemId} NOT found in table";
                }
                if (ctx.Items.Count(e => e.ItemId == itemId && e.AddedBy == _userId) > 0)
                {
                    var entity = ctx.Items.Single(e => e.ItemId == itemId && e.AddedBy == _userId);

                    ctx.Items.Remove(entity);

                    return ctx.SaveChanges() == 1 ? null : "Something Went Wrong";

                }
                return "Not Found";
            }
        }

        public ItemDetail GetItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Items.Count(e => e.ItemId == id) > 0)
                {
                    var entity = ctx.Items.Single(e => e.ItemId == id);

                    return new ItemDetail
                    {
                        ItemId = entity.ItemId,
                        Name = entity.Name,
                        Type = entity.Type,
                        Description = entity.Description,
                        AddedBy = entity.AddedBy
                    };
                }

                return new ItemDetail { Name = "pbtd" };
            }
        }

        public IEnumerable<ItemDetail> GetItemByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Where(e => e.Name.Contains(name))
                        .Select
                        (e => new ItemDetail
                        {
                            ItemId = e.ItemId,
                            Name = e.Name,
                            Type = e.Type,
                            Description = e.Description,
                            AddedBy = e.AddedBy
                        });
                var asArray = entity.ToArray();
                return asArray;
            }
        }
    }
}
