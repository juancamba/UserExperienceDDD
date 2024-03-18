using System.ComponentModel.DataAnnotations;

namespace UserExperience.Domain
{
    public class Workingexperience
    {
        public int Id { get; set; }

        public int UserId { get; set; } //<------ this line
        public virtual User User { get; set; }


        public string Name { get; set; }

        public string Details { get; set; }

        public string Environment { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
