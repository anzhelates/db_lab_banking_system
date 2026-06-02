using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace db_lab
{
    public partial class EmployeeForm : BaseForm
    {
        private string editingPassport = "";

        public EmployeeForm()
        {
            InitializeComponent();
            LoadData("employee");

            string branchQuery = @"
                SELECT (bank_id_nbu || '-' || branch_number) AS branch_key, 
                       ('Банк №' || bank_id_nbu || ', Відділення №' || branch_number || ' (' || COALESCE(address, 'Без адреси') || ')') AS branch_info 
                FROM public.branch";
            LoadComboBox(cmbBranch, branchQuery, "branch_info", "branch_key");

            string supervisorQuery = "SELECT passport_number, full_name FROM public.employee";
            LoadComboBox(cmbSupervisor, supervisorQuery, "full_name", "passport_number");
            cmbSupervisor.SelectedIndex = -1;
        }

        protected override void AddRecord()
        {
            if (string.IsNullOrWhiteSpace(txtPassport.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtPosition.Text) ||
                cmbBranch.SelectedValue == null)
            {
                MessageBox.Show("Паспорт, ПІБ, Посада та Відділення є обов'язковими", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] branchKeys = cmbBranch.SelectedValue.ToString().Split('-');
            if (branchKeys.Length != 2 || !int.TryParse(branchKeys[0], out int bankId) || !int.TryParse(branchKeys[1], out int branchNum))
            {
                MessageBox.Show("Помилка вибору відділення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = @"INSERT INTO public.employee (passport_number, full_name, position, branch_bank_id, branch_number, supervisor_passport) 
                            VALUES (@passport, @name, @position, @bankId, @branchNum, @supervisor)";

            var parameters = new Dictionary<string, object>
            {
                { "@passport", txtPassport.Text.Trim() },
                { "@name", txtFullName.Text.Trim() },
                { "@position", txtPosition.Text.Trim() },
                { "@bankId", bankId },
                { "@branchNum", branchNum },
                { "@supervisor", cmbSupervisor.SelectedValue == null ? null : cmbSupervisor.SelectedValue.ToString() }
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
            txtPosition.Text = row.Cells["position"].Value?.ToString();

            string branchKey = $"{row.Cells["branch_bank_id"].Value}-{row.Cells["branch_number"].Value}";
            cmbBranch.SelectedValue = branchKey;
            cmbSupervisor.SelectedValue = row.Cells["supervisor_passport"].Value?.ToString();
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

            string query = @"UPDATE public.employee 
                            SET full_name = @name, position = @position, branch_bank_id = @bankId, branch_number = @branchNum, supervisor_passport = @supervisor 
                            WHERE passport_number = @passport";

            var parameters = new Dictionary<string, object>
            {
                { "@name", txtFullName.Text.Trim() },
                { "@position", txtPosition.Text.Trim() },
                { "@bankId", bankId },
                { "@branchNum", branchNum },
                { "@supervisor", cmbSupervisor.SelectedValue == null ? null : cmbSupervisor.SelectedValue.ToString() },
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
            ExecuteQuery("DELETE FROM public.employee WHERE passport_number = @passport", parameters);
        }

        private void ResetForm()
        {
            txtPassport.Enabled = true;
            txtPassport.Clear();
            txtFullName.Clear();
            txtPosition.Clear();
            editingPassport = "";

            string branchQuery = @"
                SELECT (bank_id_nbu || '-' || branch_number) AS branch_key, 
                       ('Банк №' || bank_id_nbu || ', Відділення №' || branch_number || ' (' || COALESCE(address, 'Без адреси') || ')') AS branch_info 
                FROM public.branch";
            LoadComboBox(cmbBranch, branchQuery, "branch_info", "branch_key");
            cmbBranch.SelectedIndex = -1;

            string supervisorQuery = "SELECT passport_number, full_name FROM public.employee";
            LoadComboBox(cmbSupervisor, supervisorQuery, "full_name", "passport_number");
            cmbSupervisor.SelectedIndex = -1;

            LoadData("employee");
        }

        private void EmployeeForm_Load(object sender, EventArgs e) { }
        private void btnAdd_Click_1(object sender, EventArgs e) => AddRecord();

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}