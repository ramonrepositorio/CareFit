using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Trainig
{
    public class PeoplesListVM
    {
        public List<Domain.Repository.Pessoas> Peoples { get; set; }
        public List<Domain.Repository.Pessoas> Professors { get; set; }
        public string GetProfessorName(long professorId)
        {
            var professor = Professors.Where(p => p.ID == professorId).FirstOrDefault();
            return professor.Nome + "" + professor.Sobrenome;
        }
    }
}