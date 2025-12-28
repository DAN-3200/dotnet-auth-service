using System.Threading.Tasks;
using DTO;
using Entity;
using Ports;

namespace Usecase;

public class UserUsecase
{
   private readonly IUserPorts _repo;

   public UserUsecase(IUserPorts repo) => this._repo = repo;

   // ------------------------------

   public async Task SaveUser(RegisterDto newUser) =>
      await this._repo.SaveUser(newUser);

   public async Task<UserEntity> GetUserInfo(Guid id) =>
      await this._repo.GetUser(id);

   public async Task EditUser(EditDto info) =>
      await this._repo.EditUser(info);

   //  *role admin
   public async Task DeletUser(Guid id) =>
     await this._repo.DeletUser(id);

   public async Task DeactivateUser(Guid id) =>
      await this._repo.DeactivateUser(id);

   // ------------------------------

   public bool Login(LoginDto login)
   {
      return true;
   }

   public bool Logout(Guid id)
   {
      return true;
   }
}