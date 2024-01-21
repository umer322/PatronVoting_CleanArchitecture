using Core.Entities.CharacterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    internal class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasMany<Vote>(c => c.Votes).WithOne(v => v.Character).HasForeignKey(v => v.CharacterId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(b => b.Name).IsRequired();
        }
    }
}
