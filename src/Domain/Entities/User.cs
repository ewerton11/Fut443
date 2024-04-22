using Domain.Aggregates;
using Domain.Entities.Base;
using Domain.ValueObject;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class UserEntity : BaseUserEntity
    {
        // INFORMAÇÕES PARA USUARIOS QUE FOR APOSTAR VALENDO DINHEIRO

        // INFORMAÇÕES PESSOAIS 1
        // Data de nascimento (ok)
        // Cpf

        // INFORMAÇÕES PESSOAIS
        // Nome completo (ok)
        // Pais (ok)
        // Numero de celular (ok)

        // LOGIN
        // Nome de usuario (ok)
        // Email (ok)
        // Senha (ok)
        // Confirmar que tem +18 e leu os termos
        public BirthDate Birthday { get; private set; } = null!;
        public string Phone { get; private set; } = null!;
        public string Country { get; private set; } = null!;
        public UserName UserName { get; private set; } = null!;
        public List<Team> Teams { get; private set; } = new List<Team>();

        private UserEntity() { }

        public static UserEntity Create(FirstName firstName, LastName lastName, BirthDate birthday, 
            UserName userName, Email email, string passwordHash)
        {
            var user = new UserEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Birthday = birthday,
                UserName = userName,
                Email = email,
                Phone = string.Empty,
                Country = string.Empty,
                PasswordHash = passwordHash
            };

            return user;
        }

        public bool IsAdult()
        {
            var today = DateTime.Today;
            var age = today.Year - Birthday.Value.Year;
            if (Birthday.Value.Date > today.AddYears(-age)) age--;

            return age >= 18;
        }

        public bool HasTeamForChampionship(Guid championshipId)
        {
            return Teams.Any(team => team.ChampionshipId == championshipId);
        }

        public Team? GetTeam(Guid teamId)
        {
            return Teams.FirstOrDefault(team => team.Id == teamId);
        }
    }
}
