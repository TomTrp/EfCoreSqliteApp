using AutoMapper;
using EfCoreSqliteLibs.DTO;
using EfCoreSqliteLibs.Entities;

namespace EfCoreSqliteServiceApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<BookCreateDto, Book>()
                 .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(_ => DateTime.Now));


            CreateMap<Borrow, BorrowReadDto>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.BorrowUserName, opt => opt.MapFrom(src => src.User.UserName));
            CreateMap<BorrowReadDto, Borrow>();

            CreateMap<BorrowCreateDto, Borrow>()
                .ForMember(dest => dest.BorrowDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => "Borrowed"));
            CreateMap<Borrow, BorrowCreateDto>();


        }
    }
}
