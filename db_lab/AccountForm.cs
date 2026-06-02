using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace db_lab
{
    public partial class AccountForm : BaseForm
    {
        private string selectedIban = "";

        public AccountForm()
        {
            InitializeComponent();
            LoadData("account");
            LoadComboBox(cmbClient,
                "SELECT passport_number, full_name FROM public.client",
                "full_name", "passport_number");
            cmbCurrency.Items.AddRange(new object[] { "UAH", "USD", "EUR" });
            cmbCurrency.SelectedIndex = 0;

            dgvMain.SelectionChanged += (s, e) =>
            {
                var val = dgvMain.CurrentRow?.Cells["iban"].Value;
                if (val == null || val == DBNull.Value) return;
                selectedIban = val.ToString();
                lblSelectedAccount.Text = $"Обраний рахунок: {selectedIban}";
                LoadSubFormData(selectedIban);
            };
        }

        private void LoadSubFormData(string iban)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                const string query = @"
                    SELECT ca.client_passport AS ""Паспорт"",
                           c.full_name AS ""Власник рахунку""
                    FROM public.client_account ca
                    JOIN public.client c ON ca.client_passport = c.passport_number
                    WHERE ca.account_iban = @iban";
                using var adapter = new NpgsqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@iban", iban);
                var dt = new DataTable();
                adapter.Fill(dt);
                dgvClientAccounts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void AddRecord()
        {
            if (string.IsNullOrWhiteSpace(txtIban.Text))
            {
                MessageBox.Show("Поле IBAN є обов'язковим", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtBalance.Text, out decimal bal))
            {
                MessageBox.Show("Баланс має бути числовим", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var p = new Dictionary<string, object>
            {
                { "@iban", txtIban.Text.Trim() },
                { "@balance", bal },
                { "@currency", cmbCurrency.SelectedItem.ToString() },
                { "@expiryDate", dtpExpiryDate.Value.Date }
            };

            if (ExecuteQuery(
                "INSERT INTO public.account (iban, balance, currency, expiry_date) " +
                "VALUES (@iban, @balance, @currency, @expiryDate)", p))
                ResetForm();
        }

        protected override void ExecuteUpdateLogic(DataGridViewRow row)
        {
            var val = row.Cells["iban"].Value;
            if (val == null || val == DBNull.Value) return;

            selectedIban = val.ToString();

            txtIban.Text = selectedIban;
            txtIban.Enabled = false;
            txtBalance.Text = row.Cells["balance"].Value.ToString();
            cmbCurrency.SelectedItem = row.Cells["currency"].Value.ToString();
            dtpExpiryDate.Value = row.Cells["expiry_date"].Value is DateOnly d
                ? d.ToDateTime(TimeOnly.MinValue)
                : Convert.ToDateTime(row.Cells["expiry_date"].Value);
        }

        protected override void SaveRecord()
        {
            if (!decimal.TryParse(txtBalance.Text, out decimal balance))
            {
                MessageBox.Show("Баланс має бути числовим", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var p = new Dictionary<string, object>
            {
                { "@balance", balance },
                { "@currency", cmbCurrency.SelectedItem.ToString() },
                { "@expiry", dtpExpiryDate.Value.Date },
                { "@iban", selectedIban }
            };

            if (ExecuteQuery(
                "UPDATE public.account " +
                "SET balance=@balance, currency=@currency, expiry_date=@expiry " +
                "WHERE iban=@iban", p))
                ResetForm();
        }

        protected override void ExecuteDeleteLogic(DataGridViewRow row)
        {
            if (row.Cells["iban"].Value == null) return;
            ExecuteQuery(
                "DELETE FROM public.account WHERE iban = @iban",
                new Dictionary<string, object>
                    { { "@iban", row.Cells["iban"].Value.ToString() } });
        }

        private void btnLinkClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIban))
            {
                MessageBox.Show("Оберіть рахунок у таблиці", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbClient.SelectedValue == null)
            {
                MessageBox.Show("Оберіть клієнта зі списку", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(
                    "INSERT INTO public.client_account (client_passport, account_iban) " +
                    "VALUES (@passport, @iban)", conn);
                cmd.Parameters.AddWithValue("@passport", cmbClient.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@iban", selectedIban);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Клієнта додано!", "Успіх",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSubFormData(selectedIban);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            txtIban.Enabled = true;
            txtIban.Clear();
            txtBalance.Text = "0,00";
            cmbCurrency.SelectedIndex = 0;
            dtpExpiryDate.Value = DateTime.Now;
            selectedIban = "";
            lblSelectedAccount.Text = "Обраний рахунок: —";
            LoadData("account");
        }

        private void AccountForm_Load(object sender, EventArgs e) { }
        private void btnAdd_Click_1(object sender, EventArgs e) => AddRecord();

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}