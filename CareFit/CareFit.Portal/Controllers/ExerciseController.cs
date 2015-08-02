using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareFit.Portal.Controllers
{
    public class ExerciseController : Controller
    {
        //
        // GET: /Excercise/

        public ActionResult Index()
        {
            var model = new Models.Exercise.IndexVM();
            var exercicioBll = new Domain.BLL.ExerciseBLL();
            model.ExerciseTypes = exercicioBll.GetExerciseTypes();
            model.MuscleGroups = exercicioBll.GetMuscleGroups();
            return View(model);
        }
        public ActionResult List(int? exerciseMuscleGroup, int? exerciseTypeId, string exerciseNome)
        {
            var model = new Models.Exercise.ListVM();
            var exerciseBll = new Domain.BLL.ExerciseBLL();
            var loggedUser = Session.GetLoggedUser();
            model.Exercises = exerciseBll.GetExercises(loggedUser.PessoaEmpresas, exerciseMuscleGroup, exerciseTypeId, exerciseNome);
            model.ExerciseTypes = exerciseBll.GetExerciseTypes();
            model.ExerciseMuscleGroups = exerciseBll.GetMuscleGroups();
            return View(model);
        }
        public ActionResult Edit(int exerciseId)
        {
            var model = new Models.Exercise.EditVM();
            var exerciseBll = new Domain.BLL.ExerciseBLL();
            var machineBll = new Domain.BLL.MachineBLL();
            var loggedUser = Session.GetLoggedUser();
            model.Customers = loggedUser.PessoaEmpresas.Select(pe => pe.Empresas).ToList();
            model.Exercise = exerciseBll.Get(exerciseId);
            model.ExerciseTypes = exerciseBll.GetExerciseTypes();
            model.ExerciseMuscleGroups = exerciseBll.GetMuscleGroups();
            if (model.Exercise == null)
            {
                model.Exercise = new Domain.Repository.Exercicios();
            }
            else
            {
                model.Exercise.ExercicioEquipamentos = exerciseBll.GetExerciseEquipamentos(exerciseId);
            }
            model.Machines = machineBll.GetMachines(loggedUser.PessoaEmpresas);

            model.MachineTypes = machineBll.GetMachineTypes();
            return View(model);

        }
        [HttpPost]
        public int Save(string jsonExercise)
        {
            var format = "dd/MM/yyyy"; // your datetime format
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var exercise = JsonConvert.DeserializeObject<Domain.Repository.Exercicios>(jsonExercise, dateTimeConverter);

            exercise = new Domain.BLL.ExerciseBLL().Save(exercise);
            return exercise.ID;
        }

        public ActionResult GetTypeAheadAjax(string search)
        {
            var exerciseBll = new Domain.BLL.ExerciseBLL();
            var loggedUser = Session.GetLoggedUser();
            var exercises = exerciseBll.GetExercisesByFilter(loggedUser.PessoaEmpresas, search);
            var response = exercises.Select(ex => new { 
                description = ex.Nome + " " + (ex.Equipamentos != null ? ex.Equipamentos.Nome : ""), 
                ID = ex.ID 
            }).ToList();
            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}
