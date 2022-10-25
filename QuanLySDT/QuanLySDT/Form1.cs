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
        string status = "";
        int index = -1;
        int indexSearch = -1;
        DataTable datableWrite = new DataTable();
        DataSet datasetWrite = new DataSet();
        DataTable datableRead = new DataTable();
        DataSet datasetRead = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }
        DataTable CreateDatable()
        {
            DataTable datable = new DataTable();
            DataColumn colSDT = new DataColumn("Sdt");
            DataColumn colTentochuc = new DataColumn("Tentochuc");
            DataColumn colTendaidien = new DataColumn("Tennguoidaidien");
            DataColumn colghichu = new DataColumn("Binhluan");
            datable.Columns.Add(colSDT);
            datable.Columns.Add(colTentochuc);
            datable.Columns.Add(colTendaidien);
            datable.Columns.Add(colghichu);
            return datable;
        }
        void writeXML()
        {
            datableWrite = CreateDatable();
            foreach(var item in ListPhoneBook.Intance.ListNbphone)
            {
                datableWrite.Rows.Add(item.Sdt, item.Tentochuc, item.Tennguoidaidien, item.Binhluan);
            }
            datasetWrite.Tables.Add(datableWrite);
            datasetWrite.WriteXml("data.xml");
        }
        void readXML()
        {
            datasetRead.ReadXml("data.xml");
            datableRead = datasetRead.Tables[0];
            foreach (DataRow item in datableRead.Rows)
            {
                PhoneBook newphonBook = new PhoneBook(item);
                ListPhoneBook.Intance.ListNbphone.Add(newphonBook);

            }
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
            colnote.DataPropertyName = "Binhluan";
            colsdt.Width = 140;
            coltencoquan.Width = coltendaidien.Width = 140;
            colnote.Width =130;
            dataGList.Columns.AddRange(new DataGridViewColumn[] { colsdt, coltencoquan, coltendaidien, colnote });
        }
        void LoadListFormNb()
        {
            dataGList.DataSource = null;
            createdatagrid();
            dataGList.DataSource = ListPhoneBook.Intance.ListNbphone;
            dataGList.Refresh();
        }
        void enableContronl(bool isEnableTextbox, bool isEnableDatagridview)
        {
            txtghichu.Enabled = txtnguoidaidien.Enabled = txtsdt.Enabled = txttencoquan.Enabled =isEnableTextbox;
            dataGList.Enabled = isEnableDatagridview;

        }
       
        private void ClearTextBox()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        bool checkvalue()
        {
            long result;
            if(txtsdt.Text == "" || txtnguoidaidien.Text == "" || txttencoquan.Text == "")
            {
                MessageBox.Show("Xin nhap day du thong tin vao o con trong", "Yeu cau");
                
            }
            if(!(long.TryParse(txtsdt.Text, out result)))
            {
                MessageBox.Show("Xin hay nhap dung dinh dang yeu cau", "thong bao");
                return false;
            }
            if(result < 0)
            {
                MessageBox.Show("hay kiem da dau tru sdt khong the la so am", "Yeu cau");
                return false;
            }
            return true;
        }
        #endregion

        #region Event
        private void Form1_Load(object sender, EventArgs e)
        {
            enableContronl(false,true);
            readXML();
            LoadListFormNb();
            btluu.Enabled = bthuy.Enabled = false;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            enableContronl(true, false);
            btSua.Enabled = btthem.Enabled = btXoa.Enabled = false;
            btluu.Enabled = bthuy.Enabled = true;
            status = "Add";
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (!checkvalue())
            {
                return;
            }
            string nbphone1 = txtsdt.Text;
            string tendaidien1 = txtnguoidaidien.Text;
            string tencoquan1 = txttencoquan.Text;
            string ghichu1 = txtghichu.Text;
            if(status == "Add")
            {
                ListPhoneBook.Intance.ListNbphone.Add(new PhoneBook(nbphone1, tencoquan1, tendaidien1, ghichu1));
            }
            if(status == "Edit")
            {
                ListPhoneBook.Intance.ListNbphone[index].Sdt = txtsdt.Text;
                ListPhoneBook.Intance.ListNbphone[index].Tentochuc = txttencoquan.Text;
                ListPhoneBook.Intance.ListNbphone[index].Tennguoidaidien = txtnguoidaidien.Text;
                ListPhoneBook.Intance.ListNbphone[index].Binhluan = txtghichu.Text;

            }
            
            enableContronl(false, true);
            
            ClearTextBox();
            LoadListFormNb();
            btSua.Enabled = btthem.Enabled = btXoa.Enabled = true;
            btluu.Enabled = bthuy.Enabled = false;
            
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if(index < 0)
            {
                MessageBox.Show("Xin hay chon 1 dong can sua", "Canh bao");
                return;
            }
            enableContronl(true, false);
            btSua.Enabled = btthem.Enabled = btXoa.Enabled = false;
            btluu.Enabled = bthuy.Enabled = true;
            txtsdt.Text = ListPhoneBook.Intance.ListNbphone[index].Sdt;
            txttencoquan.Text = ListPhoneBook.Intance.ListNbphone[index].Tentochuc;
            txtnguoidaidien.Text = ListPhoneBook.Intance.ListNbphone[index].Tennguoidaidien;
            txtghichu.Text = ListPhoneBook.Intance.ListNbphone[index].Binhluan;
            status = "Edit";
        }

        private void dataGList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(status == "Search")
            {
                indexSearch = e.RowIndex;
                for( int i = 0; i < ListPhoneBook.Intance.ListNbphone.Count; i++)
                {
                    if(ListPhoneBook.Intance.ListNbphone[i].Tentochuc == dataGList.Rows[indexSearch].Cells[1].Value.ToString())
                    {
                        index = i;
                    }
                }
            }
            else
            {
                index = e.RowIndex;
            }
            
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            enableContronl(false, true);
            LoadListFormNb();
            btSua.Enabled = btthem.Enabled = btXoa.Enabled = true;
            btluu.Enabled = bthuy.Enabled = false;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (index < 0)
            {
                MessageBox.Show("Xin hay chon 1 dong can sua", "Canh bao");
                return;
            }
            else
            {
                if (MessageBox.Show("Ban co muon xoa bang ghi khong", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                     ListPhoneBook.Intance.ListNbphone.RemoveAt(index);
                }
            }
            LoadListFormNb();

        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            txttencoquan.Enabled = true;
            bthuy.Enabled = true;
            btthem.Enabled = btluu.Enabled = false;
            status = "Search";
        }

        private void txttencoquan_TextChanged(object sender, EventArgs e)
        {
            string search = txttencoquan.Text;
            if (search != null)
            {
                List<PhoneBook> listsearch = new List<PhoneBook>();
                foreach (var item in ListPhoneBook.Intance.ListNbphone)
                {
                    if (item.Tentochuc.ToUpper().Contains(search.ToUpper()))
                    {
                        listsearch.Add(item);
                    }
                    dataGList.DataSource = null;
                    createdatagrid();
                    dataGList.DataSource = listsearch;
                }
            }
           else
            {
                dataGList.DataSource = null;
                LoadListFormNb();
            }
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            writeXML();
        }
    }
}
