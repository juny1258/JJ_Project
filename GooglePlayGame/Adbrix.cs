using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using AdBrixRmAOS;
 
public class AdBrixRmSample_AOS : MonoBehaviour {
 
    void Awake(){     
        AdBrixRm.InitPlugin();     
    }
    
    void Start () {     
        AdBrixRm.setLogLevel(AdBrixRm.AdBrixLogLevel.ERROR);    
        AdBrixRm.setEventUploadCountInterval(AdBrixRm.AdBrixEventUploadCountInterval.NORMAL); 
        AdBrixRm.setEventUploadTimeInterval(AdBrixRm.AdBrixEventUploadTimeInterval.NORMAL);
    }
 
    void OnApplicationPause(bool pauseStatus) {     
        if (pauseStatus) {
            Debug.Log("go to Background");
            AdBrixRm.endSession();
        }           
        else{
            Debug.Log("go to Foreground");
            AdBrixRm.startSession();
        }           
    }
}