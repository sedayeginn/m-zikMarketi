using DB.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DAL
{
    public class kullaniciDAL
    {
        private static DBEntities db = new DBEntities();

        public static List<kullanici> Listele() { return db.kullanici.ToList(); }
        public static void Ekle(kullanici itemEntity) { db.Set(itemEntity.GetType()).Add(itemEntity); db.SaveChanges(); }
        public static void Guncelle(kullanici itemEntity) { db.Entry(itemEntity).State = EntityState.Modified; db.SaveChanges(); }
        public static void Sil(kullanici itemEntity) { using (DBEntities db = new DBEntities()) { itemEntity.AktifMi = false; db.SaveChanges(); } }
        public static kullanici ID(int id) { return db.kullanici.FirstOrDefault(u => u.IDKullanici == id); }
        public static kullanici Kontrol(kullanici itemEntity) { return db.kullanici.Where(u => u.Eposta == itemEntity.Eposta & u.Sifre == itemEntity.Sifre & u.AktifMi == true).FirstOrDefault(); }
    }
}
