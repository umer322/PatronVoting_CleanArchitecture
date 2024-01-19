namespace Core.Entities
{
    public class Character : BaseEntity<Guid>
    {
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public string Image { get; private set; } = default!;

        public ICollection<Vote>? Votes { get; private set; }

        private Character()
        {
        }

        public Character(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }
    }
}
