using AutoMapper;
using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;

namespace EcommerceMVC.Helpers
{
	
		public class AutoMapperProfile : Profile
		{
			public AutoMapperProfile()
			{
				CreateMap<RegisterVM, KhachHang>();
				//.ForMember(kh => kh.HoTen, option => option.MapFrom(RegisterVM => RegisterVM.HoTen))
				//.ReverseMap();
			}
		}
	
}
