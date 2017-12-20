using CoreGraphics;
using System;
using UIKit;

namespace XamarinNotes
{
    public partial class ImagePresenterVC : UIViewController
    {
        public ImagePresenterVC (IntPtr handle) : base (handle)
        {
        }

        public string imagePath;

        UIImageView imageView = new UIImageView();

        UIImage image
        {
            get
            {
                return imageView.Image;
            }
            set
            {
                imageView.Image = value;

                imageView.SizeToFit();

                Spinner.StopAnimating();
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (imagePath != null)
            {
                fetchImage();
            }

            View.AddSubview(imageView);
        }

        void fetchImage()
        {
            var imgFromFile = UIImage.FromFile(imagePath);

            CGSize newSize = new CGSize(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);

            CGRect scaledImageRect = CGRect.Empty;

            double aspectWidth = newSize.Width / imgFromFile.Size.Width;
            double aspectHeight = newSize.Height / imgFromFile.Size.Height;
            double aspectRatio = Math.Min(aspectWidth, aspectHeight);

            scaledImageRect.Size = new CGSize(imgFromFile.Size.Width * aspectRatio, imgFromFile.Size.Height * aspectRatio);
            scaledImageRect.X = (newSize.Width - scaledImageRect.Size.Width) / 2.0f;
            scaledImageRect.Y = (newSize.Height - scaledImageRect.Size.Height) / 2.0f;

            UIGraphics.BeginImageContextWithOptions(newSize, false, 0);
            imgFromFile.Draw(scaledImageRect);

            UIImage scaledImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            image = scaledImage;
        }
    }
}