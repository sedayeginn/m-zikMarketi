using DB.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DAL
{
    public class sanatciDAL
    {
        private static DBEntities db = new DBEntities();

        public static List<sanatci> Listele() { return db.sanatci.ToList(); }
        public static void Ekle(sanatci itemEntity) { db.Set(itemEntity.GetType()).Add(itemEntity); db.SaveChanges(); }
        public static sanatci ID(int id) { return db.sanatci.FirstOrDefault(u => u.IDSanatci == id); }
    }
}
