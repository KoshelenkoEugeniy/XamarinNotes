using System;
using UIKit;
using Foundation;
using XamarinNotes.Classes;
using System.Collections.Generic;
using System.IO;

namespace XamarinNotes
{
    public class TableSourceForNotesList: UITableViewSource
    {
        List<Note> data;
        string cellID = "NoteCell";
        Model blModel = new Model();

        public TableSourceForNotesList(List<Note> items)
        {
            data = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            ListNoteCell myCell = (ListNoteCell)tableView.DequeueReusableCell(cellID);

            if (data[indexPath.Row] != null)
            {
                myCell.Attachment = "";

                if (data[indexPath.Row].Attachments.Count > 0) 
                {
                    foreach(var item in data[indexPath.Row].Attachments)
                    {
                        if (myCell.Attachment == "")
                        {
                            myCell.Attachment = item.Name;
                        }
                        else 
                        {
                            myCell.Attachment = myCell.Attachment + ", " + item.Name;   
                        }
                    }
                }
               
                myCell.Date = $"{data[indexPath.Row].DateOfCreation}";
                myCell.Text = data[indexPath.Row].Text;
            }

            return myCell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (data != null)
            {
                return data.Count;
            }
            return 0;
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
        {
            Note noteForDeleting = new Note();

            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    // remove the item from the underlying data source

                    if (data[indexPath.Row].Attachments.Count > 0)
                    {
                        foreach(var item in data[indexPath.Row].Attachments)
                        {
                            File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), item.Name + $".{item.Extension}"));        
                        }
                    }
                    noteForDeleting = data[indexPath.Row];

                    data.RemoveAt(indexPath.Row);

                    // delete the row from the table
                    tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);

                    blModel.ToDo("Delete", noteForDeleting);

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
            return "Trash ("+ data[indexPath.Row].Text + ")";
        }

        public Note GetItem(int id)
        {
            return data[id];
        }
    }
}
