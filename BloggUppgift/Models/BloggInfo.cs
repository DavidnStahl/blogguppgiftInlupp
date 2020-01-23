using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace BloggUppgift.Models
{
    public partial class BloggInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori är obligatoriskt")]
        [Range(1, 3, ErrorMessage = "Kategori är obligatoriskt")]
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Rubrik måste vara minst 3 och max 50 tecken")]
        [Required(ErrorMessage = "Rubrik är obligatoriskt")]
        public string Heading { get; set; }

        [StringLength(2000, MinimumLength = 5, ErrorMessage = "Inlägg måste vara minst 5 och max 2000 tecken")]
        [Required(ErrorMessage = "Inlägg är obligatoriskt och får inte vara tom")]
        public string BloggInput { get; set; }

        public virtual BloggCategories Category { get; set; }
    }
}
