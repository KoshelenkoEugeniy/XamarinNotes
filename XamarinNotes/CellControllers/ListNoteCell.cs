using Foundation;
using System;
using UIKit;

namespace XamarinNotes
{
    public partial class ListNoteCell : UITableViewCell
    {
        public string Text
        {
            get { return NoteText.Text; }
            set { NoteText.Text = value; }
        }

        public string Date
        {
            get { return NoteDate.Text; }
            set { NoteDate.Text = value; }
        }

        public string Attachment 
        {
            get { return NoteAttachment.Text; }
            set 
            { 
                if(value != "")
                {
                    NoteAttachment.Text = value; 
                    NoteAttachment.Hidden = false;
                    AttachmentPicture.Hidden = false;
                } 
                else 
                {
                    NoteAttachment.Text = "";
                    NoteAttachment.Hidden = true;
                    AttachmentPicture.Hidden = true;
                }
            }
        }

        public ListNoteCell (IntPtr handle) : base (handle)
        {
        }
    }
}