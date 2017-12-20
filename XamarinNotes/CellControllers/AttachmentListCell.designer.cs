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
    [Register ("AttachmentListCell")]
    partial class AttachmentListCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AttachmentExtension { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FileName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AttachmentExtension != null) {
                AttachmentExtension.Dispose ();
                AttachmentExtension = null;
            }

            if (FileName != null) {
                FileName.Dispose ();
                FileName = null;
            }
        }
    }
}