using Entity;
using Microsoft.EntityFrameworkCore;

namespace ConnDB;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
  public DbSet<UserEntity> Users => Set<UserEntity>();
}