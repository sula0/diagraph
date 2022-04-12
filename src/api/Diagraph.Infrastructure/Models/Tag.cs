using Diagraph.Core.Database;

namespace Diagraph.Infrastructure.Models;

public class Tag : DbEntity, IUserRelated
{
    public int Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public string Name { get; set; }

}