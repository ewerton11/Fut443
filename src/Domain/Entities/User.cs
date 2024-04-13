using Domain.Aggregates;
using Domain.Entities.Base;
using Domain.ValueObject;

namespace Domain.Entities
{
    public class UserEntity : BaseUserEntity
    {
        public UserName UserName { get; private set; } = null!;

        public List<Team>? Teams { get; private set; }

        private UserEntity() { }

        public static UserEntity Create(UserName userName, Email email, string passwordHash)
        {
            var user = new UserEntity
            {
                FirstName = string.Empty,
                UserName = userName,
                Email = email,
                PasswordHash = passwordHash
            };

            return user;
        }

        public void UpdateName(string name)
        {
            FirstName = name;
        }

        public void UpdateUserName(UserName userName)
        {
            UserName = userName;
        }

        public void UpdateEmail(Email email)
        {
            Email = email;
        }

        public void UpdatePassword(string password)
        {
            PasswordHash = password;
        }
    }
}
