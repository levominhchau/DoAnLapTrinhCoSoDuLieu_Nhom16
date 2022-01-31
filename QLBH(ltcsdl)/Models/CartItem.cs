using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBH_ltcsdl_.Models
{
    public class CartItem
    {
        public int MaHoa { get; set; }
        public string TenHoa { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien
        {
            get
            {
                return SoLuong * DonGia;
            }
        }
    }
}