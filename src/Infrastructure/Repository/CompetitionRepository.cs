using Domain.Aggregates;
using Domain.Repository;

namespace Infrastructure.Repository;

public class CompetitionRepository : ICompetitionRepository
{
    private readonly IBaseRepository<Competition> _baseRepository;

    public CompetitionRepository(IBaseRepository<Competition> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public async Task AddAsync(Competition competition)
    {
        await _baseRepository.CreateAsync(competition);
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Competition>> GetAllAsync()
    {
        var allCompetition = await _baseRepository.GetAllAsync();

        return allCompetition;
    }

    public async Task<Competition?> GetByIdAsync(Guid id)
    {
        var competition = await _baseRepository.GetByIdAsync(id);

        return competition;
    }

    public Task UpdateAsync(object competition)
    {
        throw new NotImplementedException();
    }
}
