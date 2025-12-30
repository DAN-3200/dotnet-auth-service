using ConnDB;
using DTO;
using Entity;
using Ports;

namespace repository;

public class UserRepository : IUserPorts
{
   private readonly UserDbContext _db;

   public UserRepository(UserDbContext context)
   {
      this._db = context;
   }

   public async Task SaveUser(RegisterDto newUser)
   {
      var userMold = new UserEntity(
         newUser.Name,
         newUser.Email,
         newUser.Password
      );

      await _db.Users.AddAsync(userMold);
      await _db.SaveChangesAsync();
   }

   public async Task<UserEntity> GetUser(Guid id)
   {
      var response = await _db.Users.FindAsync(id);
      return response!;
   }

   public async Task EditUser(Guid id ,EditDto info)
   {
      var user = await _db.Users.FindAsync(id);

      if (info.Name is not null)
      {
         user!.Name = info.Name;
      }

      if (info.Email is not null)
      {
         user!.Email = info.Email;
      }

      // *bcrypt
      if (info.Password is not null)
      {
         user!.Password = info.Password;
      }

      _db.Users.Update(user!);
      await _db.SaveChangesAsync();
   }

   public async Task DeactivateUser(Guid id)
   {
      var user = await _db.Users.FindAsync(id);
      user!.IsActive = false;
      _db.Users.Update(user);
      await _db.SaveChangesAsync();
   }

   public async Task DeletUser(Guid id)
   {
      var user = await _db.Users.FindAsync(id);
      _db.Users.Remove(user!);
      await _db.SaveChangesAsync();
   }
}