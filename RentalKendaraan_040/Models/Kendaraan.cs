using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_040.Models
{
    public partial class Kendaraan
    {
        public int IdKendaraan { get; set; }
        [Required(ErrorMessage = "Nama NamaKendaraan tidak boleh kosong")]
        public string NamaKendaraan { get; set; }
        [MinLength(1, ErrorMessage = "NOPolisi minimal 1 angka")]
        [MaxLength(4, ErrorMessage = "NOPolisi maksimal 4 angka")]
        public string NoPolisi { get; set; }
        [MinLength(1, ErrorMessage = "NoStnk minimal 1 angka")]
        [MaxLength(4, ErrorMessage = "NoStnk maksimal 4 angka")]
        public string NoStnk { get; set; }
        public int? IdJenisKendaraan { get; set; }
        [Required(ErrorMessage = "Ketersediaan tidak boleh kosong")]
        public string Ketersediaan { get; set; }

        public JenisKendaraan IdJenisKendaraanNavigation { get; set; }
        public Peminjaman Peminjaman { get; set; }
    }
}
