using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_040.Models
{
    public partial class Pengembalian
    {
        public int IdPengembalian { get; set; }
        [Required(ErrorMessage = "TglPengembalian tidak boleh kosong")]
        public DateTime? TglPengembalian { get; set; }
        public int? IdPeminjaman { get; set; }
        public int? IdKondisi { get; set; }
        [Required(ErrorMessage = "Denda tidak boleh kosong")]
        public int? Denda { get; set; }

        public Peminjaman IdPengembalian1 { get; set; }
        public KondisKendaraan IdPengembalianNavigation { get; set; }
    }
}
