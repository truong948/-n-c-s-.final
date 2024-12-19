using AutoMapper;
using EcommerceMVC.Data;
using EcommerceMVC.Helpers;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace EcommerceMVC.Controllers
{
	public class KhachHangController : Controller
	{
		private readonly Hshop2023Context db;
		private readonly IMapper _mapper;

		public KhachHangController(Hshop2023Context context, IMapper mapper)
		{
			db = context;
			_mapper = mapper;
		}
	}
} 
