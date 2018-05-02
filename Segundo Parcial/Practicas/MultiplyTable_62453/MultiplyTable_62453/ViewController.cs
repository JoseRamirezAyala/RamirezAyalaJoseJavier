using System;
using Foundation;
using UIKit;

namespace MultiplyTable_62453
{
    public partial class ViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate
    {
        #region Class Properties
        nint rows = 0;
        nint num = 0;
        string inputText = "";
        #endregion
        #region Constructors
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        #endregion
        #region Controller Life Cycle
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            InitializeComponents();
        }
        #endregion
        #region UserInteraction
        partial void BtnShow(Foundation.NSObject sender)
        {
            //Create Alert
            var numbersAlert = UIAlertController.Create(null, null, UIAlertControllerStyle.ActionSheet);
            numbersAlert.AddAction(UIAlertAction.Create("0", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(0)));
            numbersAlert.AddAction(UIAlertAction.Create("1", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(1)));
            numbersAlert.AddAction(UIAlertAction.Create("2", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(2)));
            numbersAlert.AddAction(UIAlertAction.Create("3", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(3)));
            numbersAlert.AddAction(UIAlertAction.Create("4", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(4)));
            numbersAlert.AddAction(UIAlertAction.Create("5", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(5)));
            numbersAlert.AddAction(UIAlertAction.Create("6", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(6)));
            numbersAlert.AddAction(UIAlertAction.Create("7", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(7)));
            numbersAlert.AddAction(UIAlertAction.Create("8", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(8)));
            numbersAlert.AddAction(UIAlertAction.Create("9", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(9)));
            numbersAlert.AddAction(UIAlertAction.Create("10", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(10)));
            numbersAlert.AddAction(UIAlertAction.Create("11", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(11)));
            numbersAlert.AddAction(UIAlertAction.Create("12", UIAlertActionStyle.Default, (action) => NumberAlertItemClicked(12)));
            //Present Alert
            PresentViewController(numbersAlert, true, null);
        }
        #endregion
        #region Internal Functionality
        void NumberAlertItemClicked(nint number)
        {
            num = number;
            //Create Alert
            var numberAlert = UIAlertController.Create("Seleccionar", $"Selecciona el numero hasta el cual se multiplicara {number}, No se acepta numero 0", UIAlertControllerStyle.Alert);
            UITextField textField = new UITextField();
            numberAlert.AddTextField((action) =>
            {
                textField = action;
                textField.KeyboardType = UIKeyboardType.NumberPad;
            });


            //Add Action
            numberAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (action) =>
            {
                rows = getInt(textField.Text);
                inputText = textField.Text;
                SetRows(rows);
                CheckErrorAlert();
            }));

            // Present Alert
            PresentViewController(numberAlert, true, null);
        }

        nint getInt(string text)
        {
            nint result;
            if (!nint.TryParse(text, out result))
            {
                return 0;
            }
            else
            {
                return result;
            }
        }
        void CheckErrorAlert()
        {
            if (rows <= 0)
            {

                var errAlert = UIAlertController.Create("Error", $"{inputText} No es valido", UIAlertControllerStyle.Alert);
                errAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(errAlert, true, null);
            }
            else
            {

            }
        }
        void SetRows(nint pRows)
        {
            rows = pRows;
            TableView.ReloadData();
        }
        void InitializeComponents(){
            TableView.DataSource = this;
            TableView.Delegate = this;
        }
        #endregion
        #region Table Data Source
        public nint RowsInSection(UITableView tableView, nint section)
        {
            return rows;
        }
        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var res = num * indexPath.Row;
            var cell = tableView.DequeueReusableCell("BasicTableViewCell", indexPath);
            cell.TextLabel.Text = $"{num} x {indexPath.Row} = {res}";

            return cell;
        }
        [Export("numberOfSectionsInTableView:")]
        public nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }
        #endregion


    }
}
