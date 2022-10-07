using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySDT
{
    public class PhoneBook
    {
        private string sdt;
        private string tentochuc;
        private string tennguoidaidien;
        private string Note;
        public string Sdt { get => sdt; set => sdt = value; }
        public string Tentochuc { get => tentochuc; set => tentochuc = value; }
        public string Tennguoidaidien { get => tennguoidaidien; set => tennguoidaidien = value; }
        public string Note1 { get => Note; set => Note = value; }
        public PhoneBook(string nbphone, string tentochuc, string tennguoidaidien, string note)
        {
            Sdt = nbphone;
            Tentochuc = tentochuc;
            Tennguoidaidien = tennguoidaidien;
            Note1 = note;
        }

       
    }
}
