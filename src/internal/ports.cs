using Entity;

namespace Ports;

public interface IUserPorts
{
   int SaveUser(UserEntity newUser);
   UserEntity GetUser(int id);
   void EditUser(int id);
   void DeletUser(int id);
} 