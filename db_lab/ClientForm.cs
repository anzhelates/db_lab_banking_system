using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace db_lab
{
    public partial class ClientForm : BaseForm
    {
        private string selectedPassport = "";
        private string editingPassport = "";

        public ClientForm()
        {
            InitializeComponent();
            LoadData("client");
            string accountQuery = "SELECT iban FROM public.account";
            LoadComboBox(cmbAccount, accountQuery, "iban", "iban");
            dgvMain.SelectionChanged += DgvMain_SelectionChanged;
        }

        private void DgvMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow != null && dgvMain.CurrentRow.Cells["passport_number"].Value != null)
            {
                selectedPassport = dgvMain.CurrentRow.Cells["passport_number"].Value.ToString();
                lblSelectedClient.Text = $"Обрано клієнта (Паспорт): {selectedPassport}";
                LoadSubFormData(selectedPassport);
            }
            else
            {
                selectedPassport = "";
                lblSelectedClient.Text = "Клієнта не обрано";
            }
        }

        private void LoadSubFormData(string passport)
        {
            try
            {
                using (NpgsqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT ca.account_iban AS ""Номер рахунку"", 
                               a.balance AS ""Баланс"", 
                               a.currency AS ""Валюта""
                        FROM public.client_account ca
                        JOIN public.account a ON ca.account_iban = a.iban
                        WHERE ca.client_passport = @passport";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@passport", passport);
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvClientAccounts.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження рахунків клієнта: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void AddRecord()
        {
            if (string.IsNullOrWhiteSpace(txtPassport.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Паспорт та ПІБ є обов'язковими!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO public.client (passport_number, full_name, phone) VALUES (@passport, @name, @phone)";
            var parameters = new Dictionary<string, object>
            {
                { "@passport", txtPassport.Text.Trim() },
                { "@name", txtFullName.Text.Trim() },
                { "@phone", string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim() }
            };

            if (ExecuteQuery(query, parameters))
            {
                ResetForm();
            }
        }

        protected override void ExecuteUpdateLogic(DataGridViewRow row)
        {
            if (row.Cells["passport_number"].Value == null) return;

            editingPassport = row.Cells["passport_number"].Value.ToString();
            txtPassport.Text = editingPassport;
            txtPassport.Enabled = false;

            txtFullName.Text = row.Cells["full_name"].Value.ToString();
            txtPhone.Text = row.Cells["phone"].Value?.ToString();
        }

        protected override void SaveRecord()
        {
            var p = new Dictionary<string, object>
            {
                { "@name", txtFullName.Text.Trim() },
                { "@phone", string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim() },
                { "@passport", editingPassport }
            };

            if (ExecuteQuery("UPDATE public.client SET full_name=@name, phone=@phone WHERE passport_number=@passport", p))
            {
                ResetForm();
            }
        }

        protected override void ExecuteDeleteLogic(DataGridViewRow row)
        {
            if (row.Cells["passport_number"].Value == null) return;

            var parameters = new Dictionary<string, object>
            {
                { "@passport", row.Cells["passport_number"].Value.ToString() }
            };
            ExecuteQuery("DELETE FROM public.client WHERE passport_number = @passport", parameters);
        }

        private void ResetForm()
        {
            txtPassport.Enabled = true;
            txtPassport.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            editingPassport = "";
            LoadData("client");
        }

        private void btnLinkAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedPassport))
            {
                MessageBox.Show("Спочатку оберіть клієнта у таблиці!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbAccount.SelectedValue == null)
            {
                MessageBox.Show("Оберіть рахунок для прив'язки!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO public.client_account (client_passport, account_iban) VALUES (@passport, @iban)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@passport", selectedPassport);
                        cmd.Parameters.AddWithValue("@iban", cmbAccount.SelectedValue.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Рахунок успішно прив'язано до цього клієнта", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSubFormData(selectedPassport);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Цей рахунок вже прив'язаний до клієнта або виникла помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientForm_Load(object sender, EventArgs e) { }
        private void btnAdd_Click_1(object sender, EventArgs e) => AddRecord();
        private void grpSubForm_Enter(object sender, EventArgs e) { }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}