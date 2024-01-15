using OnTap2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnTap2.Controllers
{
    public class HomeController : Controller
    {
        QLBanHangQuanAoEntities db = new QLBanHangQuanAoEntities();
        public ActionResult Index()
        {
            var phanloai = db.PhanLoaiPhus.ToList();
            var sanpham = db.SanPhams.ToList();
            ViewBag.PhanLoai = phanloai;
            return View(sanpham);
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
        //của thỏa
        //public async Task<ActionResult> GetProductByCategory(string phanloai)
        //{
        //    List<SanPham> products = null;
        //    if (phanloai == null || phanloai == "Tất cả sản phẩm")
        //    {
        //        products = await db.SanPhams.ToListAsync();
        //    }
        //    else
        //    {
        //        products = await db.SanPhams
        //                    .Where(sp => sp.PhanLoaiPhu.TenPhanLoaiPhu == phanloai)
        //                    .ToListAsync();
        //    }
        //    var _sanPham = products
        //        .Select(sp => new SanPham
        //        {
        //            MaSanPham = sp.MaSanPham,
        //            TenSanPham = sp.TenSanPham,
        //            DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat,
        //            TrangThai = sp.TrangThai,
        //            MoTaNgan = sp.MoTaNgan,
        //            AnhDaiDien = sp.AnhDaiDien,
        //            NoiBat = sp.NoiBat,
        //            MaPhanLoaiPhu = sp.MaPhanLoaiPhu,
        //            MaPhanLoai = sp.MaPhanLoai,
        //            GiaNhap = sp.GiaNhap
        //        }).ToList();
        //    return Json(new { sanpham1 = _sanPham }, JsonRequestBehavior.AllowGet);
        //}



        //của huy
        [HttpPost]
        public ActionResult GetProductByCategory(string phanLoai)
        {
            // trường hợp người dùng chọn "Tất cả sản phẩm"
            if (phanLoai == "Tất cả sản phẩm")
            {
                // lấy ra tất cả sản phẩm
                var sanPham1 = db.SanPhams.ToList();

                // bỏ các thuộc tính khóa ngoại để tránh liên kết vòng
                var _sanPham1 = sanPham1
                .Select(sp => new SanPham
                {
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat,
                    DonGiaBanLonNhat = sp.DonGiaBanLonNhat,
                    TrangThai = sp.TrangThai,
                    MoTaNgan = sp.MoTaNgan,
                    AnhDaiDien = sp.AnhDaiDien,
                    NoiBat = sp.NoiBat,
                    MaPhanLoaiPhu = sp.MaPhanLoaiPhu,
                    MaPhanLoai = sp.MaPhanLoai,
                    GiaNhap = sp.GiaNhap
                }).ToList();

                return Json(new { success = true, sanPham = _sanPham1 });
            }

            // trường hợp người dùng chọn các phân loại còn lại
            var sanPham = db.SanPhams
                .Where(sp => sp.PhanLoaiPhu.TenPhanLoaiPhu == phanLoai).ToList();

            // bỏ các thuộc tính khóa ngoại để tránh liên kết vòng
            var _sanPham = sanPham
                .Select(sp => new SanPham
                {
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat,
                    DonGiaBanLonNhat = sp.DonGiaBanLonNhat,
                    TrangThai = sp.TrangThai,
                    MoTaNgan = sp.MoTaNgan,
                    AnhDaiDien = sp.AnhDaiDien,
                    NoiBat = sp.NoiBat,
                    MaPhanLoaiPhu = sp.MaPhanLoaiPhu,
                    MaPhanLoai = sp.MaPhanLoai,
                    GiaNhap = sp.GiaNhap
                }).ToList();

            return Json(new { success = true, sanPham = _sanPham });
        }
        //public ActionResult suasanpham()
        //{
        //    var phanLoaiChinh = db.PhanLoais.ToList();

        //    var phanLoaiPhu = db.PhanLoaiPhus.ToList();

        //    // Tạo SelectList
        //    ViewBag.PhanLoaiChinh = new SelectList(phanLoaiChinh, "MaPhanLoai", "PhanLoaiChinh");
        //    ViewBag.PhanLoaiPhu = new SelectList(phanLoaiPhu, "MaPhanLoaiPhu", "TenPhanLoaiPhu");

        //    return View();
        //}

        }
}