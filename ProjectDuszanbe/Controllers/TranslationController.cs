using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectDuszanbe.Application.Interfaces;
using ProjectDuszanbe.Application.ViewModels;
using ProjectDuszanbe.Domain.Model;
using ProjectDuszanbe.Infrastructure;

namespace ProjectDuszanbe.Controllers
{
    [ApiController]
    [Route("TranslationController")]
    public class TranslationController : ControllerBase
    {
        private readonly ILogger<TranslationController> _logger;
        private readonly ITranslationService _translationService;
        private readonly ILanguageService _languageService;
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TranslationController(ILogger<TranslationController> logger, ITranslationService translationService,
            ILanguageService languageService, Context context, IMapper mapper)
        {
            _logger = logger;
            _translationService = translationService;
            _languageService = languageService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{wordName}/{languageNameFrom}/{languageNameTo}")]
        public async Task<ActionResult<KeyValuePair<TranslationDto, TranslationDto>>> GetTranslation(string wordName,
            string languageNameFrom, string languageNameTo)
        {
            var translationFrom = await _context.Translations.Include(t => t.Language).Include(t => t.Word)
                .FirstOrDefaultAsync(w => w.Name == wordName);
            var languageFrom = await _languageService.GetLanguage(languageNameFrom);
            var languageTo = await _languageService.GetLanguage(languageNameTo);

            var translationPair = await _translationService.GetTranslation(_mapper.Map<TranslationDto>(translationFrom),
                languageFrom, languageTo);
            return Ok(translationPair);
        }
    }
}
