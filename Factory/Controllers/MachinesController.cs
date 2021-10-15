using System;
using System.Linq;
using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Machine> sorted = _db.Machines.ToList().OrderBy(machine => machine.Model).ToList();
      return View(sorted);
    }

    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine, int EngineerId)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      if(EngineerId != 0)
      {
        _db.Licenses.Add(new Licenses() {EngineerId = EngineerId, MachineId = machine.MachineId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines
      .Include(machine => machine.JoinEntities)
      .ThenInclude(join => join.Engineer)
      .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }
  }
}