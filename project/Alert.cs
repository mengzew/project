using System;
using UIKit;
using System.Drawing;
using Foundation;
using CoreGraphics;


namespace project
{
	public partial class Alert : UIViewController
	{
		public Alert(IntPtr handle) : base (handle)
        {
		}

		#region alert function
		public override void LoadView()
		{
			base.LoadView();


			alert.TouchUpInside += ((sender, e) =>
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
			});
		}
		#endregion

	}
}

