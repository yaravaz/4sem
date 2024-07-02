using lab8.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.WebRequestMethods;

namespace lab8.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        SqlDataAdapter adapterB;
        SqlDataAdapter adapterA;

        SqlDataAdapter adapterQuery;
        SqlDataAdapter adapterParam;

        SqlCommandBuilder commandBuilder;
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string reservString = System.Configuration.ConfigurationManager.ConnectionStrings["ReserveConnection"].ConnectionString;
        string query1 = "SELECT * FROM Book";
        string query2 = "SELECT * FROM Author";
        static string format = "fb2";
        string query = "select bname, psevdo, country, size, num_pages from book join author on author = id_author";
        string queryP = string.Format("select bname, psevdo, num_pages, num_chapt, size, format from book join author on author = id_author where format='{0}'", format);

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        DataTable _tableb;
        public DataTable Tableb
        {
            get { return _tableb; }
            set
            {
                _tableb = value;
                OnPropertyChanged("_tableb");
            }
        }

        DataTable _tablea;
        public DataTable Tablea
        {
            get { return _tablea; }
            set
            {
                _tablea = value;
                OnPropertyChanged("_tablea");
            }
        }

        DataTable _tableQuery;
        public DataTable TableQuery
        {
            get { return _tableQuery; }
            set
            {
                _tableQuery = value;
                OnPropertyChanged("_tableQuery");
            }
        }

        DataTable _tableParam;
        public DataTable TableParam
        {
            get { return _tableParam; }
            set
            {
                _tableParam = value;
                OnPropertyChanged("_tableParam");
            }
        }

        int _indexBook;
        public int IndexBook
        {
            get { return _indexBook; }
            set
            {
                _indexBook = value;
                OnPropertyChanged("IndexBook");
            }
        }

        int _indexAuthor;
        public int IndexAuthor
        {
            get { return _indexAuthor; }
            set
            {
                _indexAuthor = value;
                OnPropertyChanged("IndexAuthor");
            }
        }

        string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        public ICommand UpdateCommand { get; }
        private void OnUpdateCommandExecuted(object parametr)
        {
            SqlConnection connection = new SqlConnection(connectionString); 
            connection.Open();
            SqlTransaction sqlTransaction = null;

            try
            {
                adapterB = new SqlDataAdapter(query1, connection);
                commandBuilder = new SqlCommandBuilder(adapterB); 

                adapterB.InsertCommand = new SqlCommand("addBook", connection);
                adapterB.InsertCommand.CommandType = CommandType.StoredProcedure;

                adapterB.InsertCommand.Parameters.Add(new SqlParameter("@bname", SqlDbType.NVarChar, 20, "bname"));
                adapterB.InsertCommand.Parameters.Add(new SqlParameter("@author", SqlDbType.Int, 0, "author"));
                adapterB.InsertCommand.Parameters.Add(new SqlParameter("@image", SqlDbType.NVarChar, int.MaxValue, "image"));
                adapterB.InsertCommand.Parameters.Add(new SqlParameter("@publish_year", SqlDbType.Int, 0, "publish_year"));
                adapterB.InsertCommand.Parameters.Add(new SqlParameter("@publisher", SqlDbType.NVarChar, 20, "publisher"));
                adapterB.InsertCommand.Parameters.Add(new SqlParameter("@num_pages", SqlDbType.Int, 0, "num_pages"));
                adapterB.InsertCommand.Parameters.Add(new SqlParameter("@num_chapt", SqlDbType.Int, 0, "num_chapt"));
                adapterB.InsertCommand.Parameters.Add(new SqlParameter("@format", SqlDbType.NVarChar, 10, "format"));
                adapterB.InsertCommand.Parameters.Add(new SqlParameter("@size", SqlDbType.Real, 0, "size"));
                
                adapterB.UpdateCommand = commandBuilder.GetUpdateCommand();
                adapterB.DeleteCommand = commandBuilder.GetDeleteCommand();

                sqlTransaction = connection.BeginTransaction();
                adapterB.InsertCommand.Transaction = sqlTransaction;
                adapterB.UpdateCommand.Transaction = sqlTransaction;
                adapterB.DeleteCommand.Transaction = sqlTransaction;

                adapterB.Update(Tableb.Copy());

                sqlTransaction.Commit();

                adapterA = new SqlDataAdapter(query2, connection);
                commandBuilder = new SqlCommandBuilder(adapterA);

                adapterA.InsertCommand = new SqlCommand("addAuthor", connection);
                adapterA.InsertCommand.CommandType = CommandType.StoredProcedure;

                adapterA.InsertCommand.Parameters.Add(new SqlParameter("@id_author", SqlDbType.Int, 0, "id_author"));
                adapterA.InsertCommand.Parameters.Add(new SqlParameter("@psevdo", SqlDbType.NVarChar, 30, "psevdo"));
                adapterA.InsertCommand.Parameters.Add(new SqlParameter("@country", SqlDbType.NVarChar, 20, "country"));
                adapterA.InsertCommand.Parameters.Add(new SqlParameter("@byear", SqlDbType.Int, 0, "byear"));

                adapterA.UpdateCommand = commandBuilder.GetUpdateCommand();
                adapterA.DeleteCommand = commandBuilder.GetDeleteCommand();

                sqlTransaction = connection.BeginTransaction();
                adapterA.InsertCommand.Transaction = sqlTransaction;
                adapterA.UpdateCommand.Transaction = sqlTransaction;
                adapterA.DeleteCommand.Transaction = sqlTransaction;

                adapterA.Update(Tablea.Copy());

                sqlTransaction.Commit();

                Tableb.AcceptChanges();
                Tablea.AcceptChanges();

                adapterQuery = new SqlDataAdapter(query, connection);

                adapterQuery.Update(TableQuery.Copy());

                SqlCommand command = new SqlCommand(queryP, connection);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@x";
                param.Value = format;
                param.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(param);

                adapterParam.Update(TableParam.Copy());

                TableParam.AcceptChanges();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction?.Rollback();
            }
            finally
            {
                sqlTransaction?.Dispose();
                if (connection != null)
                    connection.Close();
            }
        }

        private bool CanUpdateCommandExecute(object parametr)=> true;

        public ICommand DeleteCommand { get; }
        private void OnDeleteCommandExecuted(object parametr)
        {
            try
            {
                if ((int)parametr == 0)
                {
                    DataRow row = Tableb.Rows[IndexBook];
                    row.Delete();
                    adapterB.Update(Tableb);
                }
                else if ((int)parametr == 1)
                {
                    DataRow row = Tablea.Rows[IndexAuthor];
                    row.Delete();
                    adapterA.Update(Tablea);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool CanDeleteCommandExecute(object parametr) => true;

        public ICommand UpCommand { get; }
        private void OnUpCommandExecuted(object parametr)
        {
            
            if ((int)parametr == 0)
            {
                IndexBook--;
                OnPropertyChanged("IndexBook");
            }
            else if ((int)parametr == 1)
            {
                IndexAuthor--;
                OnPropertyChanged("IndexAuthor");
            }
        }
        private bool CanUpCommandExecute(object parametr) => true;


        public ICommand DownCommand { get; }
        private void OnDownCommandExecuted(object parametr)
        {
            if((int)parametr == 0)
            {
                if (IndexBook < Tableb.Rows.Count)
                {
                    IndexBook++;
                    OnPropertyChanged("IndexBook");
                }
            }
            else if((int)parametr == 1)
            {
                if (IndexAuthor < Tablea.Rows.Count)
                {
                    IndexAuthor++;
                    OnPropertyChanged("IndexAuthor");
                }
            }
            
        }
        private bool CanDownCommandExecute(object parametr) => true;

        public MainWindowViewModel()
        {
            bool check = false;
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                adapterB = new SqlDataAdapter(query1, connection);
                adapterA = new SqlDataAdapter(query2, connection);
                adapterQuery = new SqlDataAdapter(query, connection);
                adapterParam = new SqlDataAdapter(queryP, connection);
                Tableb = new DataTable();
                Tablea = new DataTable();
                TableQuery = new DataTable();
                TableParam = new DataTable();
                adapterB.Fill(Tableb);
                adapterA.Fill(Tablea);
                adapterQuery.Fill(TableQuery);
                adapterParam.Fill(TableParam);
                OnUpdateCommandExecuted(null);
            }
            catch (Exception ex)
            {
                check = true;
                MessageBox.Show("Нет базы данных или таблицы");
                SqlConnection buff_connection = new SqlConnection(reservString);
                SqlCommand create = new SqlCommand("Create DB", buff_connection);
                buff_connection.Open();
                try
                {
                    create.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string table =
                    "create table Book(\r\n\t" +
                    "id_book int identity(1, 1) constraint PK_book primary key,\r\n\t" +
                    "bname nvarchar(20) not null,\r\n\t" +
                    "author int not null constraint FK_author foreign key references Author(id_author),\r\n\t" +
                    "image nvarchar(max),\r\n\t" +
                    "publish_year int check(publish_year > 1457 and publish_year < 2024),\r\n\t" +
                    "publisher nvarchar(20) not null,\r\n\t" +
                    "num_pages int check(num_pages > 0),\r\n\t" +
                    "num_chapt int check(num_chapt > 0),\r\n\t" +
                    "format nvarchar(10) check(format in ('fb2', 'epub', 'text', 'pdf')),\r\n\t" +
                    "size real check(size > 0)\r\n);";

                create = new SqlCommand(table, connection);
                try
                {
                    create.ExecuteNonQuery();
                }
                catch( Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                table =
                    "create table Author(\r\n\t" +
                    "id_author int identity(1, 1) constraint PK_author primary key,\r\n\t" +
                    "psevdo nvarchar(30) check(psevdo not like '%[^a-zA-Zа-яА-Я-]%') not null ,\r\n\t" +
                    "country nvarchar(20) check(country not like '%[^a-zA-Zа-яА-Я-]%')\r\n);";

                create = new SqlCommand(table, connection);
                try
                {
                    create.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            if (check)
            {
                MessageBox.Show("Перезапустите приложение");
                Process.GetCurrentProcess().Kill();
            }
            UpdateCommand = new BaseCommand(OnUpdateCommandExecuted, CanUpdateCommandExecute);
            UpCommand = new BaseCommand(OnUpCommandExecuted, CanUpCommandExecute);
            DeleteCommand = new BaseCommand(OnDeleteCommandExecuted, CanDeleteCommandExecute);
            DownCommand = new BaseCommand(OnDownCommandExecuted, CanDownCommandExecute);
            
        }
    }
}
