using SITE.Models;

namespace SITE.Repositories;

public sealed class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new();
    private readonly object _sync = new();
    private int _nextId = 1;

    public Task<IReadOnlyList<User>> GetAllAsync() => Task.FromResult<IReadOnlyList<User>>(_users.ToList());
    public Task<User?> GetByIdAsync(int id) => Task.FromResult(_users.FirstOrDefault(x => x.Id == id));

    public Task<User> AddAsync(User entity)
    {
        lock (_sync) { entity.Id = _nextId++; _users.Add(entity); }
        return Task.FromResult(entity);
    }

    public Task<bool> UpdateAsync(User entity)
    {
        lock (_sync)
        {
            var existing = _users.FirstOrDefault(x => x.Id == entity.Id);
            if (existing is null) return Task.FromResult(false);
            existing.Name = entity.Name; existing.Email = entity.Email;
            return Task.FromResult(true);
        }
    }

    public Task<bool> DeleteAsync(int id)
    {
        lock (_sync)
        {
            var existing = _users.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(existing is not null && _users.Remove(existing));
        }
    }
}
