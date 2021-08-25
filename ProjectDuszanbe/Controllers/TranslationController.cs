using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectDuszanbe.Application.Interfaces;
using ProjectDuszanbe.Application.ViewModels;

namespace ProjectDuszanbe.Controllers
{
    [ApiController]
    [Route("api/translations")]
    public class TranslationController : ControllerBase
    {
        private readonly ILogger<TranslationController> _logger;
        private readonly ITranslationService _translationService;
        
        public TranslationController(ILogger<TranslationController> logger, ITranslationService translationService)
        {
            _logger = logger;
            _translationService = translationService;
        }
        
        [HttpGet("{wordName}/{languageNameFrom}/{languageNameTo}")]
        [Description("Get specific translation")]
        public async Task<ActionResult<List<TranslationDto>>> GetTranslation(string wordName,
            string languageNameFrom, string languageNameTo)
        {
            var translationPair = await _translationService.GetTranslation(wordName, languageNameFrom, languageNameTo);

            if (translationPair.Any(t => t == null))
                return NotFound("Translation not found");
            
            return Ok(translationPair);
        }
    }
}
