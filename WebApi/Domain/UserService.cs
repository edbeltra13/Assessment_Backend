using Microsoft.EntityFrameworkCore;
using WebApi.Contracts;
using WebApi.Model;

namespace WebApi.Domain
{
    public class UserService : IUsers
    {
        private readonly List<User> _users = new List<User>();
        private readonly WebApiDbContext _webApiDbContext;


        public UserService(WebApiDbContext context)
        {
            _webApiDbContext = context;
        }
        public List<User> GetAllUsers()
        {
            return _webApiDbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _webApiDbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            if (_webApiDbContext.Users.Any(u => u.Id == user.Id))
            {
                throw new System.Exception("A user with this ID already exists.");
            }
            _webApiDbContext.Users.Add(user);
            _webApiDbContext.SaveChanges();


        }

        public void UpdateUser(int id, User updatedUser)
        {
            var user = _webApiDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new System.Exception($"User with ID {id} not found.");
            }

            user.Username = updatedUser.Username;
            user.Mail = updatedUser.Mail;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.Skillsets = updatedUser.Skillsets;
            user.Hobby = updatedUser.Hobby;
            _webApiDbContext.SaveChanges(); // Commit changes to the database
        }

        public void DeleteUser(int id)
        {
            var user = _webApiDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new System.Exception($"User with ID {id} not found.");
            }

            _webApiDbContext.Users.Remove(user); // Remove the user from the database
            _webApiDbContext.SaveChanges();      // Commit changes to the database
        }
    }
}

