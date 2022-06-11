using AutoMapper;
using BookMyShowTask.Models;
using Microsoft.EntityFrameworkCore;
namespace BookMyShowTask.Services
{
    public class UserService : IUserService
    {
        private readonly BookMyShowContext Context;
        public IMapper Mapper;
        public UserService(BookMyShowContext context, IMapper mapper)
        {
            Mapper = mapper;
            Context = context;
        }
        public UserDetail AddUser(UserDetail user)
        {
            if (user != null)
            {
                Context.UserDetail.Add(user);
                Context.SaveChanges();
                return Mapper.Map<UserDetail>(user);
            }
            return null;
        }

        //public UserDetail DeleteUser(int id)
        //{
        //    var user = Context.UserDetail.FirstOrDefault(x => x.Id == id);
        //    Context.Entry(user).State = EntityState.Deleted;
        //    Context.SaveChanges();
        //    return Mapper.Map<UserDetail>(user);
        //}

        //public UserDetail GetUser(int id)
        //{
        //    var user = Context.UserDetail.FirstOrDefault(x => x.Id == id);
        //    return Mapper.Map<UserDetail>(user);
        //}

        public IEnumerable<UserDetail> GetUserDetails()
        {
            var user = Context.UserDetail.ToList();
            return Mapper.Map<IEnumerable<UserDetail>>(user);
        }

    }
}
