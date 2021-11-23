using System;
using System.Collections.Generic;

namespace UCP1_praktikum.Models
{
    public partial class Penduduk
    {
        public int IdData { get; set; }
        public string Nama { get; set; }
        public string NamaDusun { get; set; }
        public int? NoKk { get; set; }
        public string Alamat { get; set; }
        public int? IdGender { get; set; }
        public int? IdStatus { get; set; }

        public Gender IdGenderNavigation { get; set; }
        public Status IdStatusNavigation { get; set; }
    }
}
