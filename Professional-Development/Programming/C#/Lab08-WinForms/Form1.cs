using System;
using System.Drawing;
using System.Windows.Forms;
namespace Lab08_WinForms;

public partial class Form1 : Form
{
    // Company name properties
    private string companyName = "Company Name";
    private Font companyFont = new Font("Times New Roman", 16);
    private Color companyColor = Color.Black;

    private Label lblCompanyName;
    public Form1()
    {
        InitializeComponent();
        InitializeCustomComponents();
    }

    private void InitializeCustomComponents()
    {
        // Create menu
        MenuStrip menuStrip = new MenuStrip();
        ToolStripMenuItem formatMenu = new ToolStripMenuItem("Format");
        ToolStripMenuItem companyNameMenuItem = new ToolStripMenuItem("Company Name");

        companyNameMenuItem.Click += CompanyNameMenuItem_Click;
        formatMenu.DropDownItems.Add(companyNameMenuItem);
        menuStrip.Items.Add(formatMenu);

        this.MainMenuStrip = menuStrip;
        this.Controls.Add(menuStrip);

        // Create company name label
        lblCompanyName = new Label();
        lblCompanyName.Text = companyName;
        lblCompanyName.Font = companyFont;
        lblCompanyName.ForeColor = companyColor;
        lblCompanyName.AutoSize = true;
        lblCompanyName.Location = new Point(200, 150);

        this.Controls.Add(lblCompanyName);
    }

    private void CompanyNameMenuItem_Click(object sender, EventArgs e)
    {
        // Create and show the format dialog
        using (Form10 dialog = new Form10(companyName, companyFont, companyColor))
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Apply changes
                companyName = dialog.SelectedText;
                companyFont = dialog.SelectedFont;
                companyColor = dialog.SelectedColor;

                // Update label
                lblCompanyName.Text = companyName;
                lblCompanyName.Font = companyFont;
                lblCompanyName.ForeColor = companyColor;
            }
            // If Cancel, no changes are applied
        }
    }
}