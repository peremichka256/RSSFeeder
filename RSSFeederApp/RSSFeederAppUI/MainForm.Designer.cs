namespace RSSFeederAppUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.settingsDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.reloadButton = new System.Windows.Forms.ToolStripMenuItem();
            this.oneMinuteReloadButton = new System.Windows.Forms.ToolStripMenuItem();
            this.fiveMinuteReloadButton = new System.Windows.Forms.ToolStripMenuItem();
            this.fifteenMinuteReloadButton = new System.Windows.Forms.ToolStripMenuItem();
            this.thirtyMinuteReloadButton = new System.Windows.Forms.ToolStripMenuItem();
            this.oneHourReloadButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.textFormatButton = new System.Windows.Forms.ToolStripMenuItem();
            this.htmlFormatButton = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.feedsListBox = new System.Windows.Forms.ListBox();
            this.feedsUMLTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.RichTextBox();
            this.pubDateLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.reloadTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsDropDownButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(787, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // settingsDropDownButton
            // 
            this.settingsDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadButton,
            this.toolStripMenuItem2});
            this.settingsDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsDropDownButton.Image")));
            this.settingsDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsDropDownButton.Name = "settingsDropDownButton";
            this.settingsDropDownButton.Size = new System.Drawing.Size(80, 22);
            this.settingsDropDownButton.Text = "Настройки";
            // 
            // reloadButton
            // 
            this.reloadButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneMinuteReloadButton,
            this.fiveMinuteReloadButton,
            this.fifteenMinuteReloadButton,
            this.thirtyMinuteReloadButton,
            this.oneHourReloadButton});
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(168, 22);
            this.reloadButton.Text = "Обновлять через";
            // 
            // oneMinuteReloadButton
            // 
            this.oneMinuteReloadButton.Name = "oneMinuteReloadButton";
            this.oneMinuteReloadButton.Size = new System.Drawing.Size(123, 22);
            this.oneMinuteReloadButton.Text = "1 минуту";
            this.oneMinuteReloadButton.Click += new System.EventHandler(this.ReloadButtonClick);
            // 
            // fiveMinuteReloadButton
            // 
            this.fiveMinuteReloadButton.Name = "fiveMinuteReloadButton";
            this.fiveMinuteReloadButton.Size = new System.Drawing.Size(123, 22);
            this.fiveMinuteReloadButton.Text = "5 минут";
            this.fiveMinuteReloadButton.Click += new System.EventHandler(this.ReloadButtonClick);
            // 
            // fifteenMinuteReloadButton
            // 
            this.fifteenMinuteReloadButton.Name = "fifteenMinuteReloadButton";
            this.fifteenMinuteReloadButton.Size = new System.Drawing.Size(123, 22);
            this.fifteenMinuteReloadButton.Text = "15 минут";
            this.fifteenMinuteReloadButton.Click += new System.EventHandler(this.ReloadButtonClick);
            // 
            // thirtyMinuteReloadButton
            // 
            this.thirtyMinuteReloadButton.Name = "thirtyMinuteReloadButton";
            this.thirtyMinuteReloadButton.Size = new System.Drawing.Size(123, 22);
            this.thirtyMinuteReloadButton.Text = "30 минут";
            this.thirtyMinuteReloadButton.Click += new System.EventHandler(this.ReloadButtonClick);
            // 
            // oneHourReloadButton
            // 
            this.oneHourReloadButton.Name = "oneHourReloadButton";
            this.oneHourReloadButton.Size = new System.Drawing.Size(123, 22);
            this.oneHourReloadButton.Text = "60 минут";
            this.oneHourReloadButton.Click += new System.EventHandler(this.ReloadButtonClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textFormatButton,
            this.htmlFormatButton});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem2.Text = "Формат текста";
            // 
            // textFormatButton
            // 
            this.textFormatButton.Name = "textFormatButton";
            this.textFormatButton.Size = new System.Drawing.Size(158, 22);
            this.textFormatButton.Text = "Обычний текст";
            this.textFormatButton.Click += new System.EventHandler(this.TextFormatButtonClick);
            // 
            // htmlFormatButton
            // 
            this.htmlFormatButton.Name = "htmlFormatButton";
            this.htmlFormatButton.Size = new System.Drawing.Size(158, 22);
            this.htmlFormatButton.Text = "HTML";
            this.htmlFormatButton.Click += new System.EventHandler(this.TextFormatButtonClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.feedsListBox);
            this.splitContainer1.Panel1.Controls.Add(this.feedsUMLTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.titleTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.pubDateLabel);
            this.splitContainer1.Panel2.Controls.Add(this.descriptionTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(787, 457);
            this.splitContainer1.SplitterDistance = 408;
            this.splitContainer1.TabIndex = 1;
            // 
            // feedsListBox
            // 
            this.feedsListBox.FormattingEnabled = true;
            this.feedsListBox.Location = new System.Drawing.Point(13, 40);
            this.feedsListBox.Name = "feedsListBox";
            this.feedsListBox.Size = new System.Drawing.Size(392, 407);
            this.feedsListBox.TabIndex = 1;
            this.feedsListBox.Click += new System.EventHandler(this.feedsListBox_Click);
            this.feedsListBox.DoubleClick += new System.EventHandler(this.feedsListBox_DoubleClick);
            // 
            // feedsUMLTextBox
            // 
            this.feedsUMLTextBox.Location = new System.Drawing.Point(12, 9);
            this.feedsUMLTextBox.Name = "feedsUMLTextBox";
            this.feedsUMLTextBox.Size = new System.Drawing.Size(393, 20);
            this.feedsUMLTextBox.TabIndex = 0;
            this.feedsUMLTextBox.TextChanged += new System.EventHandler(this.feedsUMLTextBox_TextChanged);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(14, 40);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(349, 40);
            this.titleTextBox.TabIndex = 6;
            this.titleTextBox.Text = "";
            // 
            // pubDateLabel
            // 
            this.pubDateLabel.AutoSize = true;
            this.pubDateLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pubDateLabel.Location = new System.Drawing.Point(11, 12);
            this.pubDateLabel.Name = "pubDateLabel";
            this.pubDateLabel.Size = new System.Drawing.Size(95, 13);
            this.pubDateLabel.TabIndex = 5;
            this.pubDateLabel.Text = "Дата публикации";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(14, 86);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(349, 361);
            this.descriptionTextBox.TabIndex = 3;
            this.descriptionTextBox.Text = "";
            // 
            // reloadTimer
            // 
            this.reloadTimer.Tick += new System.EventHandler(this.reloadTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(787, 482);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "RSSFeeder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox feedsListBox;
        private System.Windows.Forms.TextBox feedsUMLTextBox;
        private System.Windows.Forms.RichTextBox titleTextBox;
        private System.Windows.Forms.Label pubDateLabel;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.ToolStripDropDownButton settingsDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem reloadButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem oneMinuteReloadButton;
        private System.Windows.Forms.ToolStripMenuItem fiveMinuteReloadButton;
        private System.Windows.Forms.ToolStripMenuItem fifteenMinuteReloadButton;
        private System.Windows.Forms.ToolStripMenuItem thirtyMinuteReloadButton;
        private System.Windows.Forms.ToolStripMenuItem oneHourReloadButton;
        private System.Windows.Forms.ToolStripMenuItem textFormatButton;
        private System.Windows.Forms.ToolStripMenuItem htmlFormatButton;
        private System.Windows.Forms.Timer reloadTimer;
    }
}

