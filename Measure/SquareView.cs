using System;
using Android.Content;
using Android.Util;
using Android.Views;

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