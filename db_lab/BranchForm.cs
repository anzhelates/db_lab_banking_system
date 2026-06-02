using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace db_lab
{
    public partial class BranchForm : BaseForm
    {
        private int selectedBranchNumber;
        private int selectedBankId;

        public BranchForm()
        {
            InitializeComponent();
            LoadData("branch");
            string bankQuery = "SELECT id_nbu, name FROM public.bank";
            LoadComboBox(cmbBank, bankQuery, "name", "id_nbu");
        }

        protected override void AddRecord()
        {
            if (string.IsNullOrWhiteSpace(txtBranchNumber.Text) || cmbBank.SelectedValue == null)
            {
                MessageBox.Show("Номер відділення та банк є обов'язковими!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtBranchNumber.Text, out int branchNumber))
            {
                MessageBox.Show("Номер відділення має бути цілим числом!", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO public.branch (branch_number, address, bank_id_nbu) " +
                           "VALUES (@number, @address, @bankId)";

            var parameters = new Dictionary<string, object>
            {
                { "@number", branchNumber },
                { "@address", txtAddress.Text },
                { "@bankId", Convert.ToInt32(cmbBank.SelectedValue) }
            };

            if (ExecuteQuery(query, parameters))
            {
                ResetForm();
            }
        }

        protected override void ExecuteUpdateLogic(DataGridViewRow row)
        {
            if (row.Cells["branch_number"].Value == null || row.Cells["bank_id_nbu"].Value == null) return;

            selectedBranchNumber = Convert.ToInt32(row.Cells["branch_number"].Value);
            selectedBankId = Convert.ToInt32(row.Cells["bank_id_nbu"].Value);

            txtBranchNumber.Text = selectedBranchNumber.ToString();
            cmbBank.SelectedValue = selectedBankId;
            txtAddress.Text = row.Cells["address"].Value?.ToString();

            txtBranchNumber.Enabled = false;
            cmbBank.Enabled = false;
        }

        protected override void SaveRecord()
        {
            var p = new Dictionary<string, object>
            {
                { "@address", string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim() },
                { "@bankId", selectedBankId },
                { "@branchNum", selectedBranchNumber }
            };

            string query = "UPDATE public.branch SET address=@address WHERE bank_id_nbu=@bankId AND branch_number=@branchNum";

            if (ExecuteQuery(query, p))
            {
                ResetForm();
            }
        }

        protected override void ExecuteDeleteLogic(DataGridViewRow row)
        {
            if (row.Cells["branch_number"].Value == null || row.Cells["bank_id_nbu"].Value == null) return;

            var parameters = new Dictionary<string, object>
            {
                { "@bankId", Convert.ToInt32(row.Cells["bank_id_nbu"].Value) },
                { "@branchNum", Convert.ToInt32(row.Cells["branch_number"].Value) }
            };
            ExecuteQuery("DELETE FROM public.branch WHERE bank_id_nbu = @bankId AND branch_number = @branchNum", parameters);
        }

        private void ResetForm()
        {
            txtBranchNumber.Enabled = true;
            cmbBank.Enabled = true;

            txtBranchNumber.Clear();
            txtAddress.Clear();
            cmbBank.SelectedIndex = -1;
        }

        private void lblBranchNumber_Click(object sender, EventArgs e) { }
        private void lblBank_Click(object sender, EventArgs e) { }
        private void BranchForm_Load(object sender, EventArgs e) { }
        private void btnAdd_Click_1(object sender, EventArgs e) => AddRecord();

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}