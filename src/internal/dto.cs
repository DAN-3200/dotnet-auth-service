namespace DTO;

public record LoginDTO
{
   public string? Username { get; init; }
   public string? Password { get; init; }
};

public record RegisterDTO
{
   public string? Username { get; init; }
   public string? Email { get; init; }
   public string? Password { get; init; }
};

   
public record EditDTO
{
   public int Id {get; set;}
   public string? Username { get; set; }
   public string? Email { get; set; }
   public string? Password { get; set; }
};