using Microsoft.AspNetCore.Mvc.RazorPages;
using Web;
using Web.Inferfaces;
using Web.Services;
using Web.ViewModel;

namespace PatronVoting.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICharacterViewModelService _charactersViewModelService;

        public IndexModel(ILogger<IndexModel> logger, CharactersViewModelService viewModelService)
        {
            _logger = logger;
            _charactersViewModelService = viewModelService;
        }
        public CharactersIndexViewModel CharactersModel { get; set; } = new CharactersIndexViewModel();
        public async Task OnGet(int? pageIndex)
        {

            CharactersModel = await _charactersViewModelService.GetCharacters(pageIndex ?? 0, Constants.ITEMS_PER_PAGE);
        }
    }
}
