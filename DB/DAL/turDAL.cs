using DB.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DAL
{
    public class turDAL
    {
        private static DBEntities db = new DBEntities();

        public static List<tur> Listele() { return db.tur.ToList(); }
        public static void Ekle(tur itemEntity) { db.Set(itemEntity.GetType()).Add(itemEntity); db.SaveChanges(); }
        public static tur ID(int id) { return db.tur.FirstOrDefault(u => u.IDTur == id); }
    }
}
