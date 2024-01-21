using Ardalis.GuardClauses;
using Core.Interfaces;

namespace Core.Entities.CharacterAggregate;

public class Character : BaseEntity<Guid>, IAggrerateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Picture { get; private set; }

    private readonly List<Vote> _votes = new List<Vote>();

    public IReadOnlyList<Vote> Votes => _votes.AsReadOnly();

    public Character(string name, string description, string picture)
    {
        Name = name;
        Description = description;
        Picture = picture;
    }
    public void AddVote(Vote vote)
    {
        Guard.Against.Null(vote);
        _votes.Add(vote);
    }
    public void RemoveVote(Guid VoteId)
    {
        Guard.Against.NullOrEmpty(VoteId);
        var vote = _votes.Find(v => v.Id == VoteId);
        Guard.Against.Null(vote);
        _votes.Remove(vote);
    }
}
