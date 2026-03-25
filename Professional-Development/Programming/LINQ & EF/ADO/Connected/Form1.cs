using Microsoft.Data.SqlClient;

namespace Connected
{
    public partial class Form1 : Form
    {
        SqlConnection _connection;
        SqlCommand _command;
        public Form1()
        {
            InitializeComponent();
            _connection = new SqlConnection();
            _connection.ConnectionString = "Data source=.; Initial catalog=ITI_ALEX; Integrated security=True; TrustServerCertificate=True;";
            _command = new SqlCommand();
            _command.Connection = _connection;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader reader;
            _command.CommandText = "Select Id, Name from Department";
            listBox1.Items.Clear();
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                string row = (int)reader[0] + "\t" + reader[1].ToString();
                listBox1.Items.Add(row);

            }
            reader.Close();
        }

        // insert
        private void button2_Click(object sender, EventArgs e)
        {
            string query = $"insert into Department values({textBox1.Text}, '{textBox2.Text}')";
            ExecuteDML(query, "inserted");
        }

        // update
        private void button3_Click(object sender, EventArgs e)
        {
            string query = $"update Department set Name = '{textBox2.Text}' where Id = {textBox1.Text}";
            ExecuteDML(query, "updated");
        }

        // delete
        private void button4_Click(object sender, EventArgs e)
        {
            string query = $"Delete from Department where Name = '{textBox2.Text}'";
            ExecuteDML(query, "deleted");
        }

        private void ExecuteDML(string query, string state)
        {
            _command.CommandText = query;
            int affected = _command.ExecuteNonQuery();
            textBox1.Text = textBox2.Text = "";
            MessageBox.Show($"{affected} rows {state}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _connection.Open();
            label4.ForeColor = Color.Green;
            label4.Text = "Connected";
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = false; // connect
            button6.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _connection.Close();
            label4.ForeColor = Color.Red;
            label4.Text = "Disconnected";
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true; // connect
            button6.Enabled = false;
        }
    }
}
