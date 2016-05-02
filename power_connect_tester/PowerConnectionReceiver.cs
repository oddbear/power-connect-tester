using System;
using Android.App;
using Android.Content;
using Android.Util;

namespace power_connect_tester
{
    [BroadcastReceiver]
    [IntentFilter(new[] {
        Intent.ActionBootCompleted,
        Intent.ActionPowerConnected,
        Intent.ActionPowerDisconnected
    })]
    public class PowerConnectionReceiver : BroadcastReceiver
    {
        public const string TAG = "PowerConnectionReceiver";

        public override void OnReceive(Context context, Intent intent)
        {
            String action = intent.Action;

            String actionName = null;

            if (action.Equals(Intent.ActionPowerConnected))
            {
                actionName = "ACTION_POWER_CONNECTED";
            }
            else if (action.Equals(Intent.ActionPowerDisconnected))
            {
                actionName = "ACTION_POWER_DISCONNECTED";
            }
            else if (action.Equals(Intent.ActionBootCompleted))
            {
                actionName = "ACTION_BOOT_COMPLETED";
            }
            else
            {
                actionName = "OTHER: " + action;
            }

            Intent newIntent = new Intent(context, typeof(MainActivity));
            newIntent.PutExtra("action", actionName);
            newIntent.SetFlags(ActivityFlags.NewTask);

            Log.Debug(TAG, "Sending intent: "+ newIntent + " for broadcast intent: " + intent);
            context.ApplicationContext.StartActivity(newIntent);
        }
    }
}

