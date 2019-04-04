using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//public class SaveOnPlay : EditorWindow
//{
//    bool saved = false;
//     
//    //
//    // Add menu named "Enable Save On Play" to the Window menu
//    //
//     
//    [MenuItem ("Window/Enable Save On Play")]
//    static void Init ()
//    {
//        //
//        // Get existing open window or if none, make a new one:
//        //
// 
//        var window = (SaveOnPlay) GetWindow (typeof (SaveOnPlay));
//    }
//     
//    void Update()
//    {
//        if(EditorApplication.isPlayingOrWillChangePlaymode)
//        {
//            if(!saved)
//            {
//                saved = true;
//                 
//                EditorApplication.SaveScene();
//                 
//                Debug.Log("Saving Scene ...");
//            }
//        }
//        else
//        {
//            saved = false;
//        }
//    }
//}
