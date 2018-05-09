// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ExamenP2_62453
{
	[Register ("CustomTableViewCell")]
	partial class CustomTableViewCell
	{
		[Outlet]
		UIKit.UISearchBar SrchTweet { get; set; }

		[Outlet]
		UIKit.UILabel TxtFavs { get; set; }

		[Outlet]
		UIKit.UILabel TxtRetweets { get; set; }

		[Outlet]
		UIKit.UILabel TxtTweet { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TxtFavs != null) {
				TxtFavs.Dispose ();
				TxtFavs = null;
			}

			if (TxtRetweets != null) {
				TxtRetweets.Dispose ();
				TxtRetweets = null;
			}

			if (TxtTweet != null) {
				TxtTweet.Dispose ();
				TxtTweet = null;
			}

			if (SrchTweet != null) {
				SrchTweet.Dispose ();
				SrchTweet = null;
			}
		}
	}
}
