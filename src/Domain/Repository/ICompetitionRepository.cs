using Domain.Aggregates;
using System.Threading.Tasks;

namespace Domain.Repository;

public interface ICompetitionRepository
{
    Task<Competition?> GetByIdAsync(Guid id);
    Task<IEnumerable<Competition>> GetAllAsync();
    Task AddAsync(Competition competition);
    Task UpdateAsync(object competition);
    Task DeleteAsync(Guid id);
}

