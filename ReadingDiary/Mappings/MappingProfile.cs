using ReadingDiary.APImodels;
using ReadingDiary.DB.Models;

namespace ReadingDiary.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Diary, DiaryDTO>().ReverseMap();

            CreateMap<DiaryEntry, DiaryEntryDTO>().ReverseMap();
        }
    }
}
