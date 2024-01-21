using Web.ViewModel;

namespace Web.Inferfaces
{
    public interface ICharacterViewModelService
    {
        Task<CharactersIndexViewModel> GetCharacters(int pageIndex, int pageSize);
    }
}
