using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace db_lab
{
    public partial class ServiceProvisionForm : BaseForm
    {
        public ServiceProvisionForm()
        {
            InitializeComponent();
            LoadData("service_provision");

            string employeeQuery = "SELECT passport_number, full_name FROM public.employee";
            LoadComboBox(cmbEmployee, employeeQuery, "full_name", "passport_number");

            string clientQuery = "SELECT passport_number, full_name FROM public.client";
            LoadComboBox(cmbClient, clientQuery, "full_name", "passport_number");

            string serviceQuery = "SELECT service_code, name FROM public.service";
            LoadComboBox(cmbService, serviceQuery, "name", "service_code");

            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
        }

        protected override void AddRecord()
        {
            if (cmbEmployee.SelectedValue == null || cmbClient.SelectedValue == null || cmbService.SelectedValue == null)
            {
                MessageBox.Show("Будь ласка, оберіть Працівника, Клієнта та Послугу!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO public.service_provision (client_passport, employee_passport, service_id, service_date, service_time) 
                             VALUES (@clientPassport, @employeePassport, @serviceId, @date, @time)";

            var parameters = new Dictionary<string, object>
            {
                { "@clientPassport", cmbClient.SelectedValue.ToString() },
                { "@employeePassport", cmbEmployee.SelectedValue.ToString() },
                { "@serviceId", Convert.ToInt32(cmbService.SelectedValue) },
                { "@date", dtpDate.Value.Date },
                { "@time", dtpTime.Value.TimeOfDay }
            };

            if (ExecuteQuery(query, parameters))
            {
                ResetForm();
            }
        }

        protected override void ExecuteDeleteLogic(DataGridViewRow row)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@id", Convert.ToInt32(row.Cells["service_provision_id"].Value) }
            };

            if (ExecuteQuery("DELETE FROM public.service_provision WHERE service_provision_id = @id", parameters))
            {
                LoadData("service_provision");
            }
        }

        protected override void ExecuteUpdateLogic(DataGridViewRow row)
        {
            cmbEmployee.SelectedValue = row.Cells["employee_passport"].Value?.ToString();
            cmbClient.SelectedValue = row.Cells["client_passport"].Value?.ToString();
            cmbService.SelectedValue = Convert.ToInt32(row.Cells["service_id"].Value);

            if (row.Cells["service_date"].Value is DateOnly dateOnly)
            {
                dtpDate.Value = dateOnly.ToDateTime(TimeOnly.MinValue);
            }
            else
            {
                dtpDate.Value = Convert.ToDateTime(row.Cells["service_date"].Value);
            }

            if (row.Cells["service_time"].Value != null && row.Cells["service_time"].Value != DBNull.Value)
            {
                if (row.Cells["service_time"].Value is TimeOnly timeOnly)
                {
                    dtpTime.Value = DateTime.Today.Add(timeOnly.ToTimeSpan());
                }
                else if (row.Cells["service_time"].Value is TimeSpan ts)
                {
                    dtpTime.Value = DateTime.Today.Add(ts);
                }
            }
        }

        protected override void SaveRecord()
        {
            if (dgvMain.CurrentRow == null) return;

            if (cmbEmployee.SelectedValue == null || cmbClient.SelectedValue == null || cmbService.SelectedValue == null)
            {
                MessageBox.Show("Будь ласка, оберіть Працівника, Клієнта та Послугу!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int provisionId = Convert.ToInt32(dgvMain.CurrentRow.Cells["service_provision_id"].Value);

            string query = @"UPDATE public.service_provision 
                             SET client_passport = @clientPassport, 
                                 employee_passport = @employeePassport, 
                                 service_id = @serviceId, 
                                 service_date = @date, 
                                 service_time = @time 
                             WHERE service_provision_id = @id";

            var parameters = new Dictionary<string, object>
            {
                { "@clientPassport", cmbClient.SelectedValue.ToString() },
                { "@employeePassport", cmbEmployee.SelectedValue.ToString() },
                { "@serviceId", Convert.ToInt32(cmbService.SelectedValue) },
                { "@date", dtpDate.Value.Date },
                { "@time", dtpTime.Value.TimeOfDay },
                { "@id", provisionId }
            };

            if (ExecuteQuery(query, parameters))
            {
                ResetForm();
            }
        }

        private void ResetForm()
        {
            cmbEmployee.SelectedIndex = -1;
            cmbClient.SelectedIndex = -1;
            cmbService.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
            LoadData("service_provision");
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void ServiceProvisionForm_Load(object sender, EventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}