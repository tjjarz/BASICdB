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
                UserId = _userId,
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

        public IEnumerable<Item> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Items.ToList();
            }
        }
    }
}
