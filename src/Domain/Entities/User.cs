using Domain.ValueObject;

namespace Domain.Entities
{
    public class UserEntity : BaseUserEntity
    {
        public Points Points { get; private set; } = new Points();

        public int? Ranking { get; private set; } = null;

        public int? FutCoins { get; private set; } = null;

        private UserEntity() { }

        public static UserEntity Create(UserName userName, Email email, string password)
        {
            var user = new UserEntity
            {
                UserName = userName,
                Email = email,
                Password = password
            };

            return user;
        }

        public static UserEntity Update(UserName userName, Email email, string password)
        {
            var user = new UserEntity
            {
                UserName = userName,
                Email = email,
                Password = password
            };

            return user;
        }
    }
}
