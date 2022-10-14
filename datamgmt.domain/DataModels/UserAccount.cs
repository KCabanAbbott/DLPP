using System.ComponentModel.DataAnnotations;

namespace datamgmt.domain.DataModels.Admin
{
    public class UserAccount
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string? LoginName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Your email address is not in a valid format. Example of correct format: calvin.abbott@abbott.com")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public bool Active { get; set; }

        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

    }
}
