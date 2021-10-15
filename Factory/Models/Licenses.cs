using System.Collections.Generic;

namespace Factory.Models
{
  public class Licenses
  {
    public int LicensesId {get; set;}
    public int MachineId {get; set;}
    public int EngineerId {get; set;}
    public virtual Machine Machine {get; set;}
    public virtual Engineer Engineer {get; set;}
  }
}