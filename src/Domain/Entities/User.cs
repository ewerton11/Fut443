using Domain.Aggregates;
using Domain.Entities.Base;
using Domain.ValueObject;

namespace Domain.Entities
{
    public class UserEntity : BaseUserEntity
    {
        public UserName UserName { get; private set; }

        public Points Points { get; private set; } = new Points();

        public int? Ranking { get; private set; } = null;

        public int? FutCoins { get; private set; } = null;

        public Team? Team { get; private set; }

        public static UserEntity Create(string name, string userName, string email, string passwordHash)
        {
            var userNameResult = UserName.Create(userName);
            var emailResult = Email.Create(email);
            //var passwordResult = Password.Create(password);

            var user = new UserEntity
            {
                Name = name,
                UserName = userNameResult,
                Email = emailResult,
                PasswordHash = passwordHash
            };

            return user;
        }

        public static UserEntity Update(string name, string userName, string email, string passwordHash)
        {
            var userNameResult = UserName.Create(userName);
            var emailResult = Email.Create(email);
            //var passwordResult = Password.Create(password);

            var user = new UserEntity
            {
                Name = name,
                UserName = userNameResult,
                Email = emailResult,
                PasswordHash = passwordHash
            };

            return user;
        }
    }
}
