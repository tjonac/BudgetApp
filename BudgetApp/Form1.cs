namespace BudgetApp
{
    public partial class Form1 : Form
    {
        BindingSource expensesBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExpensesDAO expensesDAO = new ExpensesDAO();
            expensesBindingSource.DataSource = expensesDAO.getAllExpenses();

            dataGridView1.DataSource = expensesBindingSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExpensesDAO expensesDAO = new ExpensesDAO();
            expensesBindingSource.DataSource = expensesDAO.SearchDate(textBox1.Text, textBox2.Text);

            dataGridView1.DataSource = expensesBindingSource;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Expenses expense = new Expenses
            {
                Date = InDate.Value,
                Value = float.Parse(InVal.Text),
                Category = InCat.Text,
                Description = InDesc.Text

            };
            ExpensesDAO expensesDAO = new ExpensesDAO();
            int result = expensesDAO.addOneAlbum(expense);
            MessageBox.Show(result + " new row(s) inserted");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
        }

        private void button4_Click(object sender, EventArgs e)
        {

      
        }


    }
}
