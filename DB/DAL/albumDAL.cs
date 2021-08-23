using DB.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DAL
{
    public class albumDAL
    {
        private static DBEntities db = new DBEntities();

        public static List<album> Listele() { return db.album.ToList(); }
        public static List<album> TureGoreListele(string tur) { return db.album.Where(x=> x.Turu == tur).ToList(); }
        public static List<album> SanatciyaGoreListele(int id) { return db.album.Where(x => x.SanatciID == id).ToList(); }
        public static List<album> SonOnAlbum() { return db.album.OrderByDescending(x=> x.IDAlbum).Take(10).ToList(); }
        public static List<album> IndirimdekiOnBesAlbum() { return db.album.Where(x => x.IndirimOrani > 0).Take(15).ToList(); }
        public static void Ekle(album itemEntity) { db.Set(itemEntity.GetType()).Add(itemEntity); db.SaveChanges(); }
        public static void Guncelle(album itemEntity) { db.Entry(itemEntity).State = EntityState.Modified; db.SaveChanges(); }
        public static void Sil(album itemEntity) { using (DBEntities db = new DBEntities()) { itemEntity.SilindiMi = true; db.SaveChanges(); } }
        public static album ID(int id) { return db.album.FirstOrDefault(u => u.IDAlbum == id); }
    }
}
