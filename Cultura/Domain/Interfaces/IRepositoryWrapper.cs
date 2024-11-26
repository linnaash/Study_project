using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository Employee { get; }
        Task Save();
    }
}
