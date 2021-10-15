using System;
using System.Linq;
using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Engineer> sorted = _db.Engineers.ToList().OrderBy(engineer => engineer.Name).ToList();
      return View(sorted);
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Model");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer, int MachineId)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      if(MachineId !=0)
      {
        _db.Licenses.Add(new Licenses() {MachineId = MachineId, EngineerId = engineer.EngineerId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
        .Include(engineer => engineer.JoinEntities)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Model");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.Licenses.Add(new Licenses() {MachineId = MachineId, EngineerId = engineer.EngineerId});
      }
        _db.Entry(engineer).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Details", new {id = engineer.EngineerId});
    }

    public ActionResult AddMachine(int id)
    {
      var thisEngineer = _db.Engineers
      .Include(engineer => engineer.JoinEntities)
      .ThenInclude(join => join.Machine)
      .FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineModel");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int MachineId, Machine machine, int EngineerId)
    {
      if (MachineId != 0 && !_db.Licenses.Any(model => model.MachineId == machine.MachineId && model.EngineerId == EngineerId))
      {
        _db.Licenses.Add(new Licenses() {MachineId = MachineId, EngineerId = engineer.EngineerId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
      }

      public ActionResult Delete(int id)
      {
        Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
        return View(thisEngineer);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult Destroy(int id)
      {
        Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
        _db.Engineers.Remove(thisEngineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
  }
}