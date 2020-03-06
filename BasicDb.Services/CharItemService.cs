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

        public bool CreateCharItem(CharItem model)
        {
            var entity =
                new CharItem()
                {
                    //UserId = _userId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CharItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GetCharItem> getCharItemsByCharId(int charId)
        {
            //List<Item> ItemList = new List<Item>();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharItems
                    .Where(e => e.Character.CharId == charId)
                    .Select
                    (e => new GetCharItem
                    {
                        Name = e.Character.Name,
                        ShortDescription = e.Character.ShortDescription,
                        Description = e.Character.Description,
                        CharItems = e.Character.Item  //.ToArray()
                    });
                return entity.ToArray();
            }
        }
    }
}
