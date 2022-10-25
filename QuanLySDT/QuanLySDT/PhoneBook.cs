using System;
using System.Collections.Generic;
using System.Data;
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
        private string binhluan;
        public string Sdt { get => sdt; set => sdt = value; }
        public string Tentochuc { get => tentochuc; set => tentochuc = value; }
        public string Tennguoidaidien { get => tennguoidaidien; set => tennguoidaidien = value; }
        public string Binhluan { get => binhluan; set => binhluan = value; }

        public PhoneBook(string nbphone, string tentochuc, string tennguoidaidien, string note)
        {
            Sdt = nbphone;
            Tentochuc = tentochuc;
            Tennguoidaidien = tennguoidaidien;
            binhluan = note;
        }
        public PhoneBook(DataRow row)
        {
            sdt = row["Sdt"].ToString();
            tennguoidaidien = row["Tennguoidaidien"].ToString();
            tentochuc = row["Tentochuc"].ToString();
            binhluan = row["Binhluan"].ToString();
        }
       
    }
}
