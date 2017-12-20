// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinNotes
{
    [Register ("ListNoteCell")]
    partial class ListNoteCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView AttachmentPicture { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NoteAttachment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NoteDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NoteText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AttachmentPicture != null) {
                AttachmentPicture.Dispose ();
                AttachmentPicture = null;
            }

            if (NoteAttachment != null) {
                NoteAttachment.Dispose ();
                NoteAttachment = null;
            }

            if (NoteDate != null) {
                NoteDate.Dispose ();
                NoteDate = null;
            }

            if (NoteText != null) {
                NoteText.Dispose ();
                NoteText = null;
            }
        }
    }
}