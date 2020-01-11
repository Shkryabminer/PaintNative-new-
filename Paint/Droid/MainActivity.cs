using Android.App;
using Android.Widget;
using Android.OS;
using Paint.Draw;

namespace Paint.Droid
{
    [Activity(Label = "Paint", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, IPaintViewDelegate
    {
        DrawLine _drawingLine;
        DrawModel _drawModel;
        Paint.Draw.Color colorPaint;
        Button btnThin, btnMedium, btnThick, btnRedColor, btnYellowColor, btnGreenColor;
        ImageButton btnUndo, btnClear;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            LinearLayout linear = FindViewById<LinearLayout>(Resource.Id.viewDraw);
            _drawingLine = new DrawLine(this);
            linear.AddView(_drawingLine);
            _drawingLine.Delegate = this;
            _drawModel = new DrawModel();
            ButtonInitialize();
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

