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
    [Register ("NoteVC")]
    partial class NoteVC
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AttachButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch currentNoteState { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView currentNoteText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableViewListAttachments { get; set; }

        [Action ("AttachAction:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AttachAction (UIKit.UIButton sender);

        [Action ("CancelAction:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CancelAction (UIKit.UIBarButtonItem sender);

        [Action ("SaveAction:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SaveAction (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (AttachButton != null) {
                AttachButton.Dispose ();
                AttachButton = null;
            }

            if (currentNoteState != null) {
                currentNoteState.Dispose ();
                currentNoteState = null;
            }

            if (currentNoteText != null) {
                currentNoteText.Dispose ();
                currentNoteText = null;
            }

            if (TableViewListAttachments != null) {
                TableViewListAttachments.Dispose ();
                TableViewListAttachments = null;
            }
        }
    }
}