using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySDT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        #region Method
        void createdatagrid()
        {
            var coltendaidien = new DataGridViewTextBoxColumn();
            var colsdt = new DataGridViewTextBoxColumn();
            var coltencoquan = new DataGridViewTextBoxColumn();
            var colnote = new DataGridViewTextBoxColumn();
            colnote.HeaderText = "Ghi Chú";
            colsdt.HeaderText = "Số Điện Thoại";
            coltencoquan.HeaderText = "Tên cơ quan";
            coltendaidien.HeaderText = "Người đại diện";
            colsdt.DataPropertyName = "Sdt";
            coltencoquan.DataPropertyName = "Tentochuc";
            coltendaidien.DataPropertyName = "Tennguoidaidien";
            colnote.DataPropertyName = "Ghi chú";
            colsdt.Width = 140;
            coltencoquan.Width = coltendaidien.Width = 140;
            colnote.Width =130;
            
            dataGList.Columns.AddRange(new DataGridViewColumn[] { colsdt, coltencoquan, coltendaidien, colnote });
        }
        void LoadListFormNb()
        {
            dataGList.DataSource = ListPhoneBook.Intance.ListNbphone;
        }
        #endregion
        #region Event
        private void Form1_Load(object sender, EventArgs e)
        {
            createdatagrid();
            LoadListFormNb();
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
