using Diagraph.Infrastructure;
using Diagraph.Infrastructure.Database;

namespace Diagraph.Modules.GlucoseData.Imports;

public class Import : DbEntity, IUserRelated
{
    public int Id { get; set; }
    
    public string Hash { get; set; }
    
    public ICollection<GlucoseMeasurement> Measurements { get; set; }
    
    public Guid UserId { get; set; }
}