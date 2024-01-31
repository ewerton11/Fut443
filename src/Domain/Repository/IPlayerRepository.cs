namespace Domain.Repository;

public interface IPlayerRepository<TPlayer>
{
    Task CreateAsync(TPlayer player);
}
