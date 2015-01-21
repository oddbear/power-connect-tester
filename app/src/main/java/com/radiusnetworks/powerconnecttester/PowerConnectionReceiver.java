package com.radiusnetworks.powerconnecttester;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.util.Log;

/**
 * Created by dyoung on 1/21/15.
 */
public class PowerConnectionReceiver extends BroadcastReceiver {
    public static final String TAG = "PowerConnectionReceiver";

    public void onReceive(Context context , Intent intent) {
        String action = intent.getAction();

        String actionName = null;

        if(action.equals(Intent.ACTION_POWER_CONNECTED)) {
            actionName = "ACTION_POWER_CONNECTED";
        }
        else if(action.equals(Intent.ACTION_POWER_DISCONNECTED)) {
            actionName = "ACTION_POWER_DISCONNECTED";
        }
        else if(action.equals(Intent.ACTION_BOOT_COMPLETED)) {
            actionName = "ACTION_BOOT_COMPLETED";
        }
        else  {
            actionName = "OTHER: "+action;
        }
        Intent newIntent = new Intent(context, MainActivity.class);
        newIntent.putExtra("action", actionName);
        newIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        Log.d(TAG, "Sending intent: "+newIntent+" for broadcast intent: "+intent);
        context.getApplicationContext().startActivity(newIntent);
    }
}
