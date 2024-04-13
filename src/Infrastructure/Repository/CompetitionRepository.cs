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

    public async Task AddCompetitionAsync(Competition competition)
    {
        await _baseRepository.CreateAsync(competition);
    }

    public async Task<Competition?> GetCompetitionByIdAsync(Guid id)
    {
        var competition = await _baseRepository.GetByIdAsync(id);

        return competition;
    }

    /*
    public async Task<IEnumerable<Competition>> GetAllAsync()
    {
        var allCompetition = await _baseRepository.GetAllAsync();

        return allCompetition;
    }

    public Task UpdateAsync(object competition)
    {
        throw new NotImplementedException();
    }
    
    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    */
}