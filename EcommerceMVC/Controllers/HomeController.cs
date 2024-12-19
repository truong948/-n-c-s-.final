using AutoMapper;
using EcommerceMVC.Data;
using EcommerceMVC.Helpers;
using EcommerceMVC.Models;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EcommerceMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly Hshop2023Context db;
		private readonly IMapper _mapper;


		public HomeController(Hshop2023Context context, ILogger<HomeController> logger, IMapper mapper)
		{
			_logger = logger;
			db = context;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			return View();
		}
		
		public IActionResult PageNotFound()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


		#region Register
		[HttpGet]
		[Route("DangKy")]
		public IActionResult DangKy()
		{
			return View();
		}	

		[HttpPost]
		[Route("DangKy")]
		public IActionResult DangKy(RegisterVM model, IFormFile Hinh)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var khachHang = _mapper.Map<KhachHang>(model);
					khachHang.RandomKey = MyUtil.GenerateRamdomKey();
					khachHang.MatKhau = model.MatKhau.ToMd5Hash(khachHang.RandomKey);
					khachHang.HieuLuc = true;//sẽ xử lý khi dùng Mail để active
					khachHang.VaiTro = 0;

					if (Hinh != null)
					{
						khachHang.Hinh = MyUtil.UploadHinh(Hinh, "KhachHang");
					}

					db.Add(khachHang);
					db.SaveChanges();
					return RedirectToAction("Index", "HangHoa");
				}
				catch (Exception ex)
				{
					var mess = $"{ex.Message} shh";
				}
			}
			return View();
		}
		#endregion


		#region Login
		[HttpGet]
		[Route("DangNhap")]
		public IActionResult DangNhap(string? ReturnUrl = "/")
		{
			var user = User.FindFirst(ClaimTypes.Name);

            ViewBag.ReturnUrl = ReturnUrl;

			if (user == null)
			{
				return View();

			}
			return Redirect(ReturnUrl);
		}

		[HttpPost]
		[Route("DangNhap")]
		public async Task<IActionResult> DangNhap(LoginVM model, string? ReturnUrl)
		{
			ViewBag.ReturnUrl = ReturnUrl;
			if (ModelState.IsValid)
			{
				var khachHang = db.KhachHangs.SingleOrDefault(kh => kh.MaKh == model.UserName && kh.MatKhau == model.Password);
				var nhanvien = db.NhanViens.SingleOrDefault(nv => nv.MaNv == model.UserName && nv.MatKhau == model.Password);

				if (khachHang == null && nhanvien == null)
				{
					ModelState.AddModelError("loi", "Đăng nhập không thành công");
				}
				else if (khachHang != null && !khachHang.HieuLuc)
				{
					ModelState.AddModelError("loi", "Tài khoản đã bị khóa. Vui lòng liên hệ Admin.");
				}
				else
				{

					List<Claim> claims;
					if (khachHang != null) // Là khách hàng đăng nhập
					{
						claims = new List<Claim> {
								new Claim(ClaimTypes.Email, khachHang.Email),
								new Claim(ClaimTypes.Name, khachHang.HoTen),
								new Claim("CustomerID", khachHang.MaKh),

								//claim - role động
								new Claim(ClaimTypes.Role, "Customer")
							};
					}
					else // Là nhân viên
					{
						claims = new List<Claim> {
								new Claim(ClaimTypes.Email, nhanvien.Email),
								new Claim(ClaimTypes.Name, nhanvien.HoTen),
								new Claim("CustomerID", nhanvien.MaNv),

								//claim - role động
								new Claim(ClaimTypes.Role, nhanvien.IsAdmin ? "Admin": "Manager")
							};
					}

					var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

					await HttpContext.SignInAsync(claimsPrincipal);

					if (Url.IsLocalUrl(ReturnUrl))
					{
						return Redirect(ReturnUrl);
					}
					else
					{
						return Redirect("/");
					}
				}

			}
			return View();
		}
		#endregion

		[Authorize]
		public IActionResult Profile()
		{
			return View();
		}

		[Authorize]
		[Route("DangXuat")]
		public async Task<IActionResult> DangXuat()
		{
			await HttpContext.SignOutAsync();
			return Redirect("/");
		}
	}
}
