namespace AppConsumer;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        dgv_courses = new DataGridView();
        txt_id = new TextBox();
        txt_name = new TextBox();
        txt_duration = new TextBox();
        txt_desc = new TextBox();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        btn_add = new Button();
        ((System.ComponentModel.ISupportInitialize)dgv_courses).BeginInit();
        SuspendLayout();
        // 
        // dgv_courses
        // 
        dgv_courses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv_courses.Location = new Point(42, 235);
        dgv_courses.Name = "dgv_courses";
        dgv_courses.RowHeadersWidth = 51;
        dgv_courses.Size = new Size(703, 188);
        dgv_courses.TabIndex = 0;
        // 
        // txt_id
        // 
        txt_id.Location = new Point(210, 66);
        txt_id.Name = "txt_id";
        txt_id.Size = new Size(125, 27);
        txt_id.TabIndex = 1;
        // 
        // txt_name
        // 
        txt_name.Location = new Point(210, 115);
        txt_name.Name = "txt_name";
        txt_name.Size = new Size(125, 27);
        txt_name.TabIndex = 2;
        // 
        // txt_duration
        // 
        txt_duration.Location = new Point(488, 112);
        txt_duration.Name = "txt_duration";
        txt_duration.Size = new Size(125, 27);
        txt_duration.TabIndex = 3;
        // 
        // txt_desc
        // 
        txt_desc.Location = new Point(488, 66);
        txt_desc.Name = "txt_desc";
        txt_desc.Size = new Size(125, 27);
        txt_desc.TabIndex = 4;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(134, 73);
        label1.Name = "label1";
        label1.Size = new Size(22, 20);
        label1.TabIndex = 5;
        label1.Text = "Id";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(111, 115);
        label2.Name = "label2";
        label2.Size = new Size(70, 20);
        label2.TabIndex = 6;
        label2.Text = "crs_name";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(394, 73);
        label3.Name = "label3";
        label3.Size = new Size(63, 20);
        label3.TabIndex = 7;
        label3.Text = "crs_desc";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(394, 115);
        label4.Name = "label4";
        label4.Size = new Size(65, 20);
        label4.TabIndex = 8;
        label4.Text = "duration";
        // 
        // btn_add
        // 
        btn_add.Location = new Point(134, 185);
        btn_add.Name = "btn_add";
        btn_add.Size = new Size(94, 29);
        btn_add.TabIndex = 9;
        btn_add.Text = "Add";
        btn_add.UseVisualStyleBackColor = true;
        btn_add.Click += btn_add_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(btn_add);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(txt_desc);
        Controls.Add(txt_duration);
        Controls.Add(txt_name);
        Controls.Add(txt_id);
        Controls.Add(dgv_courses);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)dgv_courses).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView dgv_courses;
    private TextBox txt_id;
    private TextBox txt_name;
    private TextBox txt_duration;
    private TextBox txt_desc;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Button btn_add;
}
