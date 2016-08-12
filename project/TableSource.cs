using System;
using Foundation;
using UIKit;

namespace project
{
	public class TableSource : UITableViewSource
	{
		string[] tableItems;
		string[] _image;
		string cellIdentifier = "TableCell";

		public TableSource(string[] items, string[] image)
		{
			tableItems = items;
			_image = image;
		}


		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
			cell.TextLabel.Text = tableItems[indexPath.Row];
			cell.ImageView.Image = UIImage.FromFile(_image[indexPath.Row]);
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Length;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			new UIAlertView("Alert", "You touched: " + tableItems[indexPath.Row], null, "OK", null).Show();
			tableView.DeselectRow(indexPath, true);
		}
	}
}


