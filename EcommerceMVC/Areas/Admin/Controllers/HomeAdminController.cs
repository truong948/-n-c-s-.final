using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using EcommerceMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using System.Security.Claims;


namespace EcommerceMVC.Areas.Admin.Controllers
{

	[Area("admin")]
	[Route("admin")]
	[Route("admin/homeadmin")]
	[Authorize(Roles = "Admin")]
	public class HomeAdminController : Controller
	{
		private readonly Hshop2023Context db;

		public HomeAdminController(Hshop2023Context context)
		{
			db = context;
		}

		[Route("")]
		[Route("index")]
		public IActionResult Index()
		{
			return View();
		}

		[Route("Danhmucsanpham")]
		//public IActionResult DanhMucSanPham()
		//{
		//	var lstSanPham = db.HangHoas.ToList();
		//	return View(lstSanPham);

		//}

		public IActionResult DanhMucSanPham(int? page)
		{
			int pageSize = 12;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var lstsanpham = db.HangHoas.AsNoTracking().OrderBy(x => x.MaHh);
			IPagedList<HangHoa> lst = new PagedList<HangHoa>(lstsanpham, pageNumber, pageSize);
			return View(lst);

		}
		[Route("ThemSanPhamMoi")]
		[HttpGet]
		public IActionResult ThemSanPhamMoi()
		{
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenCongTy");
            return View();
        }
		[Route("ThemSanPhamMoi")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ThemSanPhamMoi(HangHoa sanPham)
		{
			if (ModelState.IsValid)
			{
				db.HangHoas.Add(sanPham);
				db.SaveChanges();
				return RedirectToAction("DanhMucSanPham");

			}
			return View(sanPham);
		}
		[Route("SuaSanPham")]
		[HttpGet]
		public IActionResult SuaSanPham(string maSanPham)
		{
			ViewBag.MaLoai = new SelectList(db.Loais.ToList(), "MaLoai", "TenLoai");
			ViewBag.MaNCC = new SelectList(db.NhaCungCaps.ToList(), "MaNcc", "TenCongTy");
			var sanPham = db.HangHoas.Find(maSanPham);

			return View(sanPham);
		}
		[Route("SuaSanPham")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SuaSanPham(HangHoa sanPham)
		{
			if (ModelState.IsValid)
			{
				db.Update(sanPham);
				db.SaveChanges();
				return RedirectToAction("DanhMucSanPham", "HomeAdmin");

			}
			return View(sanPham);
		}
	}
}
