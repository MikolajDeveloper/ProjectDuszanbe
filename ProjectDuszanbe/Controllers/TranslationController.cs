using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectDuszanbe.Domain.Model;

namespace ProjectDuszanbe.Controllers
{
    public class TranslationController
    {
        private readonly ILogger<LanguagesController> _logger;

        public TranslationController(ILogger<LanguagesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Translation> GetAllTranslations(string fromLanguage, string toLanguage)
        {
            return null;
        }
    }
}