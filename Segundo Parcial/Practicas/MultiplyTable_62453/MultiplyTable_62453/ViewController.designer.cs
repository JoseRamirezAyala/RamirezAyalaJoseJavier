// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MultiplyTable_62453
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UITableView TableView { get; set; }

        [Action ("BtnShow:")]
        partial void BtnShow (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }
        }
    }
}
