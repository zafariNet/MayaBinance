using MayaBinance.DataAccess.Infrastructures;
using MayaBinance.Domain.Identity.Users;
using MayaBinance.Domain.SeedWork;

namespace MayaBinance.DataAccess.Repositories.Identity.Interfaces
{
    public interface IUserRepository: IRepositoryAsync<User>
    {

    }
}
