using AutoMapper;
using LibraryApp.Domain.Entities;
using LibraryApp.Application.DTOs.User;
using LibraryApp.Application.DTOs.Book;
using LibraryApp.Application.DTOs.BookBorrowing;
using LibraryApp.Domain.Enums;
using LibraryApp.Application.DTOs.Category;

namespace LibraryApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();

            CreateMap<UpdateUserDto, User>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<Book, BookDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateBookDto, Book>();

            CreateMap<UpdateBookDto, Book>();

            CreateMap<Category, CategoryDto>();

            CreateMap<CategoryDto, Category>();

            CreateMap<CreateCategoryDto, Category>();

            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<BookBorrowingRequestCreateDto, BookBorrowingRequest>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => RequestStatus.Waiting))
            .ForMember(dest => dest.BookBorrowingRequestDetails, opt => opt.Ignore());

            CreateMap<BookBorrowingRequest, BookBorrowingRequestResponseDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.BookTitles, opt => opt.MapFrom(src =>
                    src.BookBorrowingRequestDetails.Where(b => b.Book != null)
                    .Select(b => b.Book.Title).ToList()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<BookBorrowingRequestUpdateStatusDto, BookBorrowingRequest>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<BookBorrowingRequestDetail, BookBorrowingRequestDetailDto>();
        }
    }
}
