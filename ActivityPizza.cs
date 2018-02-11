using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomComponents.Draw;

namespace CustomComponents
{
    [Activity(Label = "ActivityPizza")]
    public class ActivityPizza : Activity
    {
        Button _buttonCuts;
        Pizza _firstPizza;
        int _numberOfCuts = 1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layoutPizza);
            _firstPizza = FindViewById<Pizza>(Resource.Id.firstPizza);
            _buttonCuts = FindViewById<Button>(Resource.Id.buttonCuts);
            _buttonCuts.Click+=ButtonCutsOnClick;
            _numberOfCuts = 11;


        }

        private void ButtonCutsOnClick(object sender, EventArgs eventArgs)
        {
            _firstPizza.SetNumberOfCuts(_numberOfCuts);
            _numberOfCuts++;
        }
    }
}