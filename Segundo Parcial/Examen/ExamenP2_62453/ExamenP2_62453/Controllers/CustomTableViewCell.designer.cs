// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
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
        }
    }
}