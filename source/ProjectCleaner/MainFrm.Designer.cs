namespace ucoruh
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnRunCleaner = new System.Windows.Forms.Button();
            this.listboxSearchFolders = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGitignorePath = new System.Windows.Forms.TextBox();
            this.btnSelectGitIgnore = new System.Windows.Forms.Button();
            this.chkboxSolutionBasedDeletion = new System.Windows.Forms.CheckBox();
            this.chkRepoBasedDeletion = new System.Windows.Forms.CheckBox();
            this.chkDoxygenOutputDeletion = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnStopCleaner = new System.Windows.Forms.Button();
            this.btnOpenToptal = new System.Windows.Forms.Button();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolPercentage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStartedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolFinished = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolDuration = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerDurationUpdater = new System.Windows.Forms.Timer(this.components);
            this.btnCleanForm = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.BackColor = System.Drawing.SystemColors.Control;
            this.btnRemove.Enabled = false;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(771, 131);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(156, 29);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(771, 94);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(156, 29);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.Location = new System.Drawing.Point(771, 57);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(156, 29);
            this.btnMoveDown.TabIndex = 10;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = false;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Location = new System.Drawing.Point(771, 20);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(156, 29);
            this.btnMoveUp.TabIndex = 9;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = false;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnRunCleaner
            // 
            this.btnRunCleaner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunCleaner.BackColor = System.Drawing.Color.Lime;
            this.btnRunCleaner.Enabled = false;
            this.btnRunCleaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunCleaner.Location = new System.Drawing.Point(3, 295);
            this.btnRunCleaner.Name = "btnRunCleaner";
            this.btnRunCleaner.Size = new System.Drawing.Size(354, 43);
            this.btnRunCleaner.TabIndex = 8;
            this.btnRunCleaner.Text = "Run Cleaner";
            this.btnRunCleaner.UseVisualStyleBackColor = false;
            this.btnRunCleaner.Click += new System.EventHandler(this.btnCleanProjects_Click);
            this.btnRunCleaner.MouseEnter += new System.EventHandler(this.btnRunCleaner_MouseEnter);
            this.btnRunCleaner.MouseLeave += new System.EventHandler(this.btnRunCleaner_MouseLeave);
            // 
            // listboxSearchFolders
            // 
            this.listboxSearchFolders.AllowDrop = true;
            this.listboxSearchFolders.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listboxSearchFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxSearchFolders.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxSearchFolders.FormattingEnabled = true;
            this.listboxSearchFolders.ItemHeight = 16;
            this.listboxSearchFolders.Location = new System.Drawing.Point(3, 16);
            this.listboxSearchFolders.Name = "listboxSearchFolders";
            this.listboxSearchFolders.Size = new System.Drawing.Size(759, 209);
            this.listboxSearchFolders.TabIndex = 15;
            this.listboxSearchFolders.DragDrop += new System.Windows.Forms.DragEventHandler(this.listboxSearchFolders_DragDrop);
            this.listboxSearchFolders.DragEnter += new System.Windows.Forms.DragEventHandler(this.listboxSearchFolders_DragEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listboxSearchFolders);
            this.groupBox1.Location = new System.Drawing.Point(0, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 228);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Folders";
            // 
            // txtGitignorePath
            // 
            this.txtGitignorePath.AllowDrop = true;
            this.txtGitignorePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGitignorePath.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.txtGitignorePath.Location = new System.Drawing.Point(3, 246);
            this.txtGitignorePath.Name = "txtGitignorePath";
            this.txtGitignorePath.ReadOnly = true;
            this.txtGitignorePath.Size = new System.Drawing.Size(624, 24);
            this.txtGitignorePath.TabIndex = 17;
            this.txtGitignorePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtGitignorePath_DragDrop);
            this.txtGitignorePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtGitignorePath_DragEnter);
            // 
            // btnSelectGitIgnore
            // 
            this.btnSelectGitIgnore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectGitIgnore.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelectGitIgnore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectGitIgnore.Location = new System.Drawing.Point(633, 246);
            this.btnSelectGitIgnore.Name = "btnSelectGitIgnore";
            this.btnSelectGitIgnore.Size = new System.Drawing.Size(129, 43);
            this.btnSelectGitIgnore.TabIndex = 18;
            this.btnSelectGitIgnore.Text = "Select .gitignore";
            this.btnSelectGitIgnore.UseVisualStyleBackColor = false;
            this.btnSelectGitIgnore.Click += new System.EventHandler(this.btnSelectGitIgnore_Click);
            // 
            // chkboxSolutionBasedDeletion
            // 
            this.chkboxSolutionBasedDeletion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkboxSolutionBasedDeletion.AutoSize = true;
            this.chkboxSolutionBasedDeletion.Enabled = false;
            this.chkboxSolutionBasedDeletion.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.chkboxSolutionBasedDeletion.Location = new System.Drawing.Point(771, 174);
            this.chkboxSolutionBasedDeletion.Name = "chkboxSolutionBasedDeletion";
            this.chkboxSolutionBasedDeletion.Size = new System.Drawing.Size(141, 20);
            this.chkboxSolutionBasedDeletion.TabIndex = 19;
            this.chkboxSolutionBasedDeletion.Text = "*.sln based deletion";
            this.chkboxSolutionBasedDeletion.UseVisualStyleBackColor = true;
            // 
            // chkRepoBasedDeletion
            // 
            this.chkRepoBasedDeletion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRepoBasedDeletion.AutoSize = true;
            this.chkRepoBasedDeletion.Enabled = false;
            this.chkRepoBasedDeletion.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.chkRepoBasedDeletion.Location = new System.Drawing.Point(771, 200);
            this.chkRepoBasedDeletion.Name = "chkRepoBasedDeletion";
            this.chkRepoBasedDeletion.Size = new System.Drawing.Size(145, 20);
            this.chkRepoBasedDeletion.TabIndex = 20;
            this.chkRepoBasedDeletion.Text = "repo based deletion";
            this.chkRepoBasedDeletion.UseVisualStyleBackColor = true;
            // 
            // chkDoxygenOutputDeletion
            // 
            this.chkDoxygenOutputDeletion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDoxygenOutputDeletion.AutoSize = true;
            this.chkDoxygenOutputDeletion.Checked = true;
            this.chkDoxygenOutputDeletion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoxygenOutputDeletion.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.chkDoxygenOutputDeletion.Location = new System.Drawing.Point(771, 226);
            this.chkDoxygenOutputDeletion.Name = "chkDoxygenOutputDeletion";
            this.chkDoxygenOutputDeletion.Size = new System.Drawing.Size(169, 20);
            this.chkDoxygenOutputDeletion.TabIndex = 21;
            this.chkDoxygenOutputDeletion.Text = "doxygen output deletion";
            this.chkDoxygenOutputDeletion.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(0, 344);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(940, 238);
            this.txtLog.TabIndex = 22;
            this.txtLog.Text = "";
            // 
            // btnStopCleaner
            // 
            this.btnStopCleaner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopCleaner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStopCleaner.Enabled = false;
            this.btnStopCleaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopCleaner.Location = new System.Drawing.Point(363, 295);
            this.btnStopCleaner.Name = "btnStopCleaner";
            this.btnStopCleaner.Size = new System.Drawing.Size(129, 43);
            this.btnStopCleaner.TabIndex = 23;
            this.btnStopCleaner.Text = "Stop Cleaner";
            this.btnStopCleaner.UseVisualStyleBackColor = false;
            this.btnStopCleaner.Click += new System.EventHandler(this.btnStopCleaning_Click);
            // 
            // btnOpenToptal
            // 
            this.btnOpenToptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenToptal.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpenToptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenToptal.Location = new System.Drawing.Point(633, 295);
            this.btnOpenToptal.Name = "btnOpenToptal";
            this.btnOpenToptal.Size = new System.Drawing.Size(129, 43);
            this.btnOpenToptal.TabIndex = 24;
            this.btnOpenToptal.Text = "Open Gitignore Builder";
            this.btnOpenToptal.UseVisualStyleBackColor = false;
            this.btnOpenToptal.Click += new System.EventHandler(this.btnOpenToptal_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolProgressBar,
            this.toolPercentage,
            this.toolStartedTime,
            this.toolFinished,
            this.toolDuration});
            this.statusStripMain.Location = new System.Drawing.Point(0, 585);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(942, 22);
            this.statusStripMain.TabIndex = 27;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolProgressBar
            // 
            this.toolProgressBar.Name = "toolProgressBar";
            this.toolProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolPercentage
            // 
            this.toolPercentage.Name = "toolPercentage";
            this.toolPercentage.Size = new System.Drawing.Size(30, 17);
            this.toolPercentage.Text = "% --";
            // 
            // toolStartedTime
            // 
            this.toolStartedTime.ForeColor = System.Drawing.Color.Red;
            this.toolStartedTime.Name = "toolStartedTime";
            this.toolStartedTime.Size = new System.Drawing.Size(94, 17);
            this.toolStartedTime.Text = "Started: [--:--:--]";
            // 
            // toolFinished
            // 
            this.toolFinished.ForeColor = System.Drawing.Color.Blue;
            this.toolFinished.Name = "toolFinished";
            this.toolFinished.Size = new System.Drawing.Size(101, 17);
            this.toolFinished.Text = "Finished: [--:--:--]";
            // 
            // toolDuration
            // 
            this.toolDuration.ForeColor = System.Drawing.Color.Green;
            this.toolDuration.Name = "toolDuration";
            this.toolDuration.Size = new System.Drawing.Size(103, 17);
            this.toolDuration.Text = "Duration: [--:--:--]";
            // 
            // timerDurationUpdater
            // 
            this.timerDurationUpdater.Interval = 1000;
            this.timerDurationUpdater.Tick += new System.EventHandler(this.timerDurationUpdater_Tick);
            // 
            // btnCleanForm
            // 
            this.btnCleanForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCleanForm.BackColor = System.Drawing.Color.Yellow;
            this.btnCleanForm.Enabled = false;
            this.btnCleanForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCleanForm.Location = new System.Drawing.Point(498, 295);
            this.btnCleanForm.Name = "btnCleanForm";
            this.btnCleanForm.Size = new System.Drawing.Size(129, 43);
            this.btnCleanForm.TabIndex = 28;
            this.btnCleanForm.Text = "Clean Form";
            this.btnCleanForm.UseVisualStyleBackColor = false;
            this.btnCleanForm.Click += new System.EventHandler(this.btnCleanScreen_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(942, 607);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnCleanForm);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.btnOpenToptal);
            this.Controls.Add(this.btnStopCleaner);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.chkDoxygenOutputDeletion);
            this.Controls.Add(this.chkRepoBasedDeletion);
            this.Controls.Add(this.chkboxSolutionBasedDeletion);
            this.Controls.Add(this.btnSelectGitIgnore);
            this.Controls.Add(this.txtGitignorePath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnRunCleaner);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Cleaner";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnRunCleaner;
        private System.Windows.Forms.ListBox listboxSearchFolders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGitignorePath;
        private System.Windows.Forms.Button btnSelectGitIgnore;
        private System.Windows.Forms.CheckBox chkboxSolutionBasedDeletion;
        private System.Windows.Forms.CheckBox chkRepoBasedDeletion;
        private System.Windows.Forms.CheckBox chkDoxygenOutputDeletion;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnStopCleaner;
        private System.Windows.Forms.Button btnOpenToptal;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripProgressBar toolProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolPercentage;
        private System.Windows.Forms.ToolStripStatusLabel toolStartedTime;
        private System.Windows.Forms.ToolStripStatusLabel toolFinished;
        private System.Windows.Forms.ToolStripStatusLabel toolDuration;
        private System.Windows.Forms.Timer timerDurationUpdater;
        private System.Windows.Forms.Button btnCleanForm;
    }
}

