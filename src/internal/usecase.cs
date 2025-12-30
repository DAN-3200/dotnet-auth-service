using System.Security.Cryptography;
using System.Threading.Tasks;
using DTO;
using Entity;
using Ports;
using User.Services;

namespace Usecase;

public class UserUsecase
{
   private readonly IUserPorts _repo;
   private readonly IPasswordHelper _passwordHelper;
   public UserUsecase(IUserPorts repo, IPasswordHelper passwordHelper) { this._repo = repo; this._passwordHelper = passwordHelper;}

   // ------------------------------

   public async Task SaveUser(RegisterDto newUser) {
      newUser.Password = _passwordHelper.HashPassword(newUser.Password);
      await this._repo.SaveUser(newUser);
   }
   public async Task<UserEntity> GetUserInfo(Guid id) =>
      await this._repo.GetUser(id);

   public async Task EditUser(Guid id, EditDto info) =>
      await this._repo.EditUser(id, info);

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