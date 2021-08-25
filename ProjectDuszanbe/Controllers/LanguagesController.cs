using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectDuszanbe.Application.Interfaces;
using ProjectDuszanbe.Application.ViewModels;

namespace ProjectDuszanbe.Controllers
{
    [ApiController]
    [Route("api/languages")]
    public class LanguagesController : ControllerBase
    {
        private readonly ILogger<LanguagesController> _logger;
        private readonly ILanguageService _languageService;

        public LanguagesController(ILogger<LanguagesController> logger, ILanguageService languageService)
        {
            _logger = logger;
            _languageService = languageService;
        }

        [HttpGet("{shortcut}")]
        [Description("Get specific language")]
        public async Task<ActionResult<LanguageDto>> GetLanguage(string shortcut)
        {
            var language = await _languageService.GetLanguage(shortcut);

            if (language == null)
                return NotFound();
            
            return Ok(language);
        }

        [HttpGet]
        [Description("Get all languages")]
        public async Task<ActionResult<List<LanguageDto>>> GetAllLanguages()
        {
            var languages = await _languageService.GetAllLanguages();

            if (languages == null)
                return NotFound();
            
            return new JsonResult(languages);
        }
    }
}