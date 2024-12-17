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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database_for_products
{
    public partial class InsertDataForm : Form
    {

        private NpgsqlConnection connection;

        public InsertDataForm()
        {
            InitializeComponent();

            //Инициализация соединения
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Own3(rR;Database=products";
            connection = new NpgsqlConnection(connectionString);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void btnGoToMainFrame_Click(object sender, EventArgs e)
        {
            var mainform = (MainForm)Tag;
            mainform.Show();
            Close();
        }

        //сохранение 1 таблицы с ДСЕ
        private void btnSaveDataDSE_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    //превращаем данные в строковый тип
                    string id = row.Cells["ID"].Value.ToString();
                    string name = row.Cells["DSE_name"].Value.ToString();

                    if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //конвертация ID в тип int
                    if(!int.TryParse(id, out int intId))
                    {
                        MessageBox.Show("ID должен принимать числовое значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    InsertDataToDB(intId,name);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Ошибка при сохранении, проверьте правильность вводимых данных: " + ex.Message);
                }
            }

            MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearDataGridView();
        }

        //очистка таблицы после сохранения
        private void ClearDataGridView()
        {
            dataGridView1.Rows.Clear();
        }

        //добавление данных в БД
        private void InsertDataToDB(int id, string name)
        {
            try
            {
                connection.Open();

                //запрос на добавляемые поля
                string query = "INSERT INTO detail_assembly_unit (id, name) VALUES (@id, @name)";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    //само добавление полей
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }
            finally 
            { 
                connection.Close(); 
            }
        }

        private void btnSaveDataWithMaterials_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    string dse_id = row.Cells["DSE_ID"].Value.ToString();
                    string dse_name = row.Cells["DSE_name_w_materials"].Value.ToString();
                    string component_type = row.Cells["component_type"].Value.ToString();
                    string component_code = row.Cells["component_code"].Value.ToString();
                    string component_name = row.Cells["component_name"].Value.ToString();
                    string quantity = row.Cells["quantity"].Value.ToString();
                    string unit = row.Cells["unit_of_measurement"].Value.ToString();

                    if (string.IsNullOrEmpty(dse_id) || string.IsNullOrEmpty(dse_name) || string.IsNullOrEmpty(component_type) || string.IsNullOrEmpty(component_code) || 
                        string.IsNullOrEmpty(component_name) || string.IsNullOrEmpty(quantity) || string.IsNullOrEmpty(unit))
                    {
                        MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!int.TryParse(dse_id, out int dse_intId) || !int.TryParse(component_code, out int intcompCode) || !float.TryParse(quantity, out float flQuantity))
                    {
                        MessageBox.Show("ID должен принимать числовое значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    InsertDataToDBWithMaterials(dse_intId, dse_name, component_type, intcompCode, component_name, flQuantity, unit);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении, проверьте правильность вводимых данных: " + ex.Message);
                }
            }

            MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearDataGridViewWithMaterials();
        }

        //очистка таблицы после сохранения
        private void ClearDataGridViewWithMaterials()
        {
            dataGridView2.Rows.Clear();
        }

        //добавление данных в БД
        private void InsertDataToDBWithMaterials(int dse_id, string dse_name, string comp_type, int comp_code, string comp_name, float quantity, string unit)
        {
            try
            {
                connection.Open();

                //запрос на добавляемые поля
                string query = "INSERT INTO composion (assembly_unit_id, assembly_unit_name, component_type, component_code, component_name, quantity, unit_of_measurement) " +
                    "VALUES (@assembly_unit_id, @assembly_unit_name, @component_type, @component_code, @component_name, @quantity, @unit_of_measurement)";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    //само добавление полей
                    command.Parameters.AddWithValue("@assembly_unit_id", dse_id);
                    command.Parameters.AddWithValue("@assembly_unit_name", dse_name);
                    command.Parameters.AddWithValue("@component_type", comp_type);
                    command.Parameters.AddWithValue("@component_code", comp_code);
                    command.Parameters.AddWithValue("@component_name", comp_name);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@unit_of_measurement", unit);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
