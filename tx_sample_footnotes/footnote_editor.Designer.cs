namespace tx_sample_footnotes
{
    partial class footnote_editor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(footnote_editor));
            this.textControl1 = new TXTextControl.TextControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAccept = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.buttonBar1 = new TXTextControl.ButtonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.Font = new System.Drawing.Font("Arial", 7F);
            this.textControl1.Location = new System.Drawing.Point(13, 63);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(443, 86);
            this.textControl1.TabIndex = 0;
            this.textControl1.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textControl1.UserNames = null;
            this.textControl1.ViewMode = TXTextControl.ViewMode.SimpleControl;
            this.textControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textControl1_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAccept,
            this.btnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(456, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAccept
            // 
            this.btnAccept.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(48, 22);
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(44, 22);
            this.btnCancel.Text = "Delete";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // buttonBar1
            // 
            this.buttonBar1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBar1.ButtonOffsets = new int[] {
        10,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0};
            this.buttonBar1.ButtonPositions = new TXTextControl.Button[] {
        TXTextControl.Button.FontNameComboBox,
        TXTextControl.Button.FontSizeComboBox,
        TXTextControl.Button.FontBoldButton,
        TXTextControl.Button.FontItalicButton,
        TXTextControl.Button.FontUnderlineButton,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None};
            this.buttonBar1.ButtonSeparators = new bool[] {
        false,
        false,
        true,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
            this.buttonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBar1.Location = new System.Drawing.Point(0, 25);
            this.buttonBar1.Name = "buttonBar1";
            this.buttonBar1.Size = new System.Drawing.Size(456, 28);
            this.buttonBar1.TabIndex = 2;
            this.buttonBar1.Text = "buttonBar1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 10);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(13, 86);
            this.panel2.TabIndex = 4;
            // 
            // footnote_editor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(456, 149);
            this.ControlBox = false;
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonBar1);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "footnote_editor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.footnote_editor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnAccept;
        private TXTextControl.ButtonBar buttonBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public TXTextControl.TextControl textControl1;
    }
}
