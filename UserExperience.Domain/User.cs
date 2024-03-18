using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserExperience.Domain
{
    public class User
    {
        public int Id { get; set; }



        public string UserName { get; set; }

        public string Email { get; set; }

        public string Web { get; set; }

        public string Direccion { get; set; }

        public ICollection<Workingexperience> Workingexperiences { get; set; } // <- this line
    }
}
