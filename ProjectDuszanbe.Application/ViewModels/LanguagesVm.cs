using System.Collections.Generic;

namespace ProjectDuszanbe.Application.ViewModels
{
    public class LanguagesVm
    {
        public ICollection<LanguageDto> Langugages { get; set; }
        public int Count { get; set; }
    }
}