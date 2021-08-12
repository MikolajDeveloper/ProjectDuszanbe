using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectDuszanbe.Application.ViewModels;
using ProjectDuszanbe.Domain.Model;

namespace ProjectDuszanbe.Application.Interfaces
{
    public interface ITranslationService
    {
        Task<KeyValuePair<TranslationDto, TranslationDto>> GetTranslation(TranslationDto word, LanguageDto languageFrom,
            LanguageDto languageTo);
    }
}