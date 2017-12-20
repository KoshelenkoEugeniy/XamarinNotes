using Foundation;
using System;
using UIKit;
using XamarinNotes.Classes;
using System.IO;
using XamarinNotes.TableSources;

namespace XamarinNotes
{
    public interface SaveChangesDelegate
    {
        void Save(Note myNote);
        void Add(Note myNote);
    }

    public partial class NoteVC : UIViewController
    {
        public NoteVC(IntPtr handle) : base(handle)
        {
        }

        Note currentNote = new Note();

        UIImagePickerController imagePicker;

        public SaveChangesDelegate Delegate;

        string SandboxDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        string FileName;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.TableViewListAttachments.Source = new TableSourceForAttachmentsList();

            currentNoteText.Layer.BorderColor = UIColor.Black.CGColor;
            currentNoteText.Layer.BorderWidth = 0.5f;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            currentNoteText.Text = currentNote.Text;

            if (currentNote.Status == true)
            {
                currentNoteState.SetState(true, true);
            }
            else
            {
                currentNoteState.SetState(false, true);
            }

            if (currentNote.Attachments.Count > 0)
            {
                TableViewListAttachments.Hidden = false;
            }
            else
            {
                TableViewListAttachments.Hidden = true;
            }

            TableViewListAttachments.Source = new TableSourceForAttachmentsList(currentNote.Attachments);
        }

        public void SetTask(NoteListTVC d, Note selectedNote)
        {
            Delegate = d;
            currentNote = selectedNote;
        }

        partial void CancelAction(UIBarButtonItem sender)
        {
            currentNote = null;
            DismissViewController(true, null);
        }

        partial void SaveAction(UIBarButtonItem sender)
        {
            SaveCurrentState();

            currentNote.DateOfCreation = DateTime.Now;

            if (NavigationItem.RightBarButtonItem.Title == "Add")
            {
                Delegate.Add(currentNote);
            }
            else
            {
                Delegate.Save(currentNote);
            }

            DismissViewController(true, null);
        }

        public void SaveCurrentState()
        {
            if (currentNoteState.On)
            {
                currentNote.Status = true;
            }
            else
            {
                currentNote.Status = false;
            }

            currentNote.Text = currentNoteText.Text;
        }

        partial void AttachAction(UIButton sender)
        {
            SaveCurrentState();

            imagePicker = new UIImagePickerController();

            imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

            imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
            imagePicker.Canceled += Handle_Canceled;

            NavigationController.PresentModalViewController(imagePicker, true);
        }

        protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            string FileExtension = "";
            Picture SavingResult = new Picture();

            if (e.Info[UIImagePickerController.MediaType].ToString() == "public.image")
            {
                NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceURL")] as NSUrl;

                if (referenceURL != null)
                    FileExtension = referenceURL.PathExtension;

                UIImage SelectedImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
                if (SelectedImage != null)
                {
                    SavingResult = SavePicture(SelectedImage, FileExtension);
                }
                else
                {
                    SelectedImage = e.Info[UIImagePickerController.EditedImage] as UIImage;

                    if (SelectedImage != null)
                    {
                        SavingResult = SavePicture(SelectedImage, FileExtension);
                    }
                }
            }

            // dismiss the picker
            if (SavingResult != null)
            {
                currentNote.Attachments.Add(SavingResult);

                imagePicker.DismissViewController(true, null);
            }
        }

        void Handle_Canceled(object sender, EventArgs e)
        {
            imagePicker.DismissViewController(true, null);
        }

        Picture SavePicture(UIImage withImage, string withExtension)
        {
            NSData imageData = null;
            NSError err = null;

            Random random = new Random();

            int randomPrefix = random.Next(100, 1000);

            int imgCode = withImage.GetHashCode();

            string strImgCode = $"{randomPrefix}{imgCode}"; 

            string ShortFileName = strImgCode;

            FileName = Path.Combine(SandboxDir, strImgCode + $".{withExtension}"); // save

            if (withExtension == "JPG" || withExtension == "JPEG")
            {
                imageData = withImage.AsJPEG();
            }
            else if (withExtension == "PNG")
            {
                imageData = withImage.AsPNG();
            }

            if (imageData.Save(FileName, false, out err))
            {
                Picture pic = new Picture(ShortFileName, withExtension, FileName);
                return pic;
            }
            else
            {
                return null;
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            SaveCurrentState();

            var destinationVC = segue.DestinationViewController as ImagePresenterVC;
            if (destinationVC != null)
            {
                var source = TableViewListAttachments.Source as TableSourceForAttachmentsList;
                var rowPath = TableViewListAttachments.IndexPathForSelectedRow;
                var item = source.GetItem(rowPath.Row);

                destinationVC.imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), item.Name + $".{item.Extension}");
            }
        }
    }
}
