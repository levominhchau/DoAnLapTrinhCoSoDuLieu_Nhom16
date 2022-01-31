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
    public class ChiTietHoaDonsController : Controller
    {
        private DBDoAn_Nhom16Entities8 db = new DBDoAn_Nhom16Entities8();

        // GET: ChiTietHoaDons
        public ActionResult Index(int mahd)
        {
            List<KhachHang> khachhang = db.KhachHangs.ToList();
            List<HoaDon> hoadon = db.HoaDons.ToList();
            List<Hoa> sanpham = db.Hoas.ToList();
            List<ChiTietHoaDon> cthd = db.ChiTietHoaDons.ToList();
            var main = from h in hoadon
                       join k in khachhang on h.MaKH equals k.MaKH
                       where h.MaHoaDon == mahd
                       select new ViewModel
                       {
                           hoadon = h,
                           khachhang = k
                       };
            var sub = from c in cthd
                      join s in sanpham on c.MaHoa equals s.MaHoa
                      where c.MaHoaDon == mahd
                      select new ViewModel
                      {
                          cthd = c,
                          sanpham = s,
                          Thanhtien = Convert.ToDouble(c.DonGia * c.SoLuong)
                      };
            ViewBag.Main = main;
            ViewBag.Sub = sub;
            return View();
        }

        // GET: ChiTietHoaDons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Create
        public ActionResult Create()
        {
            ViewBag.MaHoa = new SelectList(db.Hoas, "MaHoa", "TenHoa");
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            return View();
        }

        // POST: ChiTietHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,MaHoa,SoLuong,DonGia,GiamGia")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHoaDons.Add(chiTietHoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHoa = new SelectList(db.Hoas, "MaHoa", "TenHoa", chiTietHoaDon.MaHoa);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", chiTietHoaDon.MaHoa);
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHoa = new SelectList(db.Hoas, "MaHoa", "TenHoa", chiTietHoaDon.MaHoa);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", chiTietHoaDon.MaHoa);
            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,MaKH,MaHoa,GiamGia,ThanhTien,SoLuong,Ngay")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHoa = new SelectList(db.Hoas, "MaHoa", "TenHoa", chiTietHoaDon.MaHoa);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", chiTietHoaDon.MaHoa);
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            db.ChiTietHoaDons.Remove(chiTietHoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
