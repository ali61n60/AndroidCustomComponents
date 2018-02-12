using Android.App;
using Android.OS;

namespace CustomComponents.Sideway
{
    [Activity(Label = "ActivitySideway", MainLauncher = true)]
    public class ActivitySideway : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layoutDispatchView);
        }
    }
}