using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectDuszanbe.Application.Interfaces;
using ProjectDuszanbe.Application.ViewModels;
using ProjectDuszanbe.Domain.Model;
using ProjectDuszanbe.Infrastructure;

namespace ProjectDuszanbe.Application.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public LanguageService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LanguageDto>> GetAllLanguages()
        {
            var languages = await _context.Languages.ToListAsync();
            return _mapper.Map<List<Language>, List<LanguageDto>>(languages);
        }

        public async Task<LanguageDto> GetLanguage(string  shortcut)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(l => l.Shortcut == shortcut);
            return _mapper.Map<LanguageDto>(language);
        }
    }
}