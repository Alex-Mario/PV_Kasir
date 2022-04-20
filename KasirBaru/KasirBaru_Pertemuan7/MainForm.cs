using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace KasirBaru_Pertemuan7
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private SqlCommand cmd;
		private DataSet ds;
		private SqlDataAdapter da;
		
		Koneksi Konn = new Koneksi();
		
		public MainForm()
		{
			
			InitializeComponent();
			
		}
		
		void Bersihkan()
		{
			textBox1.Text="";
			textBox2.Text="";
			textBox3.Text="0";
			textBox4.Text="0";
			textBox5.Text="0";
			textBox6.Text="";
		}
		
		private void MainFormLoad(object sender, EventArgs e)
		{
			TampilBarang();
			Bersihkan();
		}
		
		/**************************************************************
		 * Membuat event tombol simpan
		 *************************************************************/
		private void Button1Click(object sender, EventArgs e)
		{
			/*********************************************************
			 * memeriksa apakah kolom text kosong?
			 * ******************************************************/
			if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
			{
				MessageBox.Show("Mohon isikan terlebih dahulu  kolom kolom yang tersedia");
			}
			
			else{
				//simpan data
				SqlConnection conn = Konn.GetConn();
				
				try
				{
					cmd = new SqlCommand("INSERT INTO TBL_BARANG VALUES ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"')", conn);
					conn.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("Insert data berhasil!");
					TampilBarang();
					Bersihkan();
				}
				
				catch(Exception X) {
					MessageBox.Show("Tidak dapat menyimpan data");
				}
			}
		}
		
		void TampilBarang()
		{
			SqlConnection conn = Konn.GetConn();
			try{
				conn.Open();
				cmd = new SqlCommand("Select * from TBL_Barang", conn);
				ds = new DataSet();
				da = new SqlDataAdapter(cmd);
				da.Fill(ds, "TBL_Barang");
				dataGridView1.DataSource = ds;
				dataGridView1.DataMember = "TBL_BARANG";
				dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}
			
			catch(Exception G){
				MessageBox.Show(G.ToString());
			}
			
			finally{
				conn.Close();
			}	
		}
		
		/*
		void MainFormLoad(object sender, EventArgs e)
		{
			SqlConnection conn = Konn.GetConn();
			try{
				conn.Open();
				cmd = new SqlCommand("Select * from TBL_Barang", conn);
				ds = new DataSet();
				da = new SqlDataAdapter(cmd);
				da.Fill(ds, "TBL_Barang");
				dataGridView1.DataSource = ds;
				dataGridView1.DataMember = "TBL_BARANG";
				dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}
			
			catch(Exception G){
				MessageBox.Show(G.ToString());
			}
			
			finally{
				conn.Close();
			}
		}
		*/
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try{
				DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
				textBox1.Text = row.Cells["KodeBarang"].Value.ToString();
				textBox2.Text = row.Cells["NamaBarang"].Value.ToString();
				textBox3.Text = row.Cells["HargaJual"].Value.ToString();
				textBox4.Text = row.Cells["HargaBeli"].Value.ToString();
				textBox5.Text = row.Cells["JumlahBarang"].Value.ToString();
				textBox6.Text = row.Cells["SatuanBarang"].Value.ToString();
				
			}
			
			catch(Exception e1){
				MessageBox.Show(e1.ToString());
			}
		}
		
		void Label2Click(object sender, EventArgs e)
		{
			
		}
		
		void Label7Click(object sender, EventArgs e)
		{
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			/*********************************************************
			 * memeriksa apakah kolom text kosong?
			 * ******************************************************/
			if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
			{
				MessageBox.Show("Mohon isikan terlebih dahulu  kolom kolom yang tersedia");
			}
			
			else{
				//simpan data//
				SqlConnection conn = Konn.GetConn();
				
				try
				{
					cmd = new SqlCommand("UPDATE TBL_BARANG SET NamaBarang='"+textBox2.Text+"',HargaJual='"+textBox3.Text+"',HargaBeli='"+textBox4.Text+"',JumlahBarang='"+textBox5.Text+"',SatuanBarang='"+textBox6.Text+"'WHERE KodeBarang='"+textBox1.Text+"'", conn);
					conn.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("Update data berhasil!");
					TampilBarang();
					Bersihkan();
				}
				
				catch(Exception X) {
					MessageBox.Show("Tidak dapat menyimpan data");
				}
			}
		}
	}
}
