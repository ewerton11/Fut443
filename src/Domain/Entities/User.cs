using Domain.Aggregates;
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

        public static UserEntity Create(string userName, string email, string password)
        {
            var userNameResult = UserName.Create(userName);
            var emailResult = Email.Create(email);
            var passwordResult = Password.Create(password);

            var user = new UserEntity
            {
                UserName = userNameResult,
                Email = emailResult,
                Password = passwordResult
            };

            return user;
        }

        public static UserEntity Update(string userName, string email, string password)
        {
            var userNameResult = UserName.Create(userName);
            var emailResult = Email.Create(email);
            var passwordResult = Password.Create(password);

            var user = new UserEntity
            {
                UserName = userNameResult,
                Email = emailResult,
                Password = passwordResult
            };

            return user;
        }
    }
}
