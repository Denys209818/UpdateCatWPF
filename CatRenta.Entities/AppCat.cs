using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatRenta.Entities
{
    [Table("tblAppCatsHW2")]
    public class AppCat
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string UrlImage { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
    }
}
