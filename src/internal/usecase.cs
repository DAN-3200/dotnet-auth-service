using DTO;
using Entity;
using Ports;

namespace Usecase;

public class UserUsecase
{
   private IUserPorts repo;

   public UserUsecase(IUserPorts repo)
   {
      this.repo = repo;
   }

   public int SaveUser(UserEntity newUser)
   {
      return this.repo.SaveUser(newUser);
   }

   public UserEntity GetUser(int id)
   {
      return this.repo.GetUser(id);
   }

   public void EditUser(int id)
   {
      this.repo.EditUser(id);
   }

   public void DeletUser(int id)
   {
      this.repo.DeletUser(id);
   }

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