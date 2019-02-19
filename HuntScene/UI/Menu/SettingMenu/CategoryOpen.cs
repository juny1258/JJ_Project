using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class CategoryOpen : MonoBehaviour
{
    public GameObject CategoryPanel;

    private DatabaseReference couponReference;

    private bool isOpen;

    private void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://devilhunter-b89af.firebaseio.com/");
        // 엉
        couponReference = FirebaseDatabase.DefaultInstance.RootReference.Child("coupon");
    }

    public void OnClick()
    {
        if (isOpen)
        {
            CategoryPanel.SetActive(false);
            isOpen = false;
        }
        else
        {
            CategoryPanel.SetActive(true);
            isOpen = true;
        }

//        PlayGamesPlatform.Instance.LoadScores(
//            GPGSIds.leaderboard,
//            LeaderboardStart.TopScores,
//            2,
//            LeaderboardCollection.Public,
//            LeaderboardTimeSpan.AllTime,
//            data =>
//            {
//                if (data.Valid)
//                {
//                    Social.LoadUsers(data.Scores.Select(score => score.userID).ToArray(), profiles =>
//                    {
//                        GetComponentInChildren<Text>().text = "고유ID" + profiles[0].id + "\n" +
//                                                              profiles[0].userName + "의 점수 : " +
//                                                              data.Scores[0].value + "\n\n" +
//                                                              "고유ID" + profiles[1].id + "\n" +
//                                                              profiles[1].userName + "의 점수 : " +
//                                                              data.Scores[1].value;
//                    });   
//                }
//                else
//                {
//                    GetComponentInChildren<Text>().text = "데이터 없음";
//                }
//            });

//        couponReference.GetValueAsync().ContinueWith(task =>
//        {
//            print("엉");
//            if (task.IsFaulted)
//            {
//                // fail
//                GetComponentInChildren<Text>().text = "실패";
//            }
//            else if (task.IsCompleted)
//            {
//                // success
//                DataSnapshot dataSnapshot = task.Result;
//
//                foreach (var coupon in dataSnapshot.Children)
//                {
//                    GetComponentInChildren<Text>().text = "키 : " + coupon.Key + "값 : " + coupon.Value + "\n";
//                }
//            }
//        });
    }
}