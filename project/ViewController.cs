using System;
using UIKit;

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
		}


		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewWillAppear(bool animated)
		{
			this.BeginInvokeOnMainThread(delegate
			{
				this.View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("background.png"));
			});
			base.ViewWillAppear(animated);
		}

	}
}


