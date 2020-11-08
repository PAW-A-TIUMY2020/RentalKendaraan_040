using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_040.Models
{
    public partial class Gender
    {
        public int IdGender { get; set; }
        [Required(ErrorMessage = "Nama Gender tidak boleh kosong")]
        public string NamaGender { get; set; }

        public Customer Customer { get; set; }
    }
}
