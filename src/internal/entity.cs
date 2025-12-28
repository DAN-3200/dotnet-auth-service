namespace Entity;

public class UserEntity
{
   public Guid Id { get; private set; }
   public required string Name { get; set; }
   public required string Email { get; set; }
   public required string Password { get; set; }
   public Role Role { get; set; }
   public bool IsActive { get; set; }
   public DateTime CreatedAt { get; set; }


   private UserEntity()
   {
   } // *só por causa do Entity Framework

   public UserEntity(string Name, string Email, string PasswordHash)
   {
      this.Id = Guid.NewGuid();
      this.Name = Name;
      this.Email = Email;
      this.Password = PasswordHash;
      this.Role = Role.Normal;
      this.IsActive = true;
      this.CreatedAt = DateTime.UtcNow;
   }
}

public enum Role
{
   Normal = 1,
   Admin = 2,

}