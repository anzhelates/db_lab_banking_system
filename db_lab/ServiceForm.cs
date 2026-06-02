using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace db_lab
{
    public partial class ServiceForm : BaseForm
    {
        public ServiceForm()
        {
            InitializeComponent();
            LoadData("service");
        }

        protected override void AddRecord()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Назва послуги є обов'язковою для заповнення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCost.Text, out decimal cost))
            {
                MessageBox.Show("Вартість має бути числовим значенням (наприклад, 150,50)!", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO public.service (name, cost) VALUES (@name, @cost)";

            var parameters = new Dictionary<string, object>
            {
                { "@name", txtName.Text.Trim() },
                { "@cost", cost }
            };

            if (ExecuteQuery(query, parameters))
            {
                txtName.Clear();
                txtCost.Clear();
                LoadData("service");
            }
        }

        protected override void ExecuteDeleteLogic(DataGridViewRow row)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@id", Convert.ToInt32(row.Cells["service_code"].Value) }
            };

            if (ExecuteQuery("DELETE FROM public.service WHERE service_code = @id", parameters))
            {
                LoadData("service");
            }
        }

        protected override void ExecuteUpdateLogic(DataGridViewRow row)
        {
            txtName.Text = row.Cells["name"].Value?.ToString();
            txtCost.Text = row.Cells["cost"].Value?.ToString();
        }

        protected override void SaveRecord()
        {
            if (dgvMain.CurrentRow == null) return;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Назва послуги є обов'язковою для заповнення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCost.Text, out decimal cost))
            {
                MessageBox.Show("Вартість має бути числовим значенням (наприклад, 150,50)!", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int serviceCode = Convert.ToInt32(dgvMain.CurrentRow.Cells["service_code"].Value);

            string query = "UPDATE public.service SET name = @name, cost = @cost WHERE service_code = @id";

            var parameters = new Dictionary<string, object>
            {
                { "@name", txtName.Text.Trim() },
                { "@cost", cost },
                { "@id", serviceCode }
            };

            if (ExecuteQuery(query, parameters))
            {
                txtName.Clear();
                txtCost.Clear();
                LoadData("service");
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}