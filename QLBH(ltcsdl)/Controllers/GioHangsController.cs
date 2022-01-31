using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBH_ltcsdl_.Models;

namespace QLBH_ltcsdl_.Controllers
{
    public class GioHangsController : Controller
    {
        private DBDoAn_Nhom16Entities8 db = new DBDoAn_Nhom16Entities8();

        // GET: GioHangs
        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }

        public RedirectToRouteResult AddToCart(int MaHoa)
        {
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<CartItem>();
            }
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            if (giohang.FirstOrDefault(m => m.MaHoa == MaHoa) == null)
            {
                Hoa h = db.Hoas.Find(MaHoa);
                CartItem item = new CartItem();
                item.MaHoa = MaHoa;
                item.TenHoa = h.TenHoa;
                item.DonGia = Convert.ToDouble(h.DonGia);
                item.SoLuong = 1;
                giohang.Add(item);
            }
            else
            {
                CartItem item = giohang.FirstOrDefault(m => m.MaHoa == MaHoa);
                item.SoLuong++;
            }
            Session["giohang"] = giohang;
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult Update(int MaHoa, int txtSoluong)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem item = giohang.FirstOrDefault(m => m.MaHoa == MaHoa);
            if (item != null)
            {
                item.SoLuong = txtSoluong;
                Session["giohang"] = giohang;
            }

            return RedirectToAction("Index");
        }

        public RedirectToRouteResult Delete(int MaHoa)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem item = giohang.FirstOrDefault(m => m.MaHoa == MaHoa);
            if (item != null)
            {
                giohang.Remove(item);
                Session["giohang"] = giohang;
            }

            return RedirectToAction("Index");
        }
    }
}
