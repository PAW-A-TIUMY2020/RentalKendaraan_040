using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_040.Models
{
    public partial class Peminjaman
    {
        public int IdPeminjamam { get; set; }
        [Required(ErrorMessage = "TglPeminjaman tidak boleh kosong")]
        public DateTime? TglPeminjaman { get; set; }
        public int? IdKendaraan { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdJaminan { get; set; }
        public int? Biaya { get; set; }

        public Jaminan IdCustomerNavigation { get; set; }
        public Kendaraan IdPeminjamam1 { get; set; }
        public Customer IdPeminjamamNavigation { get; set; }
        public Pengembalian Pengembalian { get; set; }
    }
}
