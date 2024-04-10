using Domain.Aggregates;
using Domain.Entities.Base;
using Domain.ValueObject;

namespace Domain.Entities
{
    public class UserEntity : BaseUserEntity
    {
        public UserName UserName { get; private set; }

        public Team? Team { get; private set; }

        private UserEntity() { }

        public static UserEntity Create(UserName userName, Email email, string passwordHash)
        {
            var user = new UserEntity
            {
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

        public static UserEntity UpdateTeam(Team team)
        {
            var userTeam = new UserEntity
            {
                Team = team
            };

            return userTeam;
        }
    }
}
