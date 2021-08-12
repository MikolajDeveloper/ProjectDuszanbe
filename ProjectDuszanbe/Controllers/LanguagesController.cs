using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectDuszanbe.Application.Interfaces;
using ProjectDuszanbe.Application.ViewModels;
using ProjectDuszanbe.Domain.Model;
using ProjectDuszanbe.Infrastructure;

namespace ProjectDuszanbe.Controllers
{
    [ApiController]
    [Route("LanguagesController")]
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
            return Ok(language);
        }

        [HttpGet]
        [Description("Get all languages")]
        public async Task<ActionResult<List<LanguageDto>>> GetAllLanguages()
        {
            var languages = await _languageService.GetAllLanguages();
            return Ok(languages);
        }
    }
}