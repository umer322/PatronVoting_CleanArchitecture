namespace Web.ViewModel
{
    public class CharactersIndexViewModel
    {
        public List<CharacterViewModel> Characters { get; set; } = new List<CharacterViewModel>();
        public PaginationInfoViewModel? PagiantionInfo { get; set; }

    }
}
