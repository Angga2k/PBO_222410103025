using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBO_222410103025
{
    public partial class Form1 : Form
    {
        DatabaseHelpers database;
        string radiobuttonvalue = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            database = new DatabaseHelpers();
            DataPegawai();
            AturDGV();
        }

        private void AturDGV()
        {
            dataGridView1.Columns["id_pegawai"].HeaderText = "ID Pegawai";
            dataGridView1.Columns["nama"].HeaderText = "Nama";
            dataGridView1.Columns["jabatan"].HeaderText = "Jabatan";
            dataGridView1.Columns["jenis_kelamin"].HeaderText = "Jenis Kelamin";
            dataGridView1.Columns["no_telepon"].HeaderText = "No Telepon";
            dataGridView1.Columns["alamat"].HeaderText = "Alamat";
            dataGridView1.Columns["Edit"].DisplayIndex = 7;
            dataGridView1.Columns["Delete"].DisplayIndex = 7;
        }

        private void DataPegawai()
        {
            string sql = "SELECT * FROM pegawai";
            dataGridView1.DataSource = database.getData(sql);

            comboBox1.SelectedItem = "Manajer Umum";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radiobuttonvalue = "Laki - laki";
            }
            else if (radioButton2.Checked)
            {
                radiobuttonvalue = "Wanita";
            }
            string sql = $"INSERT INTO pegawai (id_pegawai, nama, jabatan, jenis_kelamin, no_telepon, alamat) VALUES ({textBox1.Text},'{textBox2.Text}','{comboBox1.SelectedItem}','{radiobuttonvalue}','{textBox3.Text}','{textBox4.Text}')";
            if (Modul.showDialog("Apakah anda yakin?") == DialogResult.Yes)
            {
                Modul.dialogBerhasil("Data Berhasil Ditambahkan");
                database.exc(sql);
                DataPegawai();
                button3.PerformClick();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            comboBox1.SelectedItem = "Manajer Umum";
            radioButton1.Checked= false;
            radioButton2.Checked= false;
            textBox1.Enabled = true;
            button1.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                button1.Enabled = false;
                textBox1.Enabled = false;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id_pegawai"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["nama"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["no_telepon"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["alamat"].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["jabatan"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["jenis_kelamin"].Value.ToString() == "Laki - laki")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                string id_pegawai = dataGridView1.Rows[e.RowIndex].Cells["id_pegawai"].Value.ToString();
                string sql = $"delete from pegawai where id_pegawai = {id_pegawai}";

                if (Modul.showDialog("Apakah anda yakin untuk menghapus data?") == DialogResult.Yes)
                {
                    Modul.dialogBerhasil("Data Berhasil Dihapus");
                    database.exc(sql);
                    DataPegawai();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                radiobuttonvalue = "Laki - laki";
            }
            else if (radioButton2.Checked)
            {
                radiobuttonvalue = "Wanita";
            }
            if (Modul.showDialog("Apakah Anda Yakin Ingin Update Data?") == DialogResult.Yes)
            {
                string sql = $"update pegawai set nama = '{textBox2.Text}', jabatan = '{comboBox1.SelectedItem}', jenis_kelamin='{radiobuttonvalue}', no_telepon='{textBox3.Text}', alamat='{textBox4.Text}' where id_pegawai='{textBox1.Text}'";
                database.exc(sql);
                Modul.dialogBerhasil("Data berhasil diganti!");
                DataPegawai();
                button3.PerformClick();
            }
        }
    }
}
