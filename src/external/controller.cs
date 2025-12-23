using Entity;
using Usecase;

namespace Controllers;

public class UserControllers
{
   private UserUsecase usecase;
   public UserControllers(UserUsecase usecase)
   {
      this.usecase = usecase;
   }

   public IResult SaveUser(UserEntity newUser)
   {
      var response = usecase.SaveUser(newUser);
      return Results.Ok(response);  
   }
}