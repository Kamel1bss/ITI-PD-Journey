using System;
using System.Drawing;
using System.Windows.Forms;
namespace Lab08_WinForms;
public partial class Form10 : Form
{
    private TabControl tabControl;

    // Font tab controls
    private RadioButton rbTimesNewRoman;
    private RadioButton rbArial;
    private RadioButton rbCourier;

    // Size tab controls
    private RadioButton rbSize16;
    private RadioButton rbSize20;
    private RadioButton rbSize24;

    // Color tab controls
    private Button btnSelectColor;
    private Panel colorPreview;

    // Text tab controls
    private Label lblOldValue;
    private TextBox txtOldValue;
    private Label lblNewValue;
    private TextBox txtNewValue;

    // Dialog buttons
    private Button btnOK;
    private Button btnCancel;

    // Selected values
    private string selectedFontName;
    private float selectedFontSize;
    private Color selectedColor;
    private string selectedText;

    // Original values
    private string originalText;
    private Font originalFont;
    private Color originalColor;

    public Font SelectedFont => new Font(selectedFontName, selectedFontSize);
    public Color SelectedColor => selectedColor;
    public string SelectedText => selectedText;

    public Form10(string currentText, Font currentFont, Color currentColor)
    {
        InitializeComponent();

        // Store original values
        originalText = currentText;
        originalFont = currentFont;
        originalColor = currentColor;

        // Initialize selected values with current values
        selectedFontName = currentFont.FontFamily.Name;
        selectedFontSize = currentFont.Size;
        selectedColor = currentColor;
        selectedText = currentText;

        InitializeCustomComponents();
        LoadCurrentSettings();
    }

    private void InitializeCustomComponents()
    {
        // Form settings
        this.Text = "Format Company Name";
        this.ClientSize = new Size(450, 350);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = FormStartPosition.CenterParent;

        // TabControl
        tabControl = new TabControl();
        tabControl.Location = new Point(10, 10);
        tabControl.Size = new Size(430, 280);

        // Create tab pages
        TabPage fontPage = CreateFontTab();
        TabPage sizePage = CreateSizeTab();
        TabPage colorPage = CreateColorTab();
        TabPage textPage = CreateTextTab();

        tabControl.TabPages.Add(fontPage);
        tabControl.TabPages.Add(sizePage);
        tabControl.TabPages.Add(colorPage);
        tabControl.TabPages.Add(textPage);

        this.Controls.Add(tabControl);

        // OK Button
        btnOK = new Button();
        btnOK.Text = "OK";
        btnOK.Location = new Point(260, 300);
        btnOK.Size = new Size(80, 30);
        btnOK.DialogResult = DialogResult.OK;
        btnOK.Click += BtnOK_Click;
        this.Controls.Add(btnOK);

        // Cancel Button
        btnCancel = new Button();
        btnCancel.Text = "Cancel";
        btnCancel.Location = new Point(350, 300);
        btnCancel.Size = new Size(80, 30);
        btnCancel.DialogResult = DialogResult.Cancel;
        this.Controls.Add(btnCancel);

        this.AcceptButton = btnOK;
        this.CancelButton = btnCancel;
    }

    private TabPage CreateFontTab()
    {
        TabPage page = new TabPage("Font");

        rbTimesNewRoman = new RadioButton();
        rbTimesNewRoman.Text = "Times New Roman";
        rbTimesNewRoman.Location = new Point(20, 30);
        rbTimesNewRoman.Size = new Size(200, 30);
        rbTimesNewRoman.CheckedChanged += (s, e) => { if (rbTimesNewRoman.Checked) selectedFontName = "Times New Roman"; };

        rbArial = new RadioButton();
        rbArial.Text = "Arial";
        rbArial.Location = new Point(20, 70);
        rbArial.Size = new Size(200, 30);
        rbArial.CheckedChanged += (s, e) => { if (rbArial.Checked) selectedFontName = "Arial"; };

        rbCourier = new RadioButton();
        rbCourier.Text = "Courier";
        rbCourier.Location = new Point(20, 110);
        rbCourier.Size = new Size(200, 30);
        rbCourier.CheckedChanged += (s, e) => { if (rbCourier.Checked) selectedFontName = "Courier New"; };

        page.Controls.Add(rbTimesNewRoman);
        page.Controls.Add(rbArial);
        page.Controls.Add(rbCourier);

        return page;
    }

    private TabPage CreateSizeTab()
    {
        TabPage page = new TabPage("Size");

        rbSize16 = new RadioButton();
        rbSize16.Text = "16";
        rbSize16.Location = new Point(20, 30);
        rbSize16.Size = new Size(200, 30);
        rbSize16.CheckedChanged += (s, e) => { if (rbSize16.Checked) selectedFontSize = 16; };

        rbSize20 = new RadioButton();
        rbSize20.Text = "20";
        rbSize20.Location = new Point(20, 70);
        rbSize20.Size = new Size(200, 30);
        rbSize20.CheckedChanged += (s, e) => { if (rbSize20.Checked) selectedFontSize = 20; };

        rbSize24 = new RadioButton();
        rbSize24.Text = "24";
        rbSize24.Location = new Point(20, 110);
        rbSize24.Size = new Size(200, 30);
        rbSize24.CheckedChanged += (s, e) => { if (rbSize24.Checked) selectedFontSize = 24; };

        page.Controls.Add(rbSize16);
        page.Controls.Add(rbSize20);
        page.Controls.Add(rbSize24);

        return page;
    }

    private TabPage CreateColorTab()
    {
        TabPage page = new TabPage("Color");

        btnSelectColor = new Button();
        btnSelectColor.Text = "Select Color";
        btnSelectColor.Location = new Point(20, 30);
        btnSelectColor.Size = new Size(120, 35);
        btnSelectColor.Click += BtnSelectColor_Click;

        colorPreview = new Panel();
        colorPreview.Location = new Point(150, 30);
        colorPreview.Size = new Size(100, 35);
        colorPreview.BorderStyle = BorderStyle.FixedSingle;
        colorPreview.BackColor = selectedColor;

        page.Controls.Add(btnSelectColor);
        page.Controls.Add(colorPreview);

        return page;
    }

    private TabPage CreateTextTab()
    {
        TabPage page = new TabPage("Text");

        lblOldValue = new Label();
        lblOldValue.Text = "Old Value:";
        lblOldValue.Location = new Point(20, 30);
        lblOldValue.Size = new Size(100, 20);

        txtOldValue = new TextBox();
        txtOldValue.Location = new Point(20, 55);
        txtOldValue.Size = new Size(380, 25);
        txtOldValue.ReadOnly = true;
        txtOldValue.BackColor = SystemColors.Control;

        lblNewValue = new Label();
        lblNewValue.Text = "New Value:";
        lblNewValue.Location = new Point(20, 100);
        lblNewValue.Size = new Size(100, 20);

        txtNewValue = new TextBox();
        txtNewValue.Location = new Point(20, 125);
        txtNewValue.Size = new Size(380, 25);
        txtNewValue.TextChanged += (s, e) => selectedText = txtNewValue.Text;

        page.Controls.Add(lblOldValue);
        page.Controls.Add(txtOldValue);
        page.Controls.Add(lblNewValue);
        page.Controls.Add(txtNewValue);

        return page;
    }

    private void LoadCurrentSettings()
    {
        // Set font radio button
        if (originalFont.FontFamily.Name == "Times New Roman")
            rbTimesNewRoman.Checked = true;
        else if (originalFont.FontFamily.Name == "Arial")
            rbArial.Checked = true;
        else if (originalFont.FontFamily.Name == "Courier New" || originalFont.FontFamily.Name == "Courier")
            rbCourier.Checked = true;
        else
            rbTimesNewRoman.Checked = true;

        // Set size radio button
        if (originalFont.Size == 16)
            rbSize16.Checked = true;
        else if (originalFont.Size == 20)
            rbSize20.Checked = true;
        else if (originalFont.Size == 24)
            rbSize24.Checked = true;
        else
            rbSize16.Checked = true;

        // Set color preview
        colorPreview.BackColor = originalColor;

        // Set text values
        txtOldValue.Text = originalText;
        txtNewValue.Text = originalText;
    }

    private void BtnSelectColor_Click(object sender, EventArgs e)
    {
        using (ColorDialog colorDialog = new ColorDialog())
        {
            colorDialog.Color = selectedColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
                colorPreview.BackColor = selectedColor;
            }
        }
    }

    private void BtnOK_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(selectedText))
        {
            MessageBox.Show("Please enter a company name.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.DialogResult = DialogResult.None;
        }
    }
}