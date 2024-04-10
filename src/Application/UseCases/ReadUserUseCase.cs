/*
using Domain.Repository;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.UseCases;

public class ReadUserUseCase
{
    private readonly IUserRepository _userRepository;

    public ReadUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string?> ReadUserAndTeam(Guid id)
    {
        var user = await _userRepository.GetUserByIdAndTeam(id);

        if (user == null) return null;

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        var jsonString = JsonSerializer.Serialize(user, options);
        return jsonString;
    }
}
*/