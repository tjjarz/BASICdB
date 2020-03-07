using BasicDb.Data;
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

        public Character getCharItemsByCharId(int charId)
        {
            List<Item> ItemList = new List<Item>();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters
                    .Single(e => e.CharId == charId);
                return new Character
                {
                    Name = entity.Name,
                    ShortDescription = entity.ShortDescription,
                    Description = entity.Description//,
                    //CharItems = entity.CharItems
                };
            }
        }
    }
}