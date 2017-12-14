using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TXTextControl;
namespace tx_sample_footnotes
{
    public partial class footnote_editor : Form
    {
        private TXTextControl.TextField textField;

        public footnote_editor(TXTextControl.TextField TextField)
        {
            InitializeComponent();
            textControl1.ButtonBar = buttonBar1;
            textField = TextField;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AcceptAndClose();
        }

        private void AcceptAndClose()
        {
            string footnoteText = String.Empty;
            textControl1.Save(out footnoteText, TXTextControl.StringStreamType.RichTextFormat);
            textField.Name = "FN:" + footnoteText;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt == true && e.Control == true && e.KeyCode == Keys.Enter)
                AcceptAndClose();
        }

        private void footnote_editor_Load(object sender, EventArgs e)
        {
            if (textField.Name.Length > 3)
                textControl1.Selection.Load(textField.Name.Substring(3, textField.Name.Length - 3), StringStreamType.RichTextFormat);
        }
    }
}
