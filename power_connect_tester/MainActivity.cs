using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Android.Util;
using Android.Views;

namespace power_connect_tester
{
    [Activity(
        Label = "power-connect-tester",
        MainLauncher = true,
        Icon = "@drawable/ic_launcher",
        Theme = "@style/AppTheme",
        LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
    )]
    public class MainActivity : ActionBarActivity //Deprecated, use Toolbar instead?
    {
        public const string TAG = "MainActivity";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
        }

        protected override void OnResume()
        {
            base.OnResume();
            TextView textView = (TextView)FindViewById(Resource.Id.events);
            Intent intent = this.Intent;
            this.Intent = null;
            string action = null;
            Log.Debug(TAG, "Got intent: " + intent);
            if (intent != null && intent.Extras != null)
            {
                action = intent.GetStringExtra("action");
            }
            if (action == null)
            {
                textView.SetText(textView.Text + "\nActivity Resumed", TextView.BufferType.Normal); //TextView.BufferType correct?
            }
            else
            {
                textView.SetText(textView.Text + "\nReceived action " + action, TextView.BufferType.Normal); //TextView.BufferType correct?
            }

        }

        protected override void OnNewIntent(Intent intent)
        {
            if (intent != null)
            {
                Intent = intent;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // Inflate the menu; this adds items to the action bar if it is present.
            this.MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            // Handle action bar item clicks here. The action bar will
            // automatically handle clicks on the Home/Up button, so long
            // as you specify a parent activity in AndroidManifest.xml.
            int id = item.ItemId;

            //noinspection SimplifiableIfStatement
            if (id == Resource.String.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}


