using System;
using System.Collections.Generic;

namespace RentalKendaraan_040.Models
{
    public partial class Pengembalian
    {
        public int IdPengembalian { get; set; }
        public DateTime? TglPengembalian { get; set; }
        public int? IdPeminjaman { get; set; }
        public int? IdKondisi { get; set; }
        public int? Denda { get; set; }

        public Peminjaman IdPengembalian1 { get; set; }
        public KondisKendaraan IdPengembalianNavigation { get; set; }
    }
}
