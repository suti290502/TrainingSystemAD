using System.ComponentModel.DataAnnotations;
using TrainingFPTCo.Validations;

namespace TrainingFPTCo.Models
{
    public class TopicViewModel
    {
        public List<TopicDetail> TopicDetailsList { get; set; }
    }
    public class TopicDetail
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Choose Course, please")]
        public int CourseId { get; set; }

        public string? ViewCourseName { get; set; }

        [Required(ErrorMessage = "Enter name's Topic, please")]
        public string Name { get; set; }

        public string? Description { get; set; }
        [Required(ErrorMessage = "Choose document file, please")]
        [AllowExtensionFile(new string[] { ".pdf", ".doc", ".docx" })]
        [AllowSizeFile(5 * 1024 * 1024)]
        public IFormFile Document { get; set; }

        public string? ViewDocumentTopic { get; set; }

        public IFormFile? AttachFile { get; set;}
        public string? ViewAttachFileTopic { get; set; }
        public string? TypeDocument { get; set; }

        [Required(ErrorMessage = "Choose file image, please")]
        [AllowExtensionFile(new string[] { ".png", ".jpg", ".jpeg" })]
        [AllowSizeFile(5 * 1024 * 1024)]
        public IFormFile PosterTopic { get; set; }

        public string? ViewPosterTopic { get; set; }

        [Required(ErrorMessage = "Choose Status, please")]
        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
