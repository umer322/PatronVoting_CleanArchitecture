#nullable disable
namespace Core.Entities.CharacterAggregate;

public class Vote : BaseEntity<Guid>
{
    public DateTimeOffset? Date { get; private set; }
    public Guid CharacterId { get; private set; }
    public Character Character { get; private set; }
    private Vote() { }

    public Vote(DateTime date, Guid characterId)
    {
        Date = date;
        CharacterId = characterId;
    }
}
