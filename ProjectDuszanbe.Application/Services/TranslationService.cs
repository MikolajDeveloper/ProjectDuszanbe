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


        public async Task<KeyValuePair<TranslationDto, TranslationDto>> GetTranslation(TranslationDto word, LanguageDto languageFrom, LanguageDto languageTo)
        {
            var translationFrom = await FindTranslationAsync(word, languageFrom);
            var translationTo = await FindTranslationAsync(word, languageTo);

            return new KeyValuePair<TranslationDto, TranslationDto>(_mapper.Map<TranslationDto>(translationFrom), _mapper.Map<TranslationDto>(translationTo));
        }

        private Task<Translation> FindTranslationAsync(TranslationDto translation, LanguageDto language)
        {
            return _context.Translations.FirstOrDefaultAsync(t => t.Word.Id == translation.Word.Id && t.Language.Id == language.Id);
        }
    }
}