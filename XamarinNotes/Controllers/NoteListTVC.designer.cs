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
    [Register ("NoteListTVC")]
    partial class NoteListTVC
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableViewListNotes { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TableViewListNotes != null) {
                TableViewListNotes.Dispose ();
                TableViewListNotes = null;
            }
        }
    }
}