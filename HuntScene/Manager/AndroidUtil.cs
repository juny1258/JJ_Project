using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidUtil : MonoBehaviour 
{

    public static bool IsAppInstalled(string bundleID)
    {
        if (!Debug.isDebugBuild)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject packageManager = currentActivity.Call<AndroidJavaObject>("getPackageManager");

            AndroidJavaObject launchIntent = null;

            //if the app is installed, no errors. Else, doesn't get past next line
            try
            {
                launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", bundleID);
            }
            catch (Exception ex)
            {
                Debug.Log("exception" + ex.Message);
            }

            return launchIntent != null;
        }

        return false;
    }
}
