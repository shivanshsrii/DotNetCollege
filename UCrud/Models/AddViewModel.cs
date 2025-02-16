using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UCrud.Models
{
    public class AddViewModel
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Phone { get; set; }
        [Required]
        public String Course { get; set; }
        [Required]
        // ✅ Store the saved image file path
        public string ImagePath { get; set; }

        // ✅ File upload - not stored in DB
        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }

        // Store total marks for each semester
        public int Semester1 { get; set; }
        public int Semester2 { get; set; }
        public int Semester3 { get; set; }
        public int Semester4 { get; set; }
        public int Semester5 { get; set; }
        public int Semester6 { get; set; }
        public int Semester7 { get; set; }
        public int Semester8 { get; set; }

        // Calculated properties
        [NotMapped]
        public int TotalMarksObtained =>
            Semester1 + Semester2 + Semester3 + Semester4 +
            Semester5 + Semester6 + Semester7 + Semester8;

        [NotMapped]
        public int TotalMaximumMarks => 8 * 500; // 8 semesters * 500 max marks per semester

        [NotMapped]
        public double Percentage => (double)TotalMarksObtained / TotalMaximumMarks * 100;
    }
}
