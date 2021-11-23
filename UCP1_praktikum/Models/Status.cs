using System;
using System.Collections.Generic;

namespace UCP1_praktikum.Models
{
    public partial class Status
    {
        public Status()
        {
            Penduduk = new HashSet<Penduduk>();
        }

        public int IdStatus { get; set; }
        public string Status1 { get; set; }

        public ICollection<Penduduk> Penduduk { get; set; }
    }
}
