using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//1
using System.Data.SqlClient;

namespace KasirBaru_Pertemuan7
{
	
	class Koneksi
	{
		//2
		public SqlConnection GetConn()
		{
			SqlConnection Conn = new SqlConnection();
			Conn.ConnectionString = @"Data Source=AOC\SQLEXPRESS; initial catalog = Kasir; integrated security = True";
			return Conn;
		}
	}
}
