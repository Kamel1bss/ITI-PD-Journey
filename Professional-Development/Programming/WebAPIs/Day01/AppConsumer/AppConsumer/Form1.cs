namespace AppConsumer;

public partial class Form1 : Form
{
    HttpClient _client;
    public Form1()
    {
        InitializeComponent();
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://localhost:7189/");

    }

    private void Form1_Load(object sender, EventArgs e)
    {
        
        var response = _client.GetAsync("api/courses").Result;
        if (response.IsSuccessStatusCode)
        {
            var Courses = response.Content.ReadAsAsync<List<Course>>().Result;
            dgv_courses.DataSource = Courses;
        }

    }

    private void btn_add_Click(object sender, EventArgs e)
    {
        Course course = new Course()
        {
            id = int.Parse(txt_id.Text),
            crs_name = txt_name.Text,
            crs_desc = txt_desc.Text,
            duration = int.Parse(txt_duration.Text)
        };

        var response = _client.PostAsJsonAsync("api/courses", course).Result;
        if (response.IsSuccessStatusCode)
        {
            Form1_Load(sender, e);
            txt_desc.Text = txt_id.Text = txt_name.Text = txt_duration.Text  = "";
            MessageBox.Show("Course added successfully!");
        }

    }
}
