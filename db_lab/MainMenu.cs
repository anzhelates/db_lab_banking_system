using System;
using System.Windows.Forms;

namespace db_lab
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void OpenForm<T>() where T : Form, new()
        {
            T form = new T();
            form.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e) => OpenForm<QueryForm>();
        private void btnAccount_Click(object sender, EventArgs e) => OpenForm<AccountForm>();
        private void btnBank_Click(object sender, EventArgs e) => OpenForm<BankForm>();
        private void btnBranch_Click(object sender, EventArgs e) => OpenForm<BranchForm>();
        private void btnClient_Click(object sender, EventArgs e) => OpenForm<ClientForm>();
        private void btnEmployee_Click(object sender, EventArgs e) => OpenForm<EmployeeForm>();
        private void btnManager_Click(object sender, EventArgs e) => OpenForm<ManagerForm>();
        private void btnService_Click(object sender, EventArgs e) => OpenForm<ServiceForm>();
        private void btnServiceProvision_Click(object sender, EventArgs e) => OpenForm<ServiceProvisionForm>();

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}