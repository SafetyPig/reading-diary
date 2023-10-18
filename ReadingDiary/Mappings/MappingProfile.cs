using ReadingDiary.APImodels;
using ReadingDiary.DB.Models;

namespace ReadingDiary.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {

            CreateMap<DateTime, DateOnly>()
            .ConvertUsing(src => new DateOnly(src.Year, src.Month, src.Day));

            CreateMap<DateOnly, DateTime>()
                .ConvertUsing(src => src.ToDateTime(TimeOnly.MinValue));

            CreateMap<Diary, DiaryDTO>()
                .ReverseMap();

            CreateMap<DiaryEntry, DiaryEntryDTO>()
           .ForMember(dest => dest.Book, opt => opt.MapFrom(src => new BookLiteDTO
           {
               BookId = src.BookId,
               Title = src.Book.Title,
               AuthorId = src.AuthorId,
               AuthorName = src.Author.Name,
           }));
            
            CreateMap<DiaryEntryDTO, DiaryEntry>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Book!.AuthorId))
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Book!.BookId))
                .ForMember(dest => dest.Book, opt => opt.Ignore())
                .ForMember(dest => dest.Author, opt => opt.Ignore());
        }
    }
}
