using AutoMapper;
using ProjectDuszanbe.Application.ViewModels;
using ProjectDuszanbe.Domain.Model;

namespace ProjectDuszanbe.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Language, LanguageDto>();
            CreateMap<Translation, TranslationDto>()
                .ForMember(t => t.Language, d 
                    => d.MapFrom(z => z.Language.Shortcut));
            CreateMap<Word, WordDto>();
        }
    }
}