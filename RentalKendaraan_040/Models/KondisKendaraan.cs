using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_040.Models
{
    public partial class KondisKendaraan
    {
        public int IdKondisi { get; set; }
        [Required(ErrorMessage = "NamaKondisi tidak boleh kosong")]
        public string NamaKondisi { get; set; }

        public Pengembalian Pengembalian { get; set; }
    }
}
