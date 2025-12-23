namespace Entity;

public class UserEntity
{
   private int? Id;
   private string Name;
   private string Email;
   private string Password;
   private Role Role;
   private DateTime CreatedAt;

   public UserEntity(string Name, string Email, string Password)
   {
      this.Name = Name;
      this.Email = Email;
      this.Password = Password;
   }
}

public enum Role
{
   Admin = 1,
   Normal = 2
}