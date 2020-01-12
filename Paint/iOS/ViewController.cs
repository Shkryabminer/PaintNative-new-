using System;
using Paint.Draw;
using Paint.iOS.Extensions;
using Paint.iOS.Keeper;
using Paint.Keeper;
using UIKit;

namespace Paint.iOS
{
    public partial class ViewController : UIViewController, IPaintViewDelegate
    {
        private DrawModel _drawModel;
        private IDrawKeeper _drawKeeper;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _drawModel = new DrawModel();
            _paintView.Delegate = this;
            
           
            
            _btnClear.TouchUpInside += BtnClearTouchUpInside;
            _btnBack.TouchUpInside += BtnBackTouchUpInside;
            _btnThin.TouchUpInside += BtnThinTouchUpInside;
            _btnMedium.TouchUpInside += BtnMediumTouchUpInside;
            _btnThick.TouchUpInside += BtnThickTouchUpInside;

            _btnRed.TouchUpInside += BtnRedTouchUpInside;
            _btnYellow.TouchUpInside += BtnYellowTouchUpInside;
            _btnGreen.TouchUpInside += BtnGreenTouchUpInside;
            
            _btnSave.TouchUpInside += BtnSaveOnTouchUpInside;
            _btnLoad.TouchUpInside += BtnLoadOnTouchUpInside;
        }

        private void BtnLoadOnTouchUpInside(object sender, EventArgs e)
        {
            _drawModel = _drawKeeper.Load();
            _paintView.UpdateView(_drawModel.Paths);
        }

        private void BtnSaveOnTouchUpInside(object sender, EventArgs e)
        {
            var alert = UIAlertController.Create("Save", "Select save paint", UIAlertControllerStyle.Alert);
            if (alert.PopoverPresentationController != null)
                alert.PopoverPresentationController.BarButtonItem = sender as UIBarButtonItem;

            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));

            alert.AddAction(UIAlertAction.Create("Save to File", UIAlertActionStyle.Default, action => {
                _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.File);
                _drawKeeper.Save(_drawModel);
            }));
            alert.AddAction(UIAlertAction.Create("Save to Realm", UIAlertActionStyle.Default, action => {
                _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.Realm);
                _drawKeeper.Save(_drawModel);
            }));
            alert.AddAction(UIAlertAction.Create("Save to SQLite", UIAlertActionStyle.Default, action => {
                _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.SQLite);
                _drawKeeper.Save(_drawModel);
            }));
            alert.AddAction(UIAlertAction.Create("Save to NSUserDefoult", UIAlertActionStyle.Default, action => {
                _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.Internal);
                _drawKeeper.Save(_drawModel);
            }));
            PresentViewController(alert, animated: true, completionHandler: null);
            
        }

        private void BtnBackTouchUpInside(object sender, EventArgs e)
        {
            _drawModel.Back();
            _paintView.UpdateView(_drawModel.Paths);
        }

        private void BtnGreenTouchUpInside(object sender, EventArgs e)
        {
            _drawModel.CurrentColor = UIColor.Green.GetColor();
        }

        private void BtnYellowTouchUpInside(object sender, EventArgs e)
        {
            _drawModel.CurrentColor = UIColor.Yellow.GetColor();
        }

        private void BtnRedTouchUpInside(object sender, EventArgs e)
        {
            _drawModel.CurrentColor = UIColor.Red.GetColor();
        }

        private void BtnThickTouchUpInside(object sender, EventArgs e)
        {
            _drawModel.CurrentLineWidth = 20;
        }

        private void BtnMediumTouchUpInside(object sender, EventArgs e)
        {
            _drawModel.CurrentLineWidth = 10;
        }

        private void BtnThinTouchUpInside(object sender, EventArgs e)
        {
            _drawModel.CurrentLineWidth = 5;
        }

        private void BtnClearTouchUpInside(object sender, EventArgs e)
        {
            _drawModel.Clear();
            _paintView.UpdateView(_drawModel.Paths);
        }

        public void PathStartedAt(Point point)
        {
            _drawModel.StartPath(point);
        }

        public void PathAppendedAt(Point point)
        {
           _drawModel.AppendPath(point);
           _paintView.UpdateView(_drawModel.Paths);
        }
    }
}
