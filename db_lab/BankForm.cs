using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace db_lab
{
    public partial class BankForm : BaseForm
    {
        private int selectedIdNbu;

        public BankForm()
        {
            InitializeComponent();
            LoadData("bank");
        }

        protected override void AddRecord()
        {
            if (string.IsNullOrWhiteSpace(txtIdNbu.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Код НБУ та Назва банку є обов'язковими", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtIdNbu.Text, out int idNbu))
            {
                MessageBox.Show("Код НБУ має бути цілим числом", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO public.bank (id_nbu, name, address) VALUES (@idNbu, @name, @address)";

            var parameters = new Dictionary<string, object>
            {
                { "@idNbu", idNbu },
                { "@name", txtName.Text.Trim() },
                { "@address", string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim() }
            };

            if (ExecuteQuery(query, parameters))
            {
                ResetForm();
            }
        }

        protected override void ExecuteUpdateLogic(DataGridViewRow row)
        {
            if (row.Cells["id_nbu"].Value == null || row.Cells["id_nbu"].Value == DBNull.Value) return;

            selectedIdNbu = Convert.ToInt32(row.Cells["id_nbu"].Value);

            txtIdNbu.Text = selectedIdNbu.ToString();
            txtIdNbu.Enabled = false;

            txtName.Text = row.Cells["name"].Value.ToString();
            txtAddress.Text = row.Cells["address"].Value?.ToString();
        }

        protected override void SaveRecord()
        {
            var p = new Dictionary<string, object>
            {
                { "@name", txtName.Text.Trim() },
                { "@address", string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim() },
                { "@id", selectedIdNbu }
            };

            if (ExecuteQuery("UPDATE public.bank SET name=@name, address=@address WHERE id_nbu=@id", p))
            {
                ResetForm();
            }
        }

        protected override void ExecuteDeleteLogic(DataGridViewRow row)
        {
            if (row.Cells["id_nbu"].Value == null || row.Cells["id_nbu"].Value == DBNull.Value) return;

            var parameters = new Dictionary<string, object>
            {
                { "@id", Convert.ToInt32(row.Cells["id_nbu"].Value) }
            };
            ExecuteQuery("DELETE FROM public.bank WHERE id_nbu = @id", parameters);
        }

        private void ResetForm()
        {
            txtIdNbu.Enabled = true;
            txtIdNbu.Clear();
            txtName.Clear();
            txtAddress.Clear();
        }

        private void BankForm_Load(object sender, EventArgs e) { }
        private void btnAdd_Click_1(object sender, EventArgs e) => AddRecord();

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}