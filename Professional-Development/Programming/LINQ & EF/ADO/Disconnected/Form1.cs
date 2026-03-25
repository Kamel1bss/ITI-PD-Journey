using Microsoft.Data.SqlClient;
using System.Data;

namespace Disconnected
{
    public partial class Form1 : Form
    {
        SqlDataAdapter _adapter;
        SqlConnection _connection;
        DataSet _db;

        SqlCommand _selectCommand;
        SqlCommand _insertCommand;
        SqlCommand _updateCommmand;
        SqlCommand _deleteCommmand;

        public Form1()
        {
            _adapter = new SqlDataAdapter();
            _connection = new SqlConnection();
            _connection.ConnectionString = "Data Source=.; Initial catalog=Temp; Integrated Security=True; TrustServerCertificate = True;";
            _db = new DataSet();

            // select command
            _selectCommand = new SqlCommand();
            _selectCommand.Connection = _connection;
            _selectCommand.CommandText = "Select * from Employee";
            _adapter.SelectCommand = _selectCommand;

            // insert command
            _insertCommand = new SqlCommand();
            _insertCommand.Connection = _connection;
            _insertCommand.CommandText = @"
                                            INSERT INTO Employee(Name, Department) 
                                            VALUES(@Name, @Department);
                                            SELECT Id, Name, Department FROM Employee WHERE Id = SCOPE_IDENTITY();
                                            ";
            _insertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord; _insertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 0, "Name"));
            _insertCommand.Parameters.Add(new SqlParameter("@Department", SqlDbType.VarChar, 0, "Department"));
            _adapter.InsertCommand = _insertCommand;

            // update command
            _updateCommmand = new SqlCommand();
            _updateCommmand.Connection = _connection;
            _updateCommmand.CommandText = "Update Employee Set Name = @Name, Department = @Department where Id = @Id";
            _updateCommmand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 0, "Id") { SourceVersion = DataRowVersion.Original });
            _updateCommmand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 0, "Name"));
            _updateCommmand.Parameters.Add(new SqlParameter("@Department", SqlDbType.VarChar, 0, "Department"));
            _adapter.UpdateCommand = _updateCommmand;

            // delete command
            _deleteCommmand = new SqlCommand();
            _deleteCommmand.Connection = _connection;
            _deleteCommmand.CommandText = "Delete from Employee where Id = @Id";
            _deleteCommmand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 0, "Id"));
            _adapter.DeleteCommand = _deleteCommmand;

            InitializeComponent();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index;
                DataRow row = _db.Tables[0].Rows[index];

                // Populate textboxes
                textBox2.Text = row["Name"].ToString();
                textBox3.Text = row["Department"].ToString();
            }
        }
        // Display
        private void button1_Click(object sender, EventArgs e)
        {
            _connection.Open();
            _adapter.Fill(_db);
            DataTable dt = _db.Tables[0];

            int lastId = 0;
            if (dt.Rows.Count > 0)
            {
                lastId = dt.AsEnumerable().Max(r => r.Field<int>("Id"));
            }

            dt.Columns["Id"].AutoIncrement = true;
            dt.Columns["Id"].AutoIncrementSeed = lastId + 1;
            dt.Columns["Id"].AutoIncrementStep = 1;
            _connection.Close();
            dataGridView1.DataSource = _db.Tables[0];

        }

        // Add
        private void button2_Click(object sender, EventArgs e)
        {
            DataRow _row = _db.Tables[0].NewRow();
            _row[1] = textBox2.Text;
            _row[2] = textBox3.Text;

            _db.Tables[0].Rows.Add(_row);
            textBox2.Text = textBox3.Text = string.Empty;

        }


        // update
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index;
                DataRow row = _db.Tables[0].Rows[index];

                // Update the row values
                row["Name"] = textBox2.Text;
                row["Department"] = textBox3.Text;

                // Mark the row as modified so that DataAdapter knows to update DB
                if (row.RowState == DataRowState.Unchanged)
                    row.SetModified(); // This ensures Update() will apply changes
            }
        }

        // delete
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index;

                _db.Tables[0].Rows[index].Delete();
            }
        }

        // Apply to DB
        private void button3_Click(object sender, EventArgs e)
        {
            _connection.Open();
            _adapter.Update(_db);
            _connection.Close();
            MessageBox.Show("Database Updated!");
        }
    }
}
