using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomComponents.CompoundView
{
    public delegate void LenghtChangedHandler(object sender,EventArgs e);
    public class LenghtPicker:LinearLayout
    {
        public event LenghtChangedHandler LenghChanged;
        public int NumberOfInches { get { return _numberOfInches; } }
        protected void OnLenghtChanged(object sender)
        {
            if (LenghChanged != null)
                LenghChanged(sender, new EventArgs());
        }

        private static readonly string BaseClassKey = "BaseClassKey";
        private static readonly string NumberOfInchesKey = "NumberOfInchesKey";
        private Button _buttonPlus;
        private Button _buttonMinus;
        private TextView _textView;
        private int _numberOfInches = 0;
        
        
        public LenghtPicker(Context context) : base(context)
        {
            initialize();
        }

        public LenghtPicker(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            initialize();
        }

        private void initialize()
        {
            LayoutInflater layoutInflater=LayoutInflater.From(Context);
            View rootView= layoutInflater.Inflate(Resource.Layout.lenghtPicker,this);

            _buttonMinus =rootView.FindViewById<Button>(Resource.Id.buttonMinus);
            _buttonMinus.Click += _buttonMinus_Click;
            
            _buttonPlus = rootView.FindViewById<Button>(Resource.Id.buttonPlus);
            _buttonPlus.Click += _buttonPlus_Click;

            _textView = rootView.FindViewById<TextView>(Resource.Id.textView);
            updateControls();
        }

        void _buttonPlus_Click(object sender, EventArgs e)
        {
            _numberOfInches++;
            OnLenghtChanged(this);
            updateControls();
        }

        void _buttonMinus_Click(object sender, EventArgs e)
        {
            _numberOfInches--;
            OnLenghtChanged(this);
            updateControls();
        }

        private void updateControls()
        {
            int feet = _numberOfInches/12;
            int inches = _numberOfInches%12;
            string text = $"{feet}' {inches}\"";
            if (feet == 0)
                text = $"{inches}\"";
            else if (inches == 0)
                text = $"{feet}'";
            _textView.Text = text;
            _buttonMinus.Enabled = _numberOfInches > 0;
        }

        protected override IParcelable OnSaveInstanceState()
        {
            Bundle bundle=new Bundle();
            bundle.PutParcelable(BaseClassKey,base.OnSaveInstanceState());
            bundle.PutInt(NumberOfInchesKey,_numberOfInches);
            return bundle;
        }

        protected override void OnRestoreInstanceState(IParcelable state)
        {
            Bundle bundle = state as Bundle;
            if (bundle != null)
            {
                _numberOfInches= bundle.GetInt(NumberOfInchesKey);
                base.OnRestoreInstanceState((IParcelable)bundle.GetParcelable(BaseClassKey));
            }
            else
                 base.OnRestoreInstanceState(state);

            updateControls();
        }
    }
}