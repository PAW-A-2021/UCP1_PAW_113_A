using System;
using System.Collections.Generic;

namespace UCP1_praktikum.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Penduduk = new HashSet<Penduduk>();
        }

        public int IdGender { get; set; }
        public string NamaGender { get; set; }

        public ICollection<Penduduk> Penduduk { get; set; }
    }
}
