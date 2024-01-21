using Core.Entities.CharacterAggregate;
using Core.Interfaces;
using Core.Specifications;
using Web.Inferfaces;
using Web.ViewModel;

namespace Web.Services
{
    public class CharactersViewModelService : ICharacterViewModelService
    {
        private readonly IRepository<Character> _characterRepository;
        public CharactersViewModelService(IRepository<Character> characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<CharactersIndexViewModel> GetCharacters(int pageIndex, int itemPage)
        {
            var CharacterWithVotesSpec = new CharactersPaginatedWithVotesSpecification(pageIndex * itemPage, itemPage);
            var totalCharacters = await _characterRepository.CountAsync();

            var charactersList = await _characterRepository.ListAsync(CharacterWithVotesSpec);

            var vm = new CharactersIndexViewModel
            {
                Characters = charactersList.Select(c =>
                new CharacterViewModel { Id = c.Id, Name = c.Name, Description = c.Description, Picture = c.Picture, VotesCount = c.Votes.Count() }).ToList(),
                PagiantionInfo = new PaginationInfoViewModel
                {
                    ActualPage = pageIndex,
                    TotalItems = totalCharacters,
                    TotalPages = int.Parse(Math.Ceiling((decimal)totalCharacters / itemPage).ToString()),
                    ItemsPerPage = itemPage,

                }
            };

            vm.PagiantionInfo.Next = (vm.PagiantionInfo.ActualPage == vm.PagiantionInfo.TotalPages) ? "is-disabled" : "";
            vm.PagiantionInfo.Previous = (vm.PagiantionInfo.ActualPage == 0) ? "is-disabled" : "";
            return vm;
        }

    }
}
