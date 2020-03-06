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
        //private readonly string _userId;

        public CharItemService()
        {
            //_userId = userId;
        }

        public bool CreateCharItem(PostCharItem model)
        {
            var entity =
                new CharItem()
                {
                    //UserId = _userId
                    CharId = model.CharId,
                    ItemId = model.ItemId
                };
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.CharItems.Where(e => e.Character.CharId == model.CharId && e.Item.ItemId == model.ItemId) != null)
                {
                    return false;
                }
                ctx.CharItems.Add(entity);
                return ctx.SaveChanges() == 1;
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
