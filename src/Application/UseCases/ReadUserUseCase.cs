using Domain.Entities;
using Domain.Repository;
using System.Text.Json.Serialization;
using System.Text.Json;

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
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true // Opcional: para tornar a saída JSON mais legível
        };

        var jsonString = JsonSerializer.Serialize(user, options);
        return jsonString;
    }
}
