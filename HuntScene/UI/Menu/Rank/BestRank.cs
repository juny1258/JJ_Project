using System.Collections.Generic;
using System.Linq;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

public class BestRank : MonoBehaviour
{
    public Image[] PlayerImage;
    public Text[] PlayerName;
    public Text[] Score;

    public GameObject LoadingPanel;

    private DatabaseReference userReference;

    private void Awake()
    {
        userReference = FirebaseManager.Instance.Reference.Child("FaustRank1");
    }

    private void OnEnable()
    {

        LoadingPanel.SetActive(true);

        userReference.Reference.OrderByChild("faustDamage").LimitToFirst(20).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                var i = 0;
                foreach (var child in task.Result.Children)
                {
                    var userData = JsonUtility.FromJson<UserRankData>(child.GetRawJsonValue());
                    if (userData.isHack == 0)
                    {
                        if (userData.skinIndex == 0)
                        {
                            PlayerImage[i].sprite =
                                Resources.Load("Player/Costume" + userData.costumeIndex + "/Costume",
                                    typeof(Sprite)) as Sprite;
                        }
                        else
                        {
                            PlayerImage[i].sprite =
                                Resources.Load("Player/Skin" + userData.skinIndex + "/Costume",
                                    typeof(Sprite)) as Sprite;
                        }

                        print(child.Key);

                        PlayerName[i].text = userData.userName;
                        Score[i].text = DataController.Instance.FormatGoldTwo(-userData.faustDamage);
//
                        i++;
                        if (i == 3)
                        {
                            LoadingPanel.SetActive(false);
                            break;
                        }
                    }

                    print(JsonUtility.FromJson<UserRankData>(child.GetRawJsonValue()).faustDamage);
                }
            }
        });
//        PlayGamesPlatform.Instance.LoadScores(
//            GPGSIds.leaderboard,
//            LeaderboardStart.TopScores,
//            3,
//            LeaderboardCollection.Public,
//            LeaderboardTimeSpan.AllTime,
//            data =>
//            {
//                if (data.Valid)
//                {
//                    Social.LoadUsers(data.Scores.Select(score => score.userID).ToArray(), profiles =>
//                    {
//                        if (profiles.Length >= 3)
//                        {
//                            var index = 0;
//                            userReference.Child(profiles[0].id).GetValueAsync().ContinueWith(task =>
//                            {
//                                if (task.IsCompleted)
//                                {
//                                    var userData = JsonUtility.FromJson<UserRankData>(task.Result.GetRawJsonValue());
//                                    if (userData.skinIndex == 0)
//                                    {
//                                        PlayerImage[0].sprite =
//                                            Resources.Load("Player/Costume" + userData.costumeIndex + "/Costume",
//                                                typeof(Sprite)) as Sprite;
//                                    }
//                                    else
//                                    {
//                                        PlayerImage[0].sprite =
//                                            Resources.Load("Player/Skin" + userData.skinIndex + "/Costume",
//                                                typeof(Sprite)) as Sprite;
//                                    }
//
//                                    PlayerName[0].text = profiles[0].userName;
//                                    Score[0].text = GetThousandCommaText(data.Scores[0].value);
//
//                                    index++;
//                                    if (index == 3)
//                                    {
//                                        LoadingPanel.SetActive(false);
//                                    }
//                                }
//                                else if (task.IsFaulted)
//                                {
//                                }
//                            });
//
//                            userReference.Child(profiles[1].id).GetValueAsync().ContinueWith(task =>
//                            {
//                                if (task.IsCompleted)
//                                {
//                                    var userData = JsonUtility.FromJson<UserRankData>(task.Result.GetRawJsonValue());
//                                    if (userData.skinIndex == 0)
//                                    {
//                                        PlayerImage[1].sprite =
//                                            Resources.Load("Player/Costume" + userData.costumeIndex + "/Costume",
//                                                typeof(Sprite)) as Sprite;
//                                    }
//                                    else
//                                    {
//                                        PlayerImage[1].sprite =
//                                            Resources.Load("Player/Skin" + userData.skinIndex + "/Costume",
//                                                typeof(Sprite)) as Sprite;
//                                    }
//
//                                    PlayerName[1].text = profiles[1].userName;
//                                    Score[1].text = GetThousandCommaText(data.Scores[1].value);
//
//                                    index++;
//                                    if (index == 3)
//                                    {
//                                        LoadingPanel.SetActive(false);
//                                    }
//                                }
//                                else if (task.IsFaulted)
//                                {
//                                }
//                            });
//
//                            userReference.Child(profiles[2].id).GetValueAsync().ContinueWith(task =>
//                            {
//                                if (task.IsCompleted)
//                                {
//                                    var userData = JsonUtility.FromJson<UserRankData>(task.Result.GetRawJsonValue());
//                                    if (userData.skinIndex == 0)
//                                    {
//                                        PlayerImage[2].sprite =
//                                            Resources.Load("Player/Costume" + userData.costumeIndex + "/Costume",
//                                                typeof(Sprite)) as Sprite;
//                                    }
//                                    else
//                                    {
//                                        PlayerImage[2].sprite =
//                                            Resources.Load("Player/Skin" + userData.skinIndex + "/Costume",
//                                                typeof(Sprite)) as Sprite;
//                                    }
//
//                                    PlayerName[2].text = profiles[2].userName;
//                                    Score[2].text = GetThousandCommaText(data.Scores[2].value);
//
//                                    index++;
//                                    if (index == 3)
//                                    {
//                                        LoadingPanel.SetActive(false);
//                                    }
//                                }
//                                else if (task.IsFaulted)
//                                {
//                                }
//                            });
//                        }
//                        else
//                        {
//                            NotificationManager.Instance.SetNotification("데이터가 부족합니다.");
//                        }
//                    });
//                }
//                else
//                {
//                    NotificationManager.Instance.SetNotification("인터넷 연결을 확인해주세요.");
//                }
//            });

//        userReference.GetValueAsync().ContinueWith(task =>
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

    public string GetThousandCommaText(float data)
    {
        return string.Format("{0:#,###}", data);
    }
}