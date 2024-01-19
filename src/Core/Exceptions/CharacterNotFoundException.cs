namespace Core.Exceptions
{
    public class CharacterNotFoundException : Exception
    {
        public CharacterNotFoundException(Guid CharacterId) : base($"No Character found with guid {CharacterId}") { }
    }
}
