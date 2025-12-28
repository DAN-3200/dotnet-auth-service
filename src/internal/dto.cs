namespace DTO;

public record LoginDto
{
   public required string Email { get; init; }
   public required string Password { get; init; }
};

public record RegisterDto
{
   public required string Name { get; init; }
   public required string Email { get; init; }
   public required string Password { get; init; }
};

public record EditDto
{
   public Guid Id { get; init; }
   public string? Name { get; init; }
   public string? Email { get; init; }
   public string? Password { get; init; }
};