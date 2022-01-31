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
    public class KhachHangsController : Controller
    {
        private DBDoAn_Nhom16Entities8 db = new DBDoAn_Nhom16Entities8();

        // GET: KhachHangs
        public ActionResult Index()
        {
            return View(db.KhachHangs.ToList());
        }

        // GET: KhachHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: KhachHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,TenKH,DiaChi,Email,SoDienThoai")] KhachHang khachHang)
        {
            
            if (khachHang.TenKH == null)
            {
                ModelState.AddModelError("TenKH", "Tên khách hàng không được bỏ trống.");
            }

            else if (khachHang.TenKH.Length > 70)
            {
                ModelState.AddModelError("TenKH", "Tên khách hàng vượt quá ký tự cho phép.");
            }
            
            if (khachHang.DiaChi == null)
            {
                ModelState.AddModelError("Diachi", "Địa chỉ khách hàng không được bỏ trống.");
            }

            if (khachHang.SoDienThoai == null)
            {
                ModelState.AddModelError("SoDienThoai", "Số điện thoại của khách hàng không được bỏ trống.");
            }

            //if(khachHang.SoDienThoai)

            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(khachHang);
        }

        // GET: KhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,TenKH,DiaChi,Email,SoDienThoai")] KhachHang khachHang)
        {

            if (khachHang.TenKH == null)
            {
                ModelState.AddModelError("TenKH", "Tên khách hàng không được bỏ trống.");
            }

            else if (khachHang.TenKH.Length > 50)
            {
                ModelState.AddModelError("TenKH", "Tên khách hàng vượt quá ký tự cho phép.");
            }

            if (khachHang.DiaChi == null)
            {
                ModelState.AddModelError("Diachi", "Địa chỉ khách hàng không được bỏ trống.");
            }

            if (khachHang.SoDienThoai == null)
            {
                ModelState.AddModelError("SoDienThoai", "Số điện thoại của khách hàng không được bỏ trống.");
            }

            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: KhachHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
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
