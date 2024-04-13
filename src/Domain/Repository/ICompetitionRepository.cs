using Domain.Aggregates;

namespace Domain.Repository;

public interface ICompetitionRepository
{
    Task AddCompetitionAsync(Competition competition);
    Task<Competition?> GetCompetitionByIdAsync(Guid id);
    //Task<IEnumerable<Competition>> GetAllAsync();
    //Task UpdateAsync(object competition);
    //Task DeleteAsync(Guid id);
}

