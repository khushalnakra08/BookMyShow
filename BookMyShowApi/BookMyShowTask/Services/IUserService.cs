using BookMyShowTask.Models;
namespace BookMyShowTask.Services
{
    public interface IUserService
    {
        IEnumerable<UserDetail> GetUserDetails();
        //UserDetail GetUser(int id);
        UserDetail AddUser(UserDetail user);
        //UserDetail UpdateUser(int id, UserDetail user);
        //UserDetail DeleteUser(int id);
    }
}
