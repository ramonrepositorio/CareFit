using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareFit.Portal.Controllers
{
[Authorize]
    public class MachineController : Controller
    {
        //
        // GET: /Machine/

        public ActionResult Index()
        {
            var model = new Models.Machine.IndexVM();
            var loggedUser = Session.GetLoggedUser();
            var machineBll = new Domain.BLL.MachineBLL();
            model.MachineTypes = machineBll.GetMachineTypes();
            return View(model);
        }
        public JsonResult GetMachines(string filterName)
        {
            var machineBll = new Domain.BLL.MachineBLL();
            var loggedUser = Session.GetLoggedUser();
            var machines = machineBll.GetMachines(loggedUser.PessoaEmpresas, filterName);
            return Json(machines.Select(m => new { ID = m.ID, Name = m.Nome }).ToList(), JsonRequestBehavior.AllowGet);
            
        }
        public ActionResult List(int? roomId, int? machineTypeId, string machineName)
        {
            var model = new Models.Machine.ListVM();
            var machineBll = new Domain.BLL.MachineBLL();
            var loggedUser = Session.GetLoggedUser();
            model.Machines = machineBll.GetMachines(loggedUser.PessoaEmpresas, roomId, machineTypeId, machineName);
            model.MachineTypes = machineBll.GetMachineTypes();
            return View(model);
        }

        public ActionResult Edit(int machineId)
        {
            var model = new Models.Machine.EditVM();
            var machineBll = new Domain.BLL.MachineBLL();
            model.MachineTypes = machineBll.GetMachineTypes();
            var loggedUser = Session.GetLoggedUser();
            model.Rooms = new Domain.BLL.RoomBLL().GetRooms(loggedUser.PessoaEmpresas);
            model.Customers = loggedUser.PessoaEmpresas.Select(pe => pe.Empresas).ToList();
            model.Machine = machineBll.Get(machineId);
            if (model.Machine == null)
            {
                model.Machine = new Domain.Repository.Equipamentos();
            }
            return View(model);
        }
        [HttpPost]
        public long Save(string jsonMachine)
        {
            var format = "dd/MM/yyyy"; // your datetime format
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var machine = JsonConvert.DeserializeObject<Domain.Repository.Equipamentos>(jsonMachine, dateTimeConverter);

            machine = new Domain.BLL.EquipamentoBLL().Save(machine);
            return machine.ID;
        }
    }
}
