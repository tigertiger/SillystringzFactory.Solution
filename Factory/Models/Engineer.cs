using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.JoinEntities = new HashSet<Licenses>();
    }
    public int EngineerId {get; set;}
    public string Name {get; set;}
    public virtual ICollection<Licenses> JoinEntities {get; set;}
  }
}