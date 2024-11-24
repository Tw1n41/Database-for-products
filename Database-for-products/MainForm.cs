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

            //обработчик выделения
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void ConnectToDatabase()
        {
            try
            {
                connection.Open();
                MessageBox.Show("Подключение к базе данных выполнено!");
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
            dataGridView1.Sort(dataGridView1.Columns["id"], System.ComponentModel.ListSortDirection.Ascending);
        }


        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                LoadDataGridView2(ID);
            }
        }

        private void LoadDataGridView2(int ID)
        {
            try
            {
                connection.Open();

                var query = "SELECT assembly_unit_id, assembly_unit_name, component_type, component_code, " +
                    "component_name, quantity, unit_of_measurement " +
                    "FROM composion " +
                    "WHERE assembly_unit_id = @id";
                var adapter = new Npgsql.NpgsqlDataAdapter(query, connection);

                //parameter
                adapter.SelectCommand.Parameters.AddWithValue("@id", ID);

                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView2.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
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

        //загрузка данных в таблицу на экране
        private void LoadToDataGridViewWithMaterial()
        {
            try
            {
                connection.Open();
                //Работа с БД
                string query = "SELECT * FROM composion";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                //DataAdapter для загрузки данных в DT
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataTable dataTableWithComponent = new DataTable();
                adapter.Fill(dataTableWithComponent);
                //привязка данных к элементам формы DataGridView
                dataGridView2.DataSource = dataTableWithComponent;
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

        //создать 2 кнопку выгрузки
        private void btnLoadMaterials_Click(object sender, EventArgs e)
        {
            LoadToDataGridViewWithMaterial();
            dataGridView2.Sort(dataGridView2.Columns["assembly_unit_id"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void btnGoToMaterialFrame_Click(object sender, EventArgs e)
        {
            MaterialForm matform = new MaterialForm();
            matform.Tag = this;
            matform.Show(this);
            Hide();
        }

        private void btnGoToInsertData_Click(object sender, EventArgs e)
        {
            InsertDataForm dataForm = new InsertDataForm();
            dataForm.Tag = this;
            dataForm.Show(this);
            Hide();
        }

        public void ExportDataToExcel(string query, string filePath)
        {
            try
            {
                connection.Open();

                DataTable dataTable = new DataTable();

                using(var command = new NpgsqlCommand(query, connection))
                {
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("ExportedData");

                    //запись заголовков столбцов
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        worksheet.Cells[1, col + 1].Value = dataTable.Columns[col].ColumnName;
                    }

                    //запись строк
                    for (int row =0;row < dataTable.Rows.Count; row++)
                    {
                        for (int col = 0;col < dataTable.Columns.Count; col++)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = dataTable.Rows[row][col];
                        }
                    }

                    //само сохранение файла
                    FileInfo excelFile = new FileInfo(filePath);
                    package.SaveAs(excelFile);
                }
                
                MessageBox.Show("Данные успешно экспортированы в Excel!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            //запрос для экспорта
            string query = "SELECT * FROM detail_assembly_unit";

            //путь для сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Сохранить как Excel файл"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ExportDataToExcel(query, filePath);
            }
        }

        private void btnSaveDataWithMaterials_Click(object sender, EventArgs e)
        {
            //запрос для экспорта
            string query = "SELECT * FROM composion";

            //путь для сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Сохранить как Excel файл"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ExportDataToExcel(query, filePath);
            }
        }
    }
}
