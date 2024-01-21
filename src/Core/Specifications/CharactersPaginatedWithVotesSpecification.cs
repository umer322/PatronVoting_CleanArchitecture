using Ardalis.Specification;
using Core.Entities.CharacterAggregate;

namespace Core.Specifications
{
    public class CharactersPaginatedWithVotesSpecification : Specification<Character>
    {
        public CharactersPaginatedWithVotesSpecification(int skip, int take)
        {
            Query.Include(c => c.Votes).Skip(skip).Take(take);
        }
    }
}
