namespace Core.Exceptions
{
    public class VoteNotFoundException : Exception
    {
        public VoteNotFoundException(Guid VoteId) : base($"No vote found with guid {VoteId}") { }
    }
}
