using Domain.ValueObject;

namespace Domain.Services.Interfaces;

public interface IBaseUserEntityService
{
    Task<bool> IsEmailUniqueAsync(Email email);
}
