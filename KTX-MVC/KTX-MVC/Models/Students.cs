using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTX_MVC.Models
{
    public class Students
    {
        [Key]
        [ForeignKey("StudentsId")]
        public String? Id { get; set; }
        public String? StudentName { get; set; }
        public DateTime? StudentDob { get; set; }
        public Boolean? StudentSex { get; set; }
        public String? StudentPhone { get; set; }
        public String? StudentEmail { get; set; }
        public String? StudentNote { get; set; }
        public String? StudentSpecialized { get; set; }

        public String? StudentMajors { get; set; }

        public String? StudentLink { get; set; }

        public int? StudentPrioritize { get; set; }

        public String? StudentPrioritizeImage { get; set; }

        public List<Parrents> ParrentsStudents { get; set; } = new List<Parrents>();
    }
   
}
