using System;
using System.Collections.Generic;
using XamarinNotes.Classes;
using UIKit;
using Foundation;
using System.IO;

namespace XamarinNotes.TableSources
{
    class TableSourceForAttachmentsList : UITableViewSource
    {
        List<Picture> source;

        string cellID = "AttachmentCell";

        public TableSourceForAttachmentsList() { }

        public TableSourceForAttachmentsList(List<Picture> items)
        {
            source = items;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            if (source != null)
            {
                return source.Count;
            }
            return 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            AttachmentListCell myCell = (AttachmentListCell)tableView.DequeueReusableCell(cellID);

            if (source[indexPath.Row] != null)
            {
                myCell.Name = source[indexPath.Row].Name;
                myCell.Extension = source[indexPath.Row].Extension;
            }

            return myCell;
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    // remove the item from the underlying data source

                    //File.Delete(source[indexPath.Row].Link);
                    File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), source[indexPath.Row].Name + $".{source[indexPath.Row].Extension}"));  

                    source.RemoveAt(indexPath.Row);
                    // delete the row from the table
                    tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                    break;
                case UITableViewCellEditingStyle.None:
                    Console.WriteLine("CommitEditingStyle:None called");
                    break;
            }
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true; // return false if you wish to disable editing for a specific indexPath or for all rows
        }
        public override string TitleForDeleteConfirmation(UITableView tableView, NSIndexPath indexPath)
        {   // Optional - default text is 'Delete'
            return "Trash (" + source[indexPath.Row].Name + ")";
        }

        public Picture GetItem(int id)
        {
            return source[id];
        }
    }
}

