using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomComponents.Sideway
{
    public class SidewayLayout:LinearLayout
    {
        public SidewayLayout(Context context) : base(context)
        {
        }

        public SidewayLayout(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            SetMeasuredDimension(MeasuredHeight,MeasuredWidth);
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            canvas.DrawColor(Color.LightGray);
            canvas.Save();
            canvas.Translate(0,Height);
            canvas.Rotate(-90);
            base.DispatchDraw(canvas);
            canvas.Restore();
        }
    }
}