using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<Licenses>();
    }
    public int MachineId {get; set;}
    public string Model {get; set;}
    public int Year {get; set;}
    public int Condition {get; set;}
    public virtual ICollection<Licenses> JoinEntities {get; set;}
  }
}