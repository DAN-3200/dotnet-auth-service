using DTO;
using Entity;

namespace Ports;

public interface IUserPorts
{
   int SaveUser(RegisterDTO newUser);
   UserEntity GetUser(int id);
   void EditUser(EditDTO info);
   void DeletUser(int id);
} 