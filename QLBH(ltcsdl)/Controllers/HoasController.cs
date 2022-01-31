using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBH_ltcsdl_.Models;
using System.IO;

namespace QLBH_ltcsdl_.Controllers
{
    public class HoasController : Controller
    {
        private DBDoAn_Nhom16Entities8 db = new DBDoAn_Nhom16Entities8();

        // GET: Hoas
        public ActionResult Index()
        {
            var hoas = db.Hoas.Include(h => h.TheLoai);
            return View(hoas.ToList());
        }

        // GET: Hoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa hoa = db.Hoas.Find(id);
            if (hoa == null)
            {
                return HttpNotFound();
            }
            return View(hoa);
        }

        // GET: Hoas/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiHoa = new SelectList(db.TheLoais, "MaLoaiHoa", "TenLoaiHoa");
            return View();
        }

        // POST: Hoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoa,TenHoa,DonGia,MaLoaiHoa,HinhAnh")] Hoa hoa, HttpPostedFileBase HinhAnh)
        {
            if(hoa.TenHoa == null)
            {
                ModelState.AddModelError("TenHoa", "Tên sản phẩm không được để trống.");
            }

            else if (hoa.TenHoa.Length > 50)
            {
                ModelState.AddModelError("TenHoa", "Tên sản phẩm vượt quá ký tự cho phép.");
            }

            if (ModelState.IsValid)
            {
                if(HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    string filename = Path.GetFileName(HinhAnh.FileName);
                    string path = Server.MapPath("~/Images/" + filename); // đường dẫn cập nhật hình ảnh theo kiểu vật lý
                    hoa.HinhAnh = "Images/" + filename; // đường dẫn cập nhật hình ảnh vào database
                    HinhAnh.SaveAs(path);
                }
                db.Hoas.Add(hoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiHoa = new SelectList(db.TheLoais, "MaLoaiHoa", "TenLoaiHoa", hoa.MaLoaiHoa);
            return View(hoa);
        }

        // GET: Hoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa hoa = db.Hoas.Find(id);
            if (hoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiHoa = new SelectList(db.TheLoais, "MaLoaiHoa", "TenLoaiHoa", hoa.MaLoaiHoa);
            return View(hoa);
        }

        // POST: Hoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoa,TenHoa,DonGia,MaLoaiHoa,HinhAnh")] Hoa hoa, HttpPostedFileBase HinhAnh)
        {
            if (hoa.TenHoa == null)
            {
                ModelState.AddModelError("TenHoa", "Tên sản phẩm không được để trống.");
            }

            else if (hoa.TenHoa.Length > 50)
            {
                ModelState.AddModelError("TenHoa", "Tên sản phẩm vượt quá ký tự cho phép.");
            }

            if (ModelState.IsValid)
            {
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    string filename = Path.GetFileName(HinhAnh.FileName);
                    string path = Server.MapPath("~/Images/" + filename); // đường dẫn cập nhật hình ảnh theo kiểu vật lý
                    hoa.HinhAnh = "Images/" + filename; // đường dẫn cập nhật hình ảnh vào database
                    HinhAnh.SaveAs(path);
                }
                db.Entry(hoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiHoa = new SelectList(db.TheLoais, "MaLoaiHoa", "TenLoaiHoa", hoa.MaLoaiHoa);
            return View(hoa);
        }

        // GET: Hoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa hoa = db.Hoas.Find(id);
            if (hoa == null)
            {
                return HttpNotFound();
            }
            return View(hoa);
        }

        // POST: Hoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Hoa hoa = db.Hoas.Find(id);
            db.Hoas.Remove(hoa);
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
