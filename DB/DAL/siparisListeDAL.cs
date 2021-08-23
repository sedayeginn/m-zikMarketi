using DB.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DAL
{
    public class siparisListeDAL
    {
        private static DBEntities db = new DBEntities();

        public static List<siparis_liste> Listele() { return db.siparis_liste.ToList(); }
        public static List<siparis_liste> SiparisListesi(int id) { return db.siparis_liste.Where(x => x.SiparisID == id).ToList(); }
        public static void Ekle(siparis_liste itemEntity) { db.Set(itemEntity.GetType()).Add(itemEntity); db.SaveChanges(); }
        public static siparis_liste ID(int id) { return db.siparis_liste.FirstOrDefault(u => u.IDListe == id); }
    }
}
