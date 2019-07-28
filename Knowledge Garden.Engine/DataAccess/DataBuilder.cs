using Knowledge_Garden.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.DataAccess
{
    class DataBuilder
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Flower BuildFlower(int id, bool loadOwner = false)
        {
            Flower flower = db.Flowers.Find(id);
            if (flower != null)
            {
                if (loadOwner)
                {
                    db.Entry(flower).Reference(f => f.Owner).Load();
                }
                db.Entry(flower).Collection(f => f.Attachments).Query().Count();
            }
            return flower;
        }


    }
}
