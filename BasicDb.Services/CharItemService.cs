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

        public string CreateCharItem(PostCharItem model)
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
                    return "Combination already exists";
                }
                if (ctx.Items.Count(e => e.ItemId == model.ItemId)
                    == 0)
                {
                    return $"Invalid Item ID - Item ID {model.ItemId} doesn't exist";
                }
                if (ctx.Characters.Count(e => e.CharId == model.CharId)
                    == 0)
                {
                    return $"Invalid Character ID - Character ID {model.CharId} doesn't exist";
                }
                ctx.CharItems.Add(entity);
                if (ctx.SaveChanges() == 1)
                    return "Character/Item Combination created";

                return "Character/Item Combination NOT created - unknown error";
            }
        }

        public string UpdateCharItemById(EditCharItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.CharItems.Count(e => e.CharItemId == model.CharItemId) == 0)
                {
                    return "Record not found in table";
                }
                if (ctx.CharItems.Count(e => e.CharId == model.CharId && e.ItemId == model.ItemId) != 0)
                {
                    return "Combination already exists in table";
                }
                if (ctx.Items.Count(e => e.ItemId == model.ItemId)
                    == 0)
                {
                    return $"Invalid Item ID - Item ID {model.ItemId} doesn't exist";
                }
                if (ctx.Characters.Count(e => e.CharId == model.CharId)
                    == 0)
                {
                    return $"Invalid Character ID - Character ID {model.CharId} doesn't exist";
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

        public IEnumerable<GetCharItem> GetCharItemsByCharId(int charId)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharItems
                    .Where(e => e.Character.CharId == charId)
                    .Select
                    //                    .Characters
                    //                    .Single(e => e.CharId == charId);
                    //                return new Character
                    //                {
                    //                    Name = entity.Name,
                    //                    ShortDescription = entity.ShortDescription,
                    //                    Description = entity.Description//,
                    //                    //CharItems = entity.CharItems
                    //                };
                    //>>>>>>> dev
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
        //newwer betterer get charitems list
        public IEnumerable<ItemDetail> GetCharItemList(int charId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharItems
                    .Where(e => e.Character.CharId == charId)
                    .Select
                    (e => new ItemDetail
                    {
                        ItemId = e.Item.ItemId,
                        Name = e.Item.Name,
                        Description = e.Item.Description,
                        Type = e.Item.Type
                        //CharItems = e.Character.Item
                    });
                return entity.ToArray();
            }
        }
    }
}