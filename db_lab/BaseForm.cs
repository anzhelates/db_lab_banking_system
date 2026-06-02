using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace db_lab
{
    public partial class BaseForm : Form
    {
        protected string currentTable = "";

        public BaseForm()
        {
            InitializeComponent();
        }

        protected void LoadData(string tableName)
        {
            currentTable = tableName;
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var adapter = new NpgsqlDataAdapter($"SELECT * FROM public.\"{tableName}\"", conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dgvMain.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження таблиці {tableName}: " + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void LoadComboBox(ComboBox cmb, string query, string displayMember, string valueMember)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var adapter = new NpgsqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                cmb.DataSource = dt;
                cmb.DisplayMember = displayMember;
                cmb.ValueMember = valueMember;
                cmb.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження списку: " + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected bool ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Операцію успішно виконано", "Успіх",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!string.IsNullOrEmpty(currentTable))
                    LoadData(currentTable);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка бази даних: " + ex.Message,
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        protected void btnBack_Click(object sender, EventArgs e) => Close();

        protected void btnAdd_Click_1(object sender, EventArgs e) => AddRecord();

        protected void btnDelete_Click(object sender, EventArgs e) => ProcessDelete();

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Зберегти зміни")
            {
                SaveRecord();
                btnUpdate.Text = "Редагувати";
            }
            else
            {
                ProcessUpdate();
            }
        }
        protected virtual void AddRecord() { }
        protected virtual void SaveRecord() { }
        protected virtual void ExecuteDeleteLogic(DataGridViewRow row) { }
        protected virtual void ExecuteUpdateLogic(DataGridViewRow row) { }

        private void ProcessDelete()
        {
            if (dgvMain.CurrentRow == null || dgvMain.CurrentRow.Index < 0)
            {
                MessageBox.Show("Оберіть рядок для видалення!", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Видалити цей запис?", "Підтвердження",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                ExecuteDeleteLogic(dgvMain.CurrentRow);
        }

        private void ProcessUpdate()
        {
            if (dgvMain.CurrentRow == null || dgvMain.CurrentRow.Index < 0)
            {
                MessageBox.Show("Оберіть рядок для редагування!", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ExecuteUpdateLogic(dgvMain.CurrentRow);
            btnUpdate.Text = "Зберегти зміни";
        }

        protected virtual void ResetForm() { }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void BaseForm_Load(object sender, EventArgs e) { }
        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}