using WebApi.Model;

namespace WebApi.Contracts
{
    public interface IUsers
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(int id, User user);
        void DeleteUser(int id);
    }
}
