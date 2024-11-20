using Npgsql;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_for_products
{
    public partial class DeleteForm : Form
    {
        private NpgsqlConnection connection;
        public DeleteForm()
        {
            InitializeComponent();
            //Инициализация соединения
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Own3(rR;Database=products";
            connection = new NpgsqlConnection(connectionString);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void btnGoToMainForm_Click(object sender, EventArgs e)
        {
            var mainform = (MainForm)Tag;
            mainform.Show();
            Close();
        }

        private void DeleteRowsByName(string[] namestr)
        {
            try
            {
                string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Own3(rR;Database=products";

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    //запрос для удаления строки из БД
                    string query = "DELETE FROM detail_assembly_unit WHERE name = ANY (@name)";

                    using (var command = new NpgsqlCommand(query,connection))
                    {
                        //передача параметров в запрос
                        command.Parameters.AddWithValue("name", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text, namestr);
                        int affectedRows = command.ExecuteNonQuery();

                        MessageBox.Show(affectedRows > 0 ? "Строка(и) успешно удалена!" : "Ошибка при удалении!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Операция завершена с ошибкой: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnDeleteMultiRow_Click(object sender, EventArgs e)
        {
            //получение имен
            string inputText = txtBoxNameToDel.Text;

            string[] names = inputText.Split(',')
                .Select(name => name.Trim())
                .Where(name => !string.IsNullOrEmpty(name))
                .ToArray();

            if (names.Length > 0)
            {
                DeleteRowsByName(names);
            }
            else MessageBox.Show("Введите хотя бы одно имя для удаления позиции.");
        }
    }
}
