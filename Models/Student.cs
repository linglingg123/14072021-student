namespace WebApplication8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public int studentId { get; set; }

        [Required]
        [StringLength(100)]
        public string studentName { get; set; }

        public DateTime studentDOB { get; set; }

        [Required]
        [StringLength(200)]
        public string studentAdress { get; set; }

        public int? studentPicId { get; set; }

        [Column(TypeName = "image")]
        public byte[] studentPic { get; set; }
    }
}
