using Npgsql;
using OfficeOpenXml;
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

namespace Database_for_products
{
    public partial class MaterialForm : Form
    {

        private NpgsqlConnection connection;

        public MaterialForm()
        {
            InitializeComponent();
            //Инициализация соединения
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Own3(rR;Database=products";
            connection = new NpgsqlConnection(connectionString);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        //заполнение второго DataGridView листом 2 с материалами
        //чтение таблицы из Excel
        private DataTable LoadListWithComponents(string PathToFile)
        {
            var dataTableWithComponent = new DataTable();

            //EPPlus для чтения файла
            FileInfo file = new FileInfo(PathToFile);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];//второй лист

                int columnCount = worksheet.Dimension.End.Column;

                // Добавление столбцов в DataTable
                for (int col = 1; col <= columnCount; col++)
                {
                    dataTableWithComponent.Columns.Add($"Column{col}");
                }

                //заполнение DataTable данными
                for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                {
                    DataRow dataRow = dataTableWithComponent.NewRow();
                    for (int column = 1; column <= worksheet.Dimension.End.Column; column++)
                    {
                        dataRow[column - 1] = worksheet.Cells[row, column].Text.Replace(",", ".");
                    }
                    dataTableWithComponent.Rows.Add(dataRow);
                }
            }
            return dataTableWithComponent;
        }

        private string SaveDataTableWithComponentToCSV(DataTable dataTableWithComponent, string csvFilePath)
        {
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {

                // Запись данных
                foreach (DataRow row in dataTableWithComponent.Rows)
                {
                    for (int i = 0; i < dataTableWithComponent.Columns.Count; i++)
                    {
                        writer.Write(row[i].ToString());
                        if (i < dataTableWithComponent.Columns.Count - 1)
                            writer.Write(",");
                    }
                    writer.WriteLine();
                }
            }
            return csvFilePath;
        }

        //импорт в Postgree

        private void ImportDataWithComponentToDB(string csvFilePath)
        {
            try
            {
                connection.Open();

                using (var writer = connection.BeginTextImport($"COPY composion (assembly_unit_id, assembly_unit_name, " +
                    $"component_type, component_code, component_name, quantity, unit_of_measurement) FROM STDIN WITH (FORMAT csv)"))
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
                DataTable dataTableWithComponent = LoadListWithComponents(excelFilePath);

                // Сохранение DataTable в CSV файл
                string csvFilePathWithComponent = "C:\\BD_Project\\dse_xlsx\\data_with_component.csv";
                SaveDataTableWithComponentToCSV(dataTableWithComponent, csvFilePathWithComponent);

                // Импорт CSV в PostgreSQL
                ImportDataWithComponentToDB(csvFilePathWithComponent);
            }
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
                dataGridView1.DataSource = dataTableWithComponent;
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

        private void btnGoToMainForm_Click(object sender, EventArgs e)
        {
            var mainform = (MainForm)Tag;
            mainform.Show();
            Close();
        }

        private void btnLoadMaterials_Click(object sender, EventArgs e)
        {
            LoadToDataGridViewWithMaterial();
        }
    }
}
