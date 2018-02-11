using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CustomComponents.CompoundView;

namespace CustomComponents
{
    [Activity(Label = "CustomComponents", Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        LenghtPicker _lenghtPickerWidth;
        LenghtPicker _lenghtPickerHeight;
        TextView _textViewArea;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _lenghtPickerWidth = FindViewById<LenghtPicker>(Resource.Id.lenghtPickerWidth);
            _lenghtPickerWidth.LenghChanged+=LenghtPickerLenghChanged;

            _lenghtPickerHeight = FindViewById<LenghtPicker>(Resource.Id.lenghtPickerHeight);
            _lenghtPickerHeight.LenghChanged += LenghtPickerLenghChanged;

            _textViewArea = FindViewById<TextView>(Resource.Id.textViewArea);
        }

        protected override void OnResume()
        {
            base.OnResume();
            updateArea();

        }

        private void LenghtPickerLenghChanged(object sender, EventArgs e)
        {
            updateArea();
        }

        private void updateArea()
        {
            _textViewArea.Text = "Area: " + _lenghtPickerWidth.NumberOfInches * _lenghtPickerHeight.NumberOfInches;
        }
    }
}

