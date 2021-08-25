using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectDuszanbe.Application.Interfaces;
using ProjectDuszanbe.Application.ViewModels;
using ProjectDuszanbe.Domain.Model;
using ProjectDuszanbe.Infrastructure;

namespace ProjectDuszanbe.Application.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TranslationService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<TranslationDto>> GetTranslation(string word, string languageFrom,
            string languageTo)
        {
            var wordForTranslation = await _context.Words.Include(w => w.Translations).ThenInclude(t => t.Language)
                .FirstOrDefaultAsync(w => w.Translations.Select(t => t.Name).Contains(word));

            var translationFrom = wordForTranslation.Translations.FirstOrDefault(t => t.Language.Shortcut == languageFrom);
            var translationTo = wordForTranslation.Translations.FirstOrDefault(t => t.Language.Shortcut == languageTo);

            return new List<TranslationDto>() {_mapper.Map<TranslationDto>(translationFrom),
                _mapper.Map<TranslationDto>(translationTo)};
        }
    }
}