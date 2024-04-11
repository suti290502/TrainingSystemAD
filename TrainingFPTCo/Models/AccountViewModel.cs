using System.ComponentModel.DataAnnotations;
using TrainingFPTCo.Validations;

namespace TrainingFPTCo.Models
{
    public class AccountViewModel
    {
        public List<AccountDetail> AccountDetailList { get; set; }

    }
    public class AccountDetail
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Choose Roles, please")]
        public int RoleId { get; set; }

        public string? ViewRoleName { get; set; }

        [Required(ErrorMessage = "Enter Username's, please")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Enter Password, please")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Enter ExtraCode, please")]
        public string ExtraCode { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Enter Address, please")]
        public string Address { get; set; }

        public string? FullName { get; set; }
        [Required(ErrorMessage = "Enter FirstName, please")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter LastName, please")]
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
      
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Enter Gender, please")]
        public string Gender { get; set; }
        public string? Education { get; set; }
        public string? ProgramLanguage { get; set; }
        public int? ToeicScore { get; set; }
        public string? Skill { get; set; }
        public string? IPClient { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
