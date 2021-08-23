using DB.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DAL
{
    public class siparisDAL
    {
        private static DBEntities db = new DBEntities();

        public static List<siparis> Listele() { return db.siparis.ToList(); }
        public static void Ekle(siparis itemEntity) { db.Set(itemEntity.GetType()).Add(itemEntity); db.SaveChanges(); }
        public static void Guncelle(siparis itemEntity) { db.Entry(itemEntity).State = EntityState.Modified; db.SaveChanges(); }
        public static siparis ID(int id) { return db.siparis.FirstOrDefault(u => u.IDSiparis == id); }
    }
}
