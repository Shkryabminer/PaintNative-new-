using Android.App;
using Android.Widget;
using Android.OS;
using Paint.Draw;
using Android.Support.V7.App;
using Android.Views;
using Paint.Keeper;
using Paint.Droid.Keeper;

namespace Paint.Droid
{
    [Activity(Label = "Paint", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity, IPaintViewDelegate
    {
        private IDrawKeeper _drawKeeper;
        DrawLine _drawingLine;
        DrawModel _drawModel;
        Paint.Draw.Color colorPaint;
        Button btnThin, btnMedium, btnThick, btnRedColor, btnYellowColor, btnGreenColor;
        ImageButton btnUndo, btnClear;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            var menu = FindViewById<@Android.Support.V7.Widget.Toolbar>(Resource.Id.menuForSave);
            SetSupportActionBar(menu);
            LinearLayout linear = FindViewById<LinearLayout>(Resource.Id.viewDraw);
            _drawingLine = new DrawLine(this);
            linear.AddView(_drawingLine);
            _drawingLine.Delegate = this;
            _drawModel = new DrawModel();
            ButtonInitialize();
        }

      
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            this.MenuInflater.Inflate(Resource.Menu.ToolbarMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

      
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.SaveToFile:
                    _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.File);
                    _drawKeeper.Save(_drawModel);
                    return true;
                case Resource.Id.SaveToSharedPreferance:
                    _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.Internal);
                    _drawKeeper.Save(_drawModel);
                    return true;
                case Resource.Id.SaveToRealm:
                    _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.Realm);
                    _drawKeeper.Save(_drawModel);
                    return true;
                case Resource.Id.SaveToSQLite:
                    _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.SQLite);
                    _drawKeeper.Save(_drawModel);
                    return true;
                case Resource.Id.ClickLoadToFile:
                    _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.File);
                    LoadFile();
                    return true;
                case Resource.Id.ClickLoadToSharedPreferance:
                    _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.Internal);
                    LoadFile();
                    return true;
                case Resource.Id.ClickLoadToRealm:
                    _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.Realm);
                    LoadFile();
                    return true;
                case Resource.Id.ClickLoadToSQLite:
                    _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.SQLite);
                    LoadFile();
                    return true;
                default: return false;
            }
        }

        private void LoadFile()
        {
            try
            {
                _drawModel = _drawKeeper.Load();
                _drawingLine.UpdateView(_drawModel.Paths);
            }
            catch (System.Exception ex)
            {
                _drawModel = new DrawModel();
                _drawingLine.UpdateView(_drawModel.Paths);
            }
        }
        private void BtnClear_Click(object sender, System.EventArgs e)
        {
            _drawModel.Clear();
            _drawingLine.UpdateView(_drawModel.Paths);

        }

        private void BtnUndo_Click(object sender, System.EventArgs e)
        {
            _drawModel.Back();
            _drawingLine.UpdateView(_drawModel.Paths);

        }

        private void BtnGreenColor_Click(object sender, System.EventArgs e)
        {
            colorPaint = new Paint.Draw.Color(10, 252, 10);
            _drawModel.CurrentColor = colorPaint;
        }

        private void BtnYellowColor_Click(object sender, System.EventArgs e)
        {
            colorPaint = new Paint.Draw.Color(255, 255, 0);
            _drawModel.CurrentColor = colorPaint;

        }

        private void BtnRedColor_Click(object sender, System.EventArgs e)
        {
            colorPaint = new Paint.Draw.Color(255, 0, 0);
            _drawModel.CurrentColor = colorPaint;
        }

        private void BtnThick_Click(object sender, System.EventArgs e)
        {

            _drawModel.CurrentLineWidth = 60f;
        }

        private void BtnMedium_Click(object sender, System.EventArgs e)
        {

            _drawModel.CurrentLineWidth = 40f;
        }

        private void BtnThin_Click(object sender, System.EventArgs e)
        {

            _drawModel.CurrentLineWidth = 20f;
        }

        protected override void OnDestroy()
        {
            btnThin.Click -= BtnThin_Click;
            btnMedium.Click -= BtnMedium_Click;
            btnThick.Click -= BtnThick_Click;

            btnRedColor.Click -= BtnRedColor_Click;
            btnYellowColor.Click -= BtnYellowColor_Click;
            btnGreenColor.Click -= BtnGreenColor_Click;

            btnUndo.Click -= BtnUndo_Click;
            btnClear.Click -= BtnClear_Click;
        }

        public void PathStartedAt(Point point)
        {
            _drawModel.StartPath(point);
        }

        public void PathAppendedAt(Point point)
        {
            _drawModel.AppendPath(point);
            _drawingLine.UpdateView(_drawModel.Paths);
        }
        private void ButtonInitialize()
        {
            btnThin = FindViewById<Button>(Resource.Id.btnThin);
            btnMedium = FindViewById<Button>(Resource.Id.btnMedium);
            btnThick = FindViewById<Button>(Resource.Id.btnThick);

            btnRedColor = FindViewById<Button>(Resource.Id.btnRed);
            btnYellowColor = FindViewById<Button>(Resource.Id.btnYellow);
            btnGreenColor = FindViewById<Button>(Resource.Id.btnGreen);

            btnUndo = FindViewById<ImageButton>(Resource.Id.btnUndo);
            btnClear = FindViewById<ImageButton>(Resource.Id.btnClear);

            btnThin.Click += BtnThin_Click;
            btnMedium.Click += BtnMedium_Click;
            btnThick.Click += BtnThick_Click;

            btnRedColor.Click += BtnRedColor_Click;
            btnYellowColor.Click += BtnYellowColor_Click;
            btnGreenColor.Click += BtnGreenColor_Click;

            btnUndo.Click += BtnUndo_Click;
            btnClear.Click += BtnClear_Click;
        }

       
    }
}

