using System.ComponentModel.DataAnnotations;

namespace Entity;

public class UserEntity
{
   [Key]
   public Guid Id { get; private set; }
   public string? Name { get; set; }
   public string? Email { get; set; }
   public string? Password { get; set; }
   public Role Role { get; set; }
   public bool IsActive { get; set; }
   public DateTime CreatedAt { get; set; }


   private UserEntity()
   {
   }

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