using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;
using static System.Net.WebRequestMethods;

namespace Database_for_products
{
    public partial class MainForm : Form
    {
        private NpgsqlConnection connection;

        public MainForm()
        {
            InitializeComponent();
            //Инициализация соединения
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Own3(rR;Database=products";
            connection = new NpgsqlConnection(connectionString);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void ConnectToDatabase()
        {
            try
            {
                connection.Open();
                MessageBox.Show("Подключение к базе данных выполнено!");
                //здесь выполняются SQL-запросы к БД
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex.Message);
            }
            finally { connection.Close(); }
        }

        //чтение таблицы из Excel
        private DataTable LoadFile(string PathToFile)
        {
            var dataTable = new DataTable();

            //EPPlus для чтения файла
            FileInfo file = new FileInfo(PathToFile);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];//первый лист

                //Заполнение DataTable заголовками
                //for (int columns = 1; columns <= worksheet.Dimension.End.Column; columns++)
                //{
                //    dataTable.Columns.Add(worksheet.Cells[1, columns].Text);
                //}

                int columnCount = worksheet.Dimension.End.Column;

                // Добавление столбцов в DataTable
                for (int col = 1; col <= columnCount; col++)
                {
                    dataTable.Columns.Add($"Column{col}"); 
                }

                //заполнение DataTable данными
                for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int column = 1; column <= worksheet.Dimension.End.Column; column++)
                    {
                        dataRow[column - 1] = worksheet.Cells[row, column].Text;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
            return dataTable;
        }

        private string SaveDataTableToCSV(DataTable dataTable, string csvFilePath)
        {
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                // Запись заголовков
                //for (int i = 1; i < dataTable.Columns.Count; i++)
                //{
                //    writer.Write(dataTable.Columns[i]);
                //    if (i < dataTable.Columns.Count - 1)
                //        writer.Write(",");
                //}
                //writer.WriteLine();

                // Запись данных
                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        writer.Write(row[i].ToString());
                        if (i < dataTable.Columns.Count - 1)
                            writer.Write(",");
                    }
                    writer.WriteLine();
                }
            }
            return csvFilePath;
        }

        //импорт в Postgree

        private void ImportDataToDB(string csvFilePath)
        {
            try
            {
                connection.Open();

                using (var writer = connection.BeginTextImport($"COPY detail_assembly_unit (id, name) FROM STDIN WITH (FORMAT csv)"))
                using (var reader = new StreamReader(csvFilePath))
                {
                    writer.Write(reader.ReadToEnd());
                }

                MessageBox.Show("Данные успешно импортированы!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при импорте данных: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }    
        }

        //загрузка данных в таблицу на экране
        private void LoadToDataGridView()
        {
            try
            {
                connection.Open();
                //Работа с БД
                string query = "SELECT * FROM detail_assembly_unit";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                //DataAdapter для загрузки данных в DT
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                //привязка данных к элементам формы DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnLoadDataToDGW1_Click(object sender, EventArgs e)
        {
            LoadToDataGridView();
        }

        private void btnSelectFileToImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Выберите Excel файл для импорта"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string excelFilePath = openFileDialog.FileName;

                // Загрузка данных из Excel в DataTable
                DataTable dataTable = LoadFile(excelFilePath);

                // Сохранение DataTable в CSV файл
                string csvFilePath = "C:\\BD_Project\\dse_xlsx\\data.csv";
                SaveDataTableToCSV(dataTable, csvFilePath); 

                // Импорт CSV в PostgreSQL
                ImportDataToDB(csvFilePath);
            }
        }

        private void btGoToDeleteFrame_Click(object sender, EventArgs e)
        {
            DeleteForm delform = new DeleteForm();
            delform.Tag = this;
            delform.Show(this);
            Hide();
        }
    }
}
