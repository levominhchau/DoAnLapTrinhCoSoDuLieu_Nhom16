using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_ltcsdl_.Models;
using System.Collections;

namespace QLBH_ltcsdl_.Controllers
{
    public class MenuController : Controller
    {
        private DBDoAn_Nhom16Entities8 db = new DBDoAn_Nhom16Entities8();
        // GET: Menu
        public ActionResult Index()
        {
            var loaiHoa = db.TheLoais.ToList();
            Hashtable arrTheLoai = new Hashtable();
            foreach (var item in loaiHoa)
            {
                arrTheLoai.Add(item.MaLoaiHoa, item.TenLoaiHoa);
            }
            ViewBag.TheLoai = arrTheLoai;
            return PartialView("Index");
        }
    }
}