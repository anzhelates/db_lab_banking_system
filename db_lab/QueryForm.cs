using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace db_lab
{
    public partial class QueryForm : BaseForm
    {
        private int currentQueryIndex = 0;

        private readonly string[] queryDescriptions = new string[]
        {
            "1. ПІБ працівників, які обслуговують клієнтів з кількістю рахунків не менше:",
            "2. ПІБ працівників, які надавали послуги клієнтам, що мають рахунок у (UAH/USD/EUR):",
            "3. Назви банків, у яких загальна кількість працівників більше:",
            "4. ПІБ та телефони клієнтів, рахунки яких діють після дати (YYYY-MM-DD):",
            "5. ПІБ та телефони клієнтів, яким надавав послуги працівник (ПІБ):",
            "6. Номери та адреси відділень, де середня вартість послуг не перевищує:",
            "7. ПІБ працівників з такою ж множиною клієнтів, що й заданий працівник (ПІБ):",
            "8. ПІБ клієнтів, які отримали всі послуги у відділенні (Код банку, № відділення):"
        };

        public QueryForm()
        {
            InitializeComponent();
            dgvMain.Visible = false;
            UpdateUI();
        }

        private void UpdateUI()
        {
            lblQueryDescription.Text = queryDescriptions[currentQueryIndex];
            txtParameter.Clear();
            dgvMain.Visible = false;

            btnPrev.Enabled = (currentQueryIndex > 0);
            btnNext.Enabled = (currentQueryIndex < queryDescriptions.Length - 1);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentQueryIndex > 0)
            {
                currentQueryIndex--;
                UpdateUI();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentQueryIndex < queryDescriptions.Length - 1)
            {
                currentQueryIndex++;
                UpdateUI();
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string query = "";
            var parameters = new Dictionary<string, object>();
            string paramValue = txtParameter.Text.Trim();

            if (string.IsNullOrEmpty(paramValue))
            {
                MessageBox.Show("Будь ласка, введіть параметр!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (currentQueryIndex)
            {
                case 0:
                    if (!int.TryParse(paramValue, out int minAccounts)) { ShowError(); return; }
                    query = @"
                        SELECT DISTINCT e.full_name AS ""ПІБ Працівника""
                        FROM public.employee e
                        JOIN public.service_provision sp ON e.passport_number = sp.employee_passport
                        WHERE sp.client_passport IN (
                            SELECT client_passport 
                            FROM public.client_account 
                            GROUP BY client_passport 
                            HAVING COUNT(account_iban) >= @p1
                        );";
                    parameters.Add("@p1", minAccounts);
                    break;

                case 1:
                    if (!int.TryParse(paramValue, out int minSubordinates)) { ShowError(); return; }
                    query = @"
                        SELECT DISTINCT e.full_name AS ""ПІБ Працівника""
                        FROM public.employee e
                        JOIN public.service_provision sp ON e.passport_number = sp.employee_passport
                        WHERE sp.client_passport IN (
                            SELECT ca.client_passport
                            FROM public.client_account ca
                            JOIN public.account a ON ca.account_iban = a.iban
                            WHERE a.currency = @p1
                        );";
                    parameters.Add("@p1", minSubordinates);
                    break;

                case 2:
                    if (!int.TryParse(paramValue, out int minEmployees)) { ShowError(); return; }
                    query = @"
                        SELECT b.name AS ""Назва банку""
                        FROM public.bank b
                        JOIN public.employee e ON b.id_nbu = e.branch_bank_id
                        GROUP BY b.id_nbu, b.name
                        HAVING COUNT(e.passport_number) > @p1;";
                    parameters.Add("@p1", minEmployees);
                    break;

                case 3:
                    if (!DateTime.TryParse(paramValue, out DateTime targetDate)) { ShowError(); return; }
                    query = @"
                        SELECT DISTINCT c.full_name AS ""ПІБ Клієнта"", c.phone AS ""Телефон""
                        FROM public.client c
                        JOIN public.client_account ca ON c.passport_number = ca.client_passport
                        JOIN public.account a ON ca.account_iban = a.iban
                        WHERE a.expiry_date > @p1;";
                    parameters.Add("@p1", targetDate);
                    break;

                case 4:
                    query = @"
                        SELECT DISTINCT c.full_name AS ""ПІБ Клієнта"", c.phone AS ""Телефон""
                        FROM public.client c
                        JOIN public.service_provision sp ON c.passport_number = sp.client_passport
                        WHERE sp.employee_passport IN (
                            SELECT passport_number FROM public.employee WHERE full_name = @p1
                        );";
                    parameters.Add("@p1", paramValue);
                    break;

                case 5:
                    if (!decimal.TryParse(paramValue.Replace('.', ','), out decimal minAvgCost)) { ShowError(); return; }
                    query = @"
                        SELECT b.bank_id_nbu AS ""Код Банку"", b.branch_number AS ""Номер відділення"", b.address AS ""Адреса"", AVG(s.cost) AS ""Середня вартість""
                        FROM public.service_provision sp
                        JOIN public.employee e ON sp.employee_passport = e.passport_number
                        JOIN public.service s ON sp.service_id = s.service_code
                        JOIN public.branch b ON e.branch_bank_id = b.bank_id_nbu AND e.branch_number = b.branch_number
                        GROUP BY b.bank_id_nbu, b.branch_number, b.address
                        HAVING AVG(s.cost) <= @p1;";
                    parameters.Add("@p1", minAvgCost);
                    break;

                case 6:
                    query = @"
                        SELECT e.full_name AS ""ПІБ Працівника""
                        FROM public.employee e
                        WHERE e.passport_number<>(SELECT passport_number FROM public.employee WHERE full_name = @p1 LIMIT 1)
                          AND NOT EXISTS(
                              SELECT sp1.client_passport FROM public.service_provision sp1
                              WHERE sp1.employee_passport = (SELECT passport_number FROM public.employee WHERE full_name = @p1)
                                AND sp1.client_passport NOT IN (
                                    SELECT sp2.client_passport FROM public.service_provision sp2
                                    WHERE sp2.employee_passport = e.passport_number
                                )
                          )
                          AND NOT EXISTS(
                              SELECT sp2.client_passport FROM public.service_provision sp2
                              WHERE sp2.employee_passport = e.passport_number
                                AND sp2.client_passport NOT IN (
                                    SELECT sp1.client_passport FROM public.service_provision sp1
                                    WHERE sp1.employee_passport = (SELECT passport_number FROM public.employee WHERE full_name = @p1)
                                )
                          );";
                    parameters.Add("@p1", paramValue);
                    break;

                case 7:
                    string[] parts = paramValue.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 2 || !int.TryParse(parts[0], out int bankId) || !int.TryParse(parts[1], out int branchNum))
                    {
                        MessageBox.Show("Введіть два числа через кому (наприклад: 300001, 1)", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    query = @"
                        SELECT c.full_name AS ""ПІБ Клієнта""
                        FROM public.client c
                        WHERE NOT EXISTS (
                            SELECT s.service_code FROM public.service s
                            WHERE s.service_code NOT IN (
                                SELECT sp.service_id 
                                FROM public.service_provision sp
                                JOIN public.employee e ON sp.employee_passport = e.passport_number
                                WHERE sp.client_passport = c.passport_number
                                  AND e.branch_bank_id = @p1 
                                  AND e.branch_number = @p2
                            )
                        );";
                    parameters.Add("@p1", bankId);
                    parameters.Add("@p2", branchNum);
                    break;
            }

            ExecuteAndDisplay(query, parameters);
        }

        public DataTable GetDataTable(string query, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        private void ShowError()
        {
            MessageBox.Show("Некоректний формат параметра", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ExecuteAndDisplay(string query, Dictionary<string, object> parameters)
        {
            try
            {
                DataTable result = GetDataTable(query, parameters);
                if (result != null)
                {
                    dgvMain.DataSource = result;
                    dgvMain.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка БД: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {

        }
    }
}