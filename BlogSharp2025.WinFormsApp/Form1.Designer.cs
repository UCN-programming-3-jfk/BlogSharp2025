namespace BlogSharp2025.WinFormsApp;

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
        splitContainer1 = new SplitContainer();
        lstAuthors = new ListBox();
        btnDelete = new Button();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 0);
        splitContainer1.Margin = new Padding(5);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(lstAuthors);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(btnDelete);
        splitContainer1.Size = new Size(702, 387);
        splitContainer1.SplitterDistance = 234;
        splitContainer1.SplitterWidth = 6;
        splitContainer1.TabIndex = 0;
        // 
        // lstAuthors
        // 
        lstAuthors.Dock = DockStyle.Fill;
        lstAuthors.FormattingEnabled = true;
        lstAuthors.ItemHeight = 25;
        lstAuthors.Location = new Point(0, 0);
        lstAuthors.Margin = new Padding(5);
        lstAuthors.Name = "lstAuthors";
        lstAuthors.Size = new Size(234, 387);
        lstAuthors.TabIndex = 0;
        lstAuthors.SelectedIndexChanged += LstAuthors_SelectedIndexChanged;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(320, 335);
        btnDelete.Margin = new Padding(5);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(118, 38);
        btnDelete.TabIndex = 0;
        btnDelete.Text = "&Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += BtnDelete_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(11F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(702, 387);
        Controls.Add(splitContainer1);
        Font = new Font("Segoe UI", 14F);
        Margin = new Padding(5);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private ListBox lstAuthors;
    private Button btnDelete;
}
