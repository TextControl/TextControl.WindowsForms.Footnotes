using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TXTextControl;
using System.Collections;
namespace tx_sample_footnotes
{
    public partial class Form1 : Form
    {
        // globally used variables
        int iDpi = 15;
        int iTotalPageNumber = 1;

        public Form1()
        {
            InitializeComponent();

            // connect the controls
            textControl1.RulerBar = rulerBar2;
            textControl1.ButtonBar = buttonBar1;
            textControl1.StatusBar = statusBar1;
            textControl1.VerticalRulerBar = rulerBar1;

            // get a Graphics object to calculate the resolution factor
            Graphics g = textControl1.CreateGraphics();
            iDpi = (int)(1440 / g.DpiX);
        }

        /*-------------------------------------------------------------------------------------------------------
        ** InsertFootnoteField method
         *
         * This method inserts a TextField at the current input position.
         * The TextField is used to display the footnote number and to store
         * the formatted footnote text in it's Name property.
        **-----------------------------------------------------------------------------------------------------*/
        private void InsertFootnoteField()
        {
            int iStartPos = textControl1.Selection.Start;

            TextField tfFootnoteField = new TextField();

            tfFootnoteField.Name = "FN:";
            tfFootnoteField.DoubledInputPosition = true;
            tfFootnoteField.Deleteable = false;
            tfFootnoteField.Editable = false;
            tfFootnoteField.ShowActivated = true;

            textControl1.TextFields.Add(tfFootnoteField);

            textControl1.Select(tfFootnoteField.Start - 1, tfFootnoteField.Length);

            textControl1.Selection.Baseline = 100;
            textControl1.Selection.FontSize -= 40;

            ReorderFootnotes();

            tfFootnoteField.ScrollTo();

            ShowEditor(tfFootnoteField);

            textControl1.InputPosition = new InputPosition(iStartPos + 1, TextFieldPosition.OutsideTextField);
        }

        /*-------------------------------------------------------------------------------------------------------
        ** ShowEditor method
         *
         * This method gets a TextField in the constructor and checks whether it
         * is a footnote field. It opens the footnote editor form that is used to
         * modify the footnote text.
        **-----------------------------------------------------------------------------------------------------*/
        private void ShowEditor(TXTextControl.TextField TextField)
        {
            if (TextField.Name.StartsWith("FN:") == false)
                return;

            footnote_editor frmFootnoteEditor = new footnote_editor(TextField);

            // the size is calculated based on the page size (width)
            frmFootnoteEditor.Size = new Size(
                (textControl1.GetPages()[textControl1.InputPosition.Page].TextBounds.Width / 15)
                , 150);

            // the form should be displayed directly under the footnote field
            Point pntEditorPosition = new Point(
                (int)((textControl1.GetPages()[textControl1.InputPosition.Page].TextBounds.Left / iDpi) -
                (textControl1.ScrollLocation.X / iDpi)) *
                    textControl1.ZoomFactor / 100,

                ((int)(TextField.Bounds.Bottom / 15) -
                (int)(textControl1.ScrollLocation.Y / 15)) *
                    textControl1.ZoomFactor / 100);

            frmFootnoteEditor.Location = textControl1.PointToScreen(pntEditorPosition);

            if (frmFootnoteEditor.ShowDialog() == DialogResult.OK)
            {
                CreateFootnotes();
            }
            else
            {
                textControl1.TextFields.Remove(TextField);
                CreateFootnotes();
            }
        }

        /*-------------------------------------------------------------------------------------------------------
        ** ReorderFootnotes method
         *
         * This method reorders the TextFields. The numbers of the inserted footnotes
         * must be always continuously.
        **-----------------------------------------------------------------------------------------------------*/
        private void ReorderFootnotes()
        {
            int iFootnoteCounter = 1;

            foreach (TXTextControl.TextField tfField in textControl1.TextFields)
            {
                if (tfField.Name.StartsWith("FN:") == false)
                    continue;

                tfField.ID = iFootnoteCounter;
                tfField.Text = tfField.ID.ToString();

                iFootnoteCounter++;
            }
        }

        /*-------------------------------------------------------------------------------------------------------
        ** RemoveFootnoteFrames method
         *
         * This method removes all footnote frames.
        **-----------------------------------------------------------------------------------------------------*/
        public void RemoveFootnoteFrames()
        {
            TXTextControl.TextFrameCollection.FrameBaseEnumerator frameEnum = textControl1.TextFrames.GetEnumerator();

            if (textControl1.TextFrames.Count == 0)
                return;

            while (frameEnum.MoveNext() == true)
            {
                TXTextControl.TextFrame curFrame = (TXTextControl.TextFrame)frameEnum.Current;

                if (curFrame.Name == "FN")
                {
                    textControl1.TextFrames.Remove(curFrame);
                    frameEnum.Reset();
                }
            } 
        }

        /*-------------------------------------------------------------------------------------------------------
        ** CreateFootnotes method
         *
         * This method loops through all pages in order to check whether there are
         * footnote TextFields on that page. If yes, the footnote text is collected in
         * a temporary TextControl instance.
         * If there are footnotes on that page, a TextFrame is created which contains
         * the collected footnote texts.
        **-----------------------------------------------------------------------------------------------------*/
        public void CreateFootnotes()
        {
            RemoveFootnoteFrames();

            // loop through all pages
            foreach (TXTextControl.Page page in textControl1.GetPages())
            {
                TXTextControl.TextControl tempTX = new TextControl();
                tempTX.CreateControl();
                tempTX.Font = new Font("Arial", 7F);
                tempTX.ViewMode = ViewMode.Normal;

                TXTextControl.TextFieldCollection.TextFieldEnumerator fieldEnum = textControl1.TextFields.GetEnumerator();
                int fieldCounter = textControl1.TextFields.Count;

                // loop through all TextFields
                for (int i = 0; i <= fieldCounter; i++)
                {
                    fieldEnum.MoveNext();
                    TXTextControl.TextField curField = (TXTextControl.TextField)fieldEnum.Current;

                    // use field only, if it is a footnote field (starts with "FN:")
                    // and if the field contains formatted text
                    if (curField.Name.StartsWith("FN:") == false || curField.Name.Length <= 3)
                        continue;

                    // check whether the field is on the current page
                    if (GetPageOfField(curField) == page.Number)
                    {
                        // add the formatted text to the temporary TextControl
                        int startPos = tempTX.Selection.Start;
                        tempTX.Selection.Load(curField.Name.Substring(3, curField.Name.Length - 3), StringStreamType.RichTextFormat);
                        tempTX.Selection.Start = startPos;
                        tempTX.Selection.Text = curField.Text + ") ";
                        tempTX.Selection.Start = -1;
                    }
                }

                if (tempTX.Text == "")
                    continue;

                // insert a top frame border
                tempTX.Selection.Start = 0;
                tempTX.Selection.Text = "\r\n";
                tempTX.Selection.Start = 0;
                tempTX.Selection.ParagraphFormat.RightIndent = 5000;
                tempTX.Selection.ParagraphFormat.Frame = Frame.TopLine;

                // measure the used text height
                int textHeight = tempTX.Lines[tempTX.Lines.Count].Baseline + 200;

                // create a new TextFrame based on the used text height
                TXTextControl.TextFrame frame = new TextFrame(new Size(page.TextBounds.Width, textHeight));
                frame.Sizeable = false;
                frame.Moveable = false;
                frame.BorderWidth = 0;
                frame.Name = "FN";
                frame.InternalMargins = new int[] { 0,0,0,0 };

                // add the TextFrame at the bottom border of the page
                textControl1.TextFrames.Add(
                    frame,
                    page.Number,
                    new Point((int)(textControl1.Sections[page.Section].Format.PageMargins.Left * iDpi - 55),
                        (int)textControl1.Sections[page.Section].Format.PageSize.Height * iDpi - (int)textControl1.Sections[page.Section].Format.PageMargins.Top * iDpi - 576 - frame.Size.Height),
                        TextFrameInsertionMode.DisplaceCompleteLines);

                byte[] data = null;

                // save the formatted text from the temporary TextControl
                tempTX.Save(out data, BinaryStreamType.InternalUnicodeFormat);
                // and load it into the TextFrame
                frame.Selection.Load(data, BinaryStreamType.InternalUnicodeFormat);
            }
        }

        /*-------------------------------------------------------------------------------------------------------
        ** CreateFootnotes method
         *
         * This method returns the page number of a given TextField
        **-----------------------------------------------------------------------------------------------------*/
        private int GetPageOfField(TXTextControl.TextField field)
        {
            foreach (TXTextControl.Page page in textControl1.GetPages())
            {
                if (field.Start >= page.Start && (field.Start + field.Length) <= page.Start + page.Length)
                {
                    return page.Number;
                }
            }

            return 0;
        }

        #region "TextControl events and menu handling"

        private void footnoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertFootnoteField();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textControl1.PrintPreview("Print");
        }

        private void textControl1_TextFrameActivated(object sender, TextFrameEventArgs e)
        {
            if(e.TextFrame.Name == "FN")
                textControl1.EditMode = EditMode.ReadAndSelect;
        }

        private void textControl1_TextFrameDeactivated(object sender, TextFrameEventArgs e)
        {
            if (e.TextFrame.Name == "FN")
                textControl1.EditMode = EditMode.Edit;
        }

        private void textControl1_TextFieldClicked(object sender, TextFieldEventArgs e)
        {
            ShowEditor(e.TextField);
        }

        private void textControl1_Changed(object sender, EventArgs e)
        {
            if (iTotalPageNumber != textControl1.Pages)
            {
                CreateFootnotes();
                iTotalPageNumber = textControl1.Pages;
            }
        }

        private void recalculateFootnotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFootnotes();
        }

        private void textControl1_TextFieldCreated(object sender, TextFieldEventArgs e)
        {
            if (e.TextField.Name.StartsWith("FN:") == true)
            {
                ReorderFootnotes();
                CreateFootnotes();
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textControl1.Load(StreamType.InternalUnicodeFormat | StreamType.RichTextFormat);
            CreateFootnotes();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textControl1.Save(StreamType.InternalUnicodeFormat | StreamType.RichTextFormat);
        }

        #endregion
    }
}

