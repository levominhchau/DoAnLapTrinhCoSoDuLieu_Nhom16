using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_ltcsdl_.Models;
using System.Data.Entity;
using PagedList;

namespace QLBH_ltcsdl_.Controllers
{
    public class HomeController : Controller
    {
        private DBDoAn_Nhom16Entities8 db = new DBDoAn_Nhom16Entities8();
        public ActionResult Index(string currentFilter, int?page , int MaTheLoai = 0, string SearchString = "")
        {
            if (SearchString != "")
            {
                page = 1;
                var dshoa = db.Hoas.Include(s => s.TheLoai).Where(x => x.TenHoa.ToUpper().Contains(SearchString.ToUpper())).OrderBy(m => m.TenHoa);
                int pageSize = dshoa.Count();
                int pageNumber = (page ?? 1);
                return View(dshoa.ToPagedList(pageNumber, pageSize));
            }

            else
            {
                SearchString = currentFilter;
            }
            ViewBag.CurrentFilter = SearchString;

            if (MaTheLoai == 0)
            {
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var dshoa = db.Hoas.Include(s => s.TheLoai).OrderBy(x => x.TenHoa);
                return View(dshoa.ToPagedList(pageNumber, pageSize));
            }

            else
            {
                var dshoa = db.Hoas.Include(s => s.TheLoai).Where(x => x.MaLoaiHoa == MaTheLoai).OrderBy(m => m.TenHoa);
                int pageSize = dshoa.Count();
                int pageNumber = (page ?? 1);
                return View(dshoa.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}