using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBH_ltcsdl_.Models
{
    public class ViewModel
    {
        public KhachHang khachhang { get; set; }
        public HoaDon hoadon { get; set; }
        public TheLoai loaisp { get; set; }
        public ChiTietHoaDon cthd { get; set; }
        public Hoa sanpham { get; set; }
        public double Thanhtien { get; set; }
    }
}