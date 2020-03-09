using BasicDb.Data;
using BasicDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Services
{
    public class CharItemService
    {
        public CharItemService()
        {
        }

        public bool CreateCharItem(PostCharItem model)
        {
            var entity =
                new CharItem()
                {
                    CharId = model.CharId,
                    ItemId = model.ItemId
                };
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.CharItems.Count(e => e.Character.CharId == model.CharId && e.Item.ItemId == model.ItemId)
                    > 0)
                {
                    return false;
                }
                ctx.CharItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public string UpdateCharItemById(EditCharItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                int testNum = (ctx.CharItems.Count(e => e.CharItemId == model.CharItemId));
                if (ctx.CharItems.Count(e => e.CharItemId == model.CharItemId) == 0)
                {
                    return "Record not found in table";
                }
                testNum = (ctx.CharItems.Count(e => e.CharId == model.CharId && e.ItemId == model.ItemId));
                if (ctx.CharItems.Count(e => e.CharId == model.CharId && e.ItemId == model.ItemId) != 0)
                {
                    return "Combination already exists in table";
                }
                var entity =
                    ctx
                        .CharItems
                        .Single(e => e.CharItemId == model.CharItemId);

                entity.CharId = model.CharId;
                entity.ItemId = model.ItemId;

                if (ctx.SaveChanges() == 1)
                    return "Update completed";

                return "Update failed - unknown error";
            }
        }

        public string DeleteCharItemById(int charItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.CharItems.Count(e => e.CharItemId == charItemId) == 0)
                {
                    return "No record found to delete";
                }
                var entity =
                    ctx
                    .CharItems
                    .Single(e => e.CharItemId == charItemId);

                ctx.CharItems.Remove(entity);
                if (ctx.SaveChanges() == 1)
                    return "Record Deleted";

                return "Delete failed - unknown error";
            }
        }

        public IEnumerable<GetCharItem> getCharItemsByCharId(int charId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharItems
                    .Where(e => e.Character.CharId == charId)
                    .Select
                    (e => new GetCharItem
                    {
                        CharId = e.Character.CharId,
                        Name = e.Character.Name,
                        ShortDescription = e.Character.ShortDescription,
                        Description = e.Character.Description,
                        ItemId = e.Item.ItemId,
                        ItemType = e.Item.Type,
                        ItemName = e.Item.Name,
                        ItemDescription = e.Item.Description
                        //CharItems = e.Character.Item
                    });
                return entity.ToArray();
            }
        }
    }
}