using System;
using UIKit;
using AudioToolbox;
using AVFoundation;
using Foundation;

namespace project
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			this.View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("background.png"));

			// enable the following lines to make functions work
			/*
			alert.TouchUpInside += ((object sender, EventArgs e) =>
			{
				var textInputAlertController = UIAlertController.Create("Require user password", "please enter ", UIAlertControllerStyle.Alert);
				textInputAlertController.AddTextField(textField =>
				{
				});
				var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alertAction => Console.WriteLine("Cancel was Pressed"));
				var okayAction = UIAlertAction.Create("Okay", UIAlertActionStyle.Default, alertAction => Console.WriteLine("The user entered '{0}'", textInputAlertController.TextFields[0].Text));

				textInputAlertController.AddAction(cancelAction);
				textInputAlertController.AddAction(okayAction);
				PresentViewController(textInputAlertController, true, null);
			}); */

			imageController.ValueChanged += (sender, e) =>
			{
				var selectedSegmentId = (sender as UISegmentedControl).SelectedSegment;
				if (selectedSegmentId == 1)
				{
					changedImage.Image = UIImage.FromBundle("uni_life.jpg");
				}
			};

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public static AppDelegate App
		{
			get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
		}
	}
}


