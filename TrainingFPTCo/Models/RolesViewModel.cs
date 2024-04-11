using System.ComponentModel.DataAnnotations;

namespace TrainingFPTCo.Models.Queries
{
    public class RolesViewModel
    {
        public List<RoleDetail> RoleDetailList { get; set; }
    }
    public class RoleDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name's Role, please")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Choose Status, please")]
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
