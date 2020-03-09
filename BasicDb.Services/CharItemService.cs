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
               /* if (ctx.CharItems.Where(e => e.Character.CharId == model.CharId && e.Item.ItemId == model.ItemId) != null)
                {
                    return false;
                }*/
                ctx.CharItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateCharItemById(int charItemId, PostCharItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.CharItems.Where(e => e.Character.CharId == model.CharId && e.Item.ItemId == model.ItemId) != null)
                {
                    return false;
                }
                var entity =
                    ctx
                        .CharItems
                        .Single(e => e.CharItemId == charItemId);

                entity.CharId = model.CharId;
                entity.ItemId = model.ItemId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCharItemById(int charItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharItems
                    .Single(e => e.CharItemId == charItemId);

                ctx.CharItems.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ItemDetail> GetCharItemsByCharId(int charId)
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
//=======
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
            }
        }
    }
}