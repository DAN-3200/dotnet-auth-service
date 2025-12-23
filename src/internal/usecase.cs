using DTO;
using Entity;
using Ports;

namespace Usecase;

public class UserUsecase
{
   private IUserPorts repo;

   public UserUsecase(IUserPorts repo) =>
      this.repo = repo;


   public int SaveUser(RegisterDTO newUser) =>
      this.repo.SaveUser(newUser);


   public UserEntity GetUserInfo(int id) =>
      this.repo.GetUser(id);


   public void EditUser(EditDTO info) =>
      this.repo.EditUser(info);


   //  *role admin
   public void DeletUser(int id) =>
      this.repo.DeletUser(id);


   // ------------------------------

   public bool Login(LoginDTO login)
   {
      return true;
   }

   public bool Logout(int id)
   {
      return true;
   }
}