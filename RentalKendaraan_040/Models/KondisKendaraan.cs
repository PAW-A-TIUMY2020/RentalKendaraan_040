using System;
using System.Collections.Generic;

namespace RentalKendaraan_040.Models
{
    public partial class KondisKendaraan
    {
        public int IdKondisi { get; set; }
        public string NamaKondisi { get; set; }

        public Pengembalian Pengembalian { get; set; }
    }
}
