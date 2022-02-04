using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UTSAfida.Models
{
    public class Jadwal
    {
        public int Id { get; set; }
        public string pelatihan { get; set; }
        public DateTime TglMulai { get; set; }
        public DateTime TglSelesai { get; set; }
        public string pertemuan { get; set; }
        public string Tutor { get; set; }
        public string Keterangan { get; set; }
    }
}
