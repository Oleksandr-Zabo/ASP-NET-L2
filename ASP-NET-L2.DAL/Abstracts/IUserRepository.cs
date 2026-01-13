

using ASP_NET_L2.DAL.Entities;

namespace ASP_NET_L2.DAL.Abstracts
{
    public interface IUserRepository
    {
        User GetUser(int id);
        void AddUser(User user);
    }
}
