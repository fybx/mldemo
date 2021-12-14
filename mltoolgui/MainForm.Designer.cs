namespace mltoolgui;

partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiDropboxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewDataset = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewModel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDropboxLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoadDataset = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoadModel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDropboxActions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEvaluate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.lblDatasetFile = new System.Windows.Forms.Label();
            this.lblModelPath = new System.Windows.Forms.Label();
            this.@__lblDataset = new System.Windows.Forms.Label();
            this.@__lblModel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rtbEvaluate = new System.Windows.Forms.RichTextBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDropboxNew,
            this.tsmiDropboxLoad,
            this.tsmiDropboxActions,
            this.tsmiExit});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(604, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // tsmiDropboxNew
            // 
            this.tsmiDropboxNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewDataset,
            this.tsmiNewModel});
            this.tsmiDropboxNew.Name = "tsmiDropboxNew";
            this.tsmiDropboxNew.Size = new System.Drawing.Size(43, 20);
            this.tsmiDropboxNew.Text = "New";
            // 
            // tsmiNewDataset
            // 
            this.tsmiNewDataset.Name = "tsmiNewDataset";
            this.tsmiNewDataset.Size = new System.Drawing.Size(116, 22);
            this.tsmiNewDataset.Text = "Data set";
            this.tsmiNewDataset.Click += new System.EventHandler(this.tsmiNewDataset_Click);
            // 
            // tsmiNewModel
            // 
            this.tsmiNewModel.Name = "tsmiNewModel";
            this.tsmiNewModel.Size = new System.Drawing.Size(116, 22);
            this.tsmiNewModel.Text = "Model";
            this.tsmiNewModel.Click += new System.EventHandler(this.tsmiNewModel_Click);
            // 
            // tsmiDropboxLoad
            // 
            this.tsmiDropboxLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadDataset,
            this.tsmiLoadModel});
            this.tsmiDropboxLoad.Name = "tsmiDropboxLoad";
            this.tsmiDropboxLoad.Size = new System.Drawing.Size(45, 20);
            this.tsmiDropboxLoad.Text = "Load";
            // 
            // tsmiLoadDataset
            // 
            this.tsmiLoadDataset.Name = "tsmiLoadDataset";
            this.tsmiLoadDataset.Size = new System.Drawing.Size(116, 22);
            this.tsmiLoadDataset.Text = "Data set";
            this.tsmiLoadDataset.Click += new System.EventHandler(this.tsmiLoadDataset_Click);
            // 
            // tsmiLoadModel
            // 
            this.tsmiLoadModel.Name = "tsmiLoadModel";
            this.tsmiLoadModel.Size = new System.Drawing.Size(116, 22);
            this.tsmiLoadModel.Text = "Model";
            this.tsmiLoadModel.Click += new System.EventHandler(this.tsmiLoadModel_Click);
            // 
            // tsmiDropboxActions
            // 
            this.tsmiDropboxActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTrain,
            this.tsmiEvaluate});
            this.tsmiDropboxActions.Name = "tsmiDropboxActions";
            this.tsmiDropboxActions.Size = new System.Drawing.Size(59, 20);
            this.tsmiDropboxActions.Text = "Actions";
            // 
            // tsmiTrain
            // 
            this.tsmiTrain.Name = "tsmiTrain";
            this.tsmiTrain.Size = new System.Drawing.Size(118, 22);
            this.tsmiTrain.Text = "Train";
            this.tsmiTrain.Click += new System.EventHandler(this.tsmiTrain_Click);
            // 
            // tsmiEvaluate
            // 
            this.tsmiEvaluate.Name = "tsmiEvaluate";
            this.tsmiEvaluate.Size = new System.Drawing.Size(118, 22);
            this.tsmiEvaluate.Text = "Evaluate";
            this.tsmiEvaluate.Click += new System.EventHandler(this.tsmiEvaluate_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(38, 20);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.btnEvaluate);
            this.splitContainer.Panel1.Controls.Add(this.btnTrain);
            this.splitContainer.Panel1.Controls.Add(this.lblDatasetFile);
            this.splitContainer.Panel1.Controls.Add(this.lblModelPath);
            this.splitContainer.Panel1.Controls.Add(this.@__lblDataset);
            this.splitContainer.Panel1.Controls.Add(this.@__lblModel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.textBox1);
            this.splitContainer.Panel2.Controls.Add(this.rtbEvaluate);
            this.splitContainer.Size = new System.Drawing.Size(604, 427);
            this.splitContainer.SplitterDistance = 113;
            this.splitContainer.TabIndex = 1;
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluate.Location = new System.Drawing.Point(93, 75);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(75, 23);
            this.btnEvaluate.TabIndex = 12;
            this.btnEvaluate.Text = "Evaluate";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrain.Location = new System.Drawing.Point(12, 75);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(75, 23);
            this.btnTrain.TabIndex = 11;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // lblDatasetFile
            // 
            this.lblDatasetFile.AutoSize = true;
            this.lblDatasetFile.Location = new System.Drawing.Point(134, 36);
            this.lblDatasetFile.Name = "lblDatasetFile";
            this.lblDatasetFile.Size = new System.Drawing.Size(0, 15);
            this.lblDatasetFile.TabIndex = 10;
            // 
            // lblModelPath
            // 
            this.lblModelPath.AutoSize = true;
            this.lblModelPath.Location = new System.Drawing.Point(134, 11);
            this.lblModelPath.Name = "lblModelPath";
            this.lblModelPath.Size = new System.Drawing.Size(0, 15);
            this.lblModelPath.TabIndex = 9;
            // 
            // __lblDataset
            // 
            this.@__lblDataset.AutoSize = true;
            this.@__lblDataset.Location = new System.Drawing.Point(12, 36);
            this.@__lblDataset.Name = "__lblDataset";
            this.@__lblDataset.Size = new System.Drawing.Size(113, 15);
            this.@__lblDataset.TabIndex = 8;
            this.@__lblDataset.Text = "Current data set file:";
            // 
            // __lblModel
            // 
            this.@__lblModel.AutoSize = true;
            this.@__lblModel.Location = new System.Drawing.Point(12, 11);
            this.@__lblModel.Name = "__lblModel";
            this.@__lblModel.Size = new System.Drawing.Size(106, 15);
            this.@__lblModel.TabIndex = 7;
            this.@__lblModel.Text = "Current model file:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.ForeColor = System.Drawing.Color.Turquoise;
            this.textBox1.Location = new System.Drawing.Point(0, 285);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "enter a number";
            this.textBox1.Size = new System.Drawing.Size(602, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "beep boop?";
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // rtbEvaluate
            // 
            this.rtbEvaluate.BackColor = System.Drawing.Color.Black;
            this.rtbEvaluate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbEvaluate.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbEvaluate.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbEvaluate.ForeColor = System.Drawing.Color.LightCoral;
            this.rtbEvaluate.Location = new System.Drawing.Point(0, 0);
            this.rtbEvaluate.Name = "rtbEvaluate";
            this.rtbEvaluate.ReadOnly = true;
            this.rtbEvaluate.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbEvaluate.Size = new System.Drawing.Size(602, 307);
            this.rtbEvaluate.TabIndex = 0;
            this.rtbEvaluate.Text = "beep boop? boop beep.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(604, 451);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "mltoolgui";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private MenuStrip menuStrip;
    private ToolStripMenuItem tsmiDropboxNew;
    private ToolStripMenuItem tsmiNewDataset;
    private ToolStripMenuItem tsmiNewModel;
    private ToolStripMenuItem tsmiDropboxLoad;
    private ToolStripMenuItem tsmiLoadDataset;
    private ToolStripMenuItem tsmiLoadModel;
    private ToolStripMenuItem tsmiDropboxActions;
    private ToolStripMenuItem tsmiTrain;
    private ToolStripMenuItem tsmiEvaluate;
    private ToolStripMenuItem tsmiExit;
    private SplitContainer splitContainer;
    private Button btnEvaluate;
    private Button btnTrain;
    private Label lblDatasetFile;
    private Label lblModelPath;
    private Label __lblDataset;
    private Label __lblModel;
    private RichTextBox rtbEvaluate;
    private TextBox textBox1;
}