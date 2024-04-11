using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TrainingFPTCo.DBContext
{
    public class AccountDBContext
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CategoryId"), Required]
        public required RolesDBContext roles { get; set; }
        public required int RoleId { get; set; }

        [Column("UserName", TypeName = "Varchar(50)"), AllowNull]
        public required string UserName { get; set; }
        [Column("Password", TypeName = "Varchar(150)"), AllowNull]
        public required string Password { get; set; }

        [Column("ExtraCode", TypeName = "Varchar(200)"), Required]
        public required string ExtraCode { get; set; }

        [Column("Email", TypeName = "Varchar(50)"), AllowNull]
        public required string Email { get; set; }
        [Column("Phone", TypeName = "Varchar(50)"), AllowNull]
        public required string Phone { get; set; }

        [Column("Address", TypeName = "Varchar(250)"), Required]
        public required string Address { get; set; }
        [Column("FullName", TypeName = "Varchar(50)"), AllowNull]
        public required string FullName { get; set; }
        [Column("FirstName", TypeName = "Varchar(50)"), Required]
        public required string FirstName { get; set; }
        [Column("LastName", TypeName = "Varchar(50)"), Required]
        public required string LastName { get; set; }

        [AllowNull]
        public DateTime? CreatedAt { get; set; }
        [AllowNull]
        public DateTime? UpdatedAt { get; set; }
        [AllowNull]
        public DateTime? DeletedAt { get; set; }
    }
}
