using DTO;
using Entity;

namespace Ports;

public interface IUserPorts
{
   Task SaveUser(RegisterDto newUser);
   Task<UserEntity> GetUser(Guid id);
   Task EditUser(EditDto info);
   Task DeactivateUser(Guid id);
   Task DeletUser(Guid id);
} 