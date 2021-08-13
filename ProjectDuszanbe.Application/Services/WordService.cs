using System.Threading.Tasks;
using AutoMapper;
using ProjectDuszanbe.Application.Interfaces;
using ProjectDuszanbe.Application.ViewModels;
using ProjectDuszanbe.Infrastructure;

namespace ProjectDuszanbe.Application.Services
{
    public class WordService : IWordService
    {
        private readonly IMapper _mapper;
        private readonly Context _context;

        public WordService(IMapper mapper, Context context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<WordDto> GetWordByName(string name)
        {
            return null;
        }

    }
}