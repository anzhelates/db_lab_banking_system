using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace db_lab
{
    public partial class ManagerForm : BaseForm
    {
        private string editingPassport = "";
        private bool _isLoading = false;

        public ManagerForm()
        {
            InitializeComponent();
            LoadData("manager");

            string branchQuery = @"
                SELECT (bank_id_nbu || '-' || branch_number) AS branch_key, 
                       ('Банк №' || bank_id_nbu || ', Відділення №' || branch_number || ' (' || COALESCE(address, 'Без адреси') || ')') AS branch_info 
                FROM public.branch";
            LoadComboBox(cmbBranch, branchQuery, "branch_info", "branch_key");

            cmbBranch.SelectedIndexChanged += CmbBranch_SelectedIndexChanged;
            UpdateEmployeeComboBox();
        }

        private void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEmployeeComboBox();
        }

        private void UpdateEmployeeComboBox()
        {
            if (cmbBranch.SelectedValue != null)
            {
                string[] branchKeys = cmbBranch.SelectedValue.ToString().Split('-');
                if (branchKeys.Length == 2 && int.TryParse(branchKeys[0], out int bankId) && int.TryParse(branchKeys[1], out int branchNum))
                {
                    string employeeQuery = $"SELECT passport_number, full_name FROM public.employee WHERE branch_bank_id = {bankId} AND branch_number = {branchNum}";
                    LoadComboBox(cmbEmployee, employeeQuery, "full_name", "passport_number");
                    cmbEmployee.SelectedIndex = -1;
                }
            }
        }

        protected override void AddRecord()
        {
            if (cmbBranch.SelectedValue == null || cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Відділення та співробітник є обов'язковими!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] branchKeys = cmbBranch.SelectedValue.ToString().Split('-');
            if (branchKeys.Length != 2 || !int.TryParse(branchKeys[0], out int bankId) || !int.TryParse(branchKeys[1], out int branchNum))
            {
                MessageBox.Show("Помилка вибору відділення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = @"INSERT INTO public.manager (passport_number, branch_bank_id, branch_number, phone_number) 
                            VALUES (@passport, @bankId, @branchNum, @phone)";

            var parameters = new Dictionary<string, object>
            {
                { "@passport", cmbEmployee.SelectedValue.ToString() },
                { "@bankId", bankId },
                { "@branchNum", branchNum },
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

            string branchKey = $"{row.Cells["branch_bank_id"].Value}-{row.Cells["branch_number"].Value}";
            cmbBranch.SelectedValue = branchKey;

            cmbEmployee.SelectedValue = editingPassport;
            cmbEmployee.Enabled = false;

            txtPhone.Text = row.Cells["phone_number"].Value?.ToString();
        }

        protected override void SaveRecord()
        {
            if (cmbBranch.SelectedValue == null) return;

            string[] branchKeys = cmbBranch.SelectedValue.ToString().Split('-');
            if (branchKeys.Length != 2 || !int.TryParse(branchKeys[0], out int bankId) || !int.TryParse(branchKeys[1], out int branchNum))
            {
                MessageBox.Show("Помилка вибору відділення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = @"UPDATE public.manager 
                            SET branch_bank_id = @bankId, branch_number = @branchNum, phone_number = @phone 
                            WHERE passport_number = @passport";

            var parameters = new Dictionary<string, object>
            {
                { "@bankId", bankId },
                { "@branchNum", branchNum },
                { "@phone", string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim() },
                { "@passport", editingPassport }
            };

            if (ExecuteQuery(query, parameters))
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
            ExecuteQuery("DELETE FROM public.manager WHERE passport_number = @passport", parameters);
        }

        private void ResetForm()
        {
            _isLoading = true;
            try
            {
                cmbEmployee.Enabled = true;
                txtPhone.Clear();
                editingPassport = "";

                string branchQuery = @"
                    SELECT (bank_id_nbu || '-' || branch_number) AS branch_key, 
                           ('Банк №' || bank_id_nbu || ', Відділення №' || branch_number || ' (' || COALESCE(address, 'Без адреси') || ')') AS branch_info 
                    FROM public.branch";
                LoadComboBox(cmbBranch, branchQuery, "branch_info", "branch_key");
                cmbBranch.SelectedIndex = -1;

                cmbEmployee.SelectedIndex = -1;
            }
            finally
            {
                _isLoading = false;
            }

            LoadData("manager");
        }

        private void ManagerForm_Load(object sender, EventArgs e) { }
        private void btnAdd_Click_1(object sender, EventArgs e) => AddRecord();

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}