/*
using Domain.Aggregates;
using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases;

public class CreateTeamUseCase
{
    private readonly IBaseRepository<UserEntity> _baseUserRepository;
    private readonly IBaseRepository<Team> _baseTeamRepository;

    public CreateTeamUseCase(IBaseRepository<UserEntity> baseUserRepository, IBaseRepository<Team> baseTeamRepository)
    {
        _baseUserRepository = baseUserRepository;
        _baseTeamRepository = baseTeamRepository;
    }

    public async Task CreateTeam(string name, Guid userId)
    {
        var user = await _baseUserRepository.GetByIdAsync(userId);

        if(user == null)
            throw new Exception("Usuário não encontrado.");

        var newteam = Team.Create(name, userId);

        UserEntity.UpdateTeam(newteam);

        await _baseTeamRepository.CreateAsync(newteam);
        await _baseUserRepository.UpdateAsync(user);
    }
}
*/