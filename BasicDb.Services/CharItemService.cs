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
                if (ctx.Characters.Count(e => e.CharId == model.CharId) == 0)
                {
                    return $"Character {model.CharId} NOT found in table";
                }
                if (ctx.Items.Count(e => e.ItemId == model.ItemId) == 0)
                {
                    return $"Item {model.ItemId} NOT found in table";
                }
                ctx.CharItems.Add(entity);
                if (ctx.SaveChanges() == 1)
                    return null;

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
                if (ctx.Characters.Count(e => e.CharId == model.CharId) == 0)
                {
                    return $"Character {model.CharId} NOT found in table";
                }
                if (ctx.Items.Count(e => e.ItemId == model.ItemId) == 0)
                {
                    return $"Item {model.ItemId} NOT found in table";
                }
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
                    return null;

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
                    return null;

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
                    });
                return entity.ToArray();
            }
        }
        //this method is used by the CharacterController to get a character's list of items for display
        public IEnumerable<ItemGetAll> GetCharItemList(int charId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharItems
                    .Where(e => e.Character.CharId == charId)
                    .Select
                    (e => new ItemGetAll
                    {
                        ItemId = e.Item.ItemId,
                        Name = e.Item.Name,
                        Type = e.Item.Type,
                        AddedBy = e.Item.User.UserName
                    });
                return entity.ToArray();
            }
        }
    }
}