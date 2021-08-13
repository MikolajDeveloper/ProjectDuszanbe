using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectDuszanbe.Application.ViewModels;

namespace ProjectDuszanbe.Application.Interfaces
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageDto>> GetAllLanguages();
        Task<LanguageDto> GetLanguage(string shortcut);
    }
}