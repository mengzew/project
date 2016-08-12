using Foundation;
using System;
using UIKit;

namespace project
{
    public partial class TableView : UIViewController
    {
        public TableView (IntPtr handle) : base (handle)
        {
        }

		#region tableview
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			string[] data = new string[] { "News", "Weather", "Party", "Assignment", "Tools" };
			string[] image = new string[] { "images.png", "weather.png", "party.png", "assignment.png", "tools.png"};

			UITableView _table;
			_table = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 30, View.Bounds.Width, View.Bounds.Height),
				Source = new TableSource(data, image)
			};

			View.AddSubview(_table);
		}
		#endregion

    }
}