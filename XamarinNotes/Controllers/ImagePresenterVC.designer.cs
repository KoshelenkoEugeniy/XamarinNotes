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
    [Register ("ImagePresenterVC")]
    partial class ImagePresenterVC
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView Spinner { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Spinner != null) {
                Spinner.Dispose ();
                Spinner = null;
            }
        }
    }
}