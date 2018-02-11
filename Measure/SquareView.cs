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

namespace CustomComponents.Measure
{
    public class SquareView:View 
    {
        public SquareView(Context context) : base(context)
        {
        }

        public SquareView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec,heightMeasureSpec);
            
            int lenght = Math.Min(MeasuredWidth,MeasuredHeight);

            SetMeasuredDimension(lenght,lenght);
        }
    }
}