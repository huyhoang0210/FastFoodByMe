using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fast_food1.Models
{
    public class GioHang
    {
        FastFoodDbContext db = new FastFoodDbContext();
        public int mamon { get; set; }
        public string anh { get; set; }
        public string tenmon { get; set; }
        public double giamon { get; set; }
        public int soluong { get; set; }
        public double tongtien
        {
            get { return soluong * giamon; }
        }
        public GioHang(int ma)
        {
            mamon = ma;
            Mon mon = db.Mons.Single(n => n.MaMon == mamon);
            tenmon = mon.TenMon;
            anh = mon.UrlImg;
            giamon = double.Parse(mon.Gia.ToString());
            soluong = 1;
        }
    }
}
