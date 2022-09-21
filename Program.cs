using System;
using System.Data;
using System.Data.SqlClient;
using databasetry.Models;

namespace databasetry
{
    class Program
    {
        SqlConnection sqlConnection;

        /*
         * Data Source -> Server
         * Initial Catalog -> Database
         * User ID -> username
         * Password -> password
         * Connect Timeout
         */
        string connectionString =
            "Data Source = DESKTOP-AFA1311; Initial Catalog = connection2; User ID = MCCDTS; Password = 12345;";

        static void Main(string[] args)
        {
            // variabel
            int input;
            //looping
            for (input = 1; input <= 2; input++)
            {
                Console.WriteLine("");
                Console.WriteLine("============================================================");
                Console.WriteLine("                        Gaji Karyawan    ");
                Console.WriteLine("============================================================");
                Console.WriteLine("");
                Console.WriteLine(" 1. Golongan Gaji Karyawan ");
                Console.WriteLine(" 2. Data Karyawan ");
                Console.WriteLine("");
                Console.WriteLine("============================================================");
                Console.Write(" Silahkan masukkan nomor pilihan :");
                input = Convert.ToInt32(Console.ReadLine());
                // if else
                if ((input >= 1) && (input <= 2))
                { //comparison & conditional operator
                    switch (input)
                    {// switch case
                        case 1:
                            Console.WriteLine("");
                            //gaji();
                            break;
                        case 2:
                            Console.WriteLine("");
                            crudkar();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Data Tidak Ditemukan");
                    Console.WriteLine("");
                }
            }
        }
        static void crudkar()
        {
            Program program = new Program();

            //program.GetById(1);
            Console.WriteLine("========= Data Karyawan ===========");
            Console.WriteLine();
            program.GetAllKaryawan();
            Console.WriteLine();

            //insert kary
            karyawan kary = new karyawan()
            { //NIK, Golongan, FirstName, LastName, Jabatan, Tanggal Lahir, Alamat
                Nik = "3304015671889998",
                Golongan = 1,
                Nama = "Amarta Pradipta",
                Jabatan = "Manajer",
                Alamat = "Bandung"
            };
            program.Insertkaryawan(kary);
            Console.WriteLine();
            Console.WriteLine("========= Data Insert Karyawan ========");
            Console.WriteLine();
            program.GetAllKaryawan();
            Console.WriteLine();

            //update data karyawan
            karyawan upkar = new karyawan()
            {
                Nama = "Agus Haryanto",
                Golongan = 2,
                Jabatan = "Staff"
            };
            program.Updatekaryawan(kary);

            Console.WriteLine();
            Console.WriteLine("========= Data Update Karyawan ========");
            Console.WriteLine();
            program.GetAllKaryawan();


            //delete data karyawan
            Console.WriteLine();
            Console.WriteLine("========= Data Karyawan ========");
            Console.WriteLine();
            program.GetAllKaryawan();
            Console.WriteLine();
            Console.WriteLine("======= Delete Data Karyawan =====");
            karyawan delkar = new karyawan
            {
                Nama = "Ayu Lestari"
            };
            program.deletekaryawan(delkar);

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-------- Data Setelah di Delete -----");
            Console.WriteLine("-------------------------------------");
            program.GetAllKaryawan();

        
            ////insert gaji
            //gaji sal = new gaji();
            //{ //Golongan, gaji pokok, tunjangan makan, total gaji
            //    Golongan = 4,
            //    GajiPokok = "Rp 750.000",
            //    TunjanganMakan = "Rp 50.000",
            //    TotalGaji = "Rp 800.000"
            //};
            //program.Insertgaji(sal);
            //Console.WriteLine();
            //Console.WriteLine("========= Data Insert Gaji ========");
            //Console.WriteLine();
            //program.GetAllGaji();
            //Console.WriteLine();
        }

        void GetAllKaryawan()
        {
            string query = "SELECT * FROM karyawan";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {

                            Console.WriteLine(sqlDataReader[0] + " | " + sqlDataReader[1] +
                                " | " + sqlDataReader[2] + " | " + sqlDataReader[3] + " | " +
                                sqlDataReader[4] + " | " + sqlDataReader[5] + " | ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        void GetAllGaji()
        {
            string query = "SELECT * FROM gaji";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {

                            Console.WriteLine(sqlDataReader[0] + " | " + sqlDataReader[1] +
                                " | " + sqlDataReader[2] + " | " + sqlDataReader[3] + " | ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        void GetById(int id)
        {
            string query = "SELECT * FROM Karyawan WHERE KaryawanId = @id";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = id;

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " | " +
                                sqlDataReader[1] + " | " + sqlDataReader[2] + " | " +
                                sqlDataReader[3] + " | " + sqlDataReader[4] + " | " + sqlDataReader[5] +
                                " | ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        void Insertkaryawan(karyawan karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {

                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText =
                        "INSERT INTO Karyawan " +
                        "(NIK, Golongan, Nama, Jabatan, Alamat) VALUES (@nik, @gol,@nama, @jabatan, @alamat) ";
                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@nik";
                    sqlParameter1.Value = karyawan.Nik;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@gol";
                    sqlParameter2.Value = karyawan.Golongan;

                    SqlParameter sqlParameter3 = new SqlParameter();
                    sqlParameter3.ParameterName = "@nama";
                    sqlParameter3.Value = karyawan.Nama;

                    SqlParameter sqlParameter4 = new SqlParameter();
                    sqlParameter4.ParameterName = "@jabatan";
                    sqlParameter4.Value = karyawan.Jabatan;

                    SqlParameter sqlParameter5 = new SqlParameter();
                    sqlParameter5.ParameterName = "@alamat";
                    sqlParameter5.Value = karyawan.Alamat;

                    sqlCommand.Parameters.Add(sqlParameter1);
                    sqlCommand.Parameters.Add(sqlParameter2);
                    sqlCommand.Parameters.Add(sqlParameter3);
                    sqlCommand.Parameters.Add(sqlParameter4);
                    sqlCommand.Parameters.Add(sqlParameter5);

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }

            }
            //    sqlConnection.Open();
            //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.Transaction = sqlTransaction;


        }

        void Insertgaji(gaji gaji)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {

                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText =
                        "INSERT INTO Karyawan " +
                        "(Golongan, GajiPokok, TunjanganMakan, TotalGaji) VALUES (@gol,@gajipokok, @tunj, @total) ";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@gol";
                    sqlParameter1.Value = gaji.Golongan;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@gajipokok";
                    sqlParameter2.Value = gaji.GajiPokok;

                    SqlParameter sqlParameter3 = new SqlParameter();
                    sqlParameter3.ParameterName = "@tunj";
                    sqlParameter3.Value = gaji.TunjanganMakan;

                    SqlParameter sqlParameter4 = new SqlParameter();
                    sqlParameter4.ParameterName = "@total";
                    sqlParameter4.Value = gaji.TotalGaji;

                    sqlCommand.Parameters.Add(sqlParameter1);
                    sqlCommand.Parameters.Add(sqlParameter2);
                    sqlCommand.Parameters.Add(sqlParameter3);
                    sqlCommand.Parameters.Add(sqlParameter4);


                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
        }

        void Updatekaryawan(karyawan karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {

                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText =
                        "UPDATE karyawan SET Golongan = @golongan, Jabatan = @jabatan WHERE Nama = @nama";
                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@golongan";
                    sqlParameter1.Value = karyawan.Golongan;

                    SqlParameter sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "@jabatan";
                    sqlParameter2.Value = karyawan.Jabatan;

                    SqlParameter sqlParameter3 = new SqlParameter();
                    sqlParameter2.ParameterName = "@nama";
                    sqlParameter2.Value = karyawan.Nama;

                    sqlCommand.Parameters.Add(sqlParameter1);
                    sqlCommand.Parameters.Add(sqlParameter2);
                    sqlCommand.Parameters.Add(sqlParameter3);

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
        }

        void deletekaryawan(karyawan karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {

                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText =
                        "DELETE FROM karyawan WHERE Nama = @nama";
                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@nama";
                    sqlParameter1.Value = karyawan.Nama;

                    //SqlParameter sqlParameter2 = new SqlParameter();
                    //sqlParameter2.ParameterName = "@jabatan";
                    //sqlParameter2.Value = karyawan.Jabatan;

                    sqlCommand.Parameters.Add(sqlParameter1);
                    //sqlCommand.Parameters.Add(sqlParameter2);

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
        }
    }
}
