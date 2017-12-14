# TextControl.WindowsForms.Footnotes

Footnotes are placed at the bottom of a page to display additional information, comments or citations. Generally, the footnote marker in the text is represented by a superscripted number.

This sample shows how to realize footnotes with TX Text Control .NET for Windows Forms. The footnote marker in the text is represented by a TextField with a specific name to recognize such fields later.

To insert a footnote, click on Footnote from the Insert main menu. When the footnote marker has been inserted, a footnote editor is opened. This editor uses TX Text Control to provide an interface to type in the fully formatted footnote text. Click on the Accept button to add the footnote to the document.

The formatted footnote text is stored in the Name property of the TextField. After the dialog is closed, the sample loops through all pages of the document in order to check whether there are footnotes on that page. If there are such TextFields on a page, the formatted text is collected in a temporary TextControl in order to be inserted into a TextFrame at the end of the page.

The required height of the TextFrame is calculated automatically based on the used text height in the temporary TextControl. This guarantees that only the minimum required height is used for the footnote area at the bottom of a page.
