using Ardalis.Specification.EntityFrameworkCore;
using Core.Interfaces;

namespace Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IRepository<T>, IReadRepository<T> where T : class, IAggrerateRoot
{
    public EfRepository(AppDbContext dbContext) : base(dbContext) { }
}
