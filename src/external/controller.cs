using DTO;
using Usecase;

namespace Controllers;

public class UserControllers
{
   private readonly UserUsecase _usecase;
   public UserControllers(UserUsecase usecase)
   {
      this._usecase = usecase;
   }

   public async Task<IResult> SaveUser(RegisterDto newUser)
   {
      await _usecase.SaveUser(newUser);
      return Results.Ok();
   }
   public async Task<IResult> GetUserInfo(Guid id)
   {
      var response = await _usecase.GetUserInfo(id);
      return Results.Ok(response);
   }
}