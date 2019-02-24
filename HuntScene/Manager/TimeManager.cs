using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private string _url = "http://leatonm.net/wp-content/uploads/2017/candlepin/getdate.php";
    private string _timeData;
    private string _currentTime;
    private string _currentDate;
    private int serverTime;

    public GameObject CompensationPanel;
    public Text CompensationText;

    public GameObject AttendancePanel;
    
    private int[] attendanceRuby =
    {
        50, 80, 120, 150, 200, 250, 300
    };
    
    private DatabaseReference reference;
    private DatabaseReference userReference;

    private void Awake()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://devilhunter-b89af.firebaseio.com/");
        // 엉
        userReference = FirebaseDatabase.DefaultInstance.RootReference.Child("Rank");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void Start()
    {
        Debug.Log("==> TimeManager script is Ready.");
        StartCoroutine("AttendanceChack");
        StartCoroutine("OfflineCompensation");
    }

    // 시간 기록
    public void RecordTime()
    {
        DataController.Instance.lastPlayTime += 5;
        if (DataController.Instance.lastPlayTime > 86400)
        {
            DataController.Instance.lastPlayTime = 0;
        }
        
        var user = new UserRankData
        {
            costumeIndex = DataController.Instance.costumeIndex,
            skinIndex =  DataController.Instance.skinIndex
        };
        
        var json = JsonUtility.ToJson(user);

        if (PlayGamesPlatform.Instance.localUser.id != "")
        {
            userReference.Child(PlayGamesPlatform.Instance.localUser.id).SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    
                }
            });
        }
        else
        {
            
        }
    }

    public IEnumerator OfflineCompensation()
    {
        print("5");
        WebRequest request = WebRequest.Create(_url);
        WebResponse response = request.GetResponse();
        StreamReader stream = new StreamReader(response.GetResponseStream());
        print("6");
        try
        {
            var timeData1 = "";
            timeData1 += stream.ReadLine();
            string[] words = timeData1.Split('/');
            //timerTestLabel.text = www.text;
            Debug.Log("The date is : " + words[0]);
            Debug.Log("The time is : " + words[1]);
            var time = Convert.ToDateTime(words[0].Replace('-', '/') + " " + words[1]);

            var nowTime = float.Parse(TimeSpan.Parse(time.Add(TimeSpan.FromHours(14)).ToString().Split(' ')[1])
                .TotalSeconds
                .ToString());

            var compensationTime = nowTime - DataController.Instance.lastPlayTime;

            if (DataController.Instance.lastPlayTime != 0)
            {
                if (compensationTime < 0)
                {
                    // 다음날로 지났을 때
                    var rewardTime = 86400 - DataController.Instance.lastPlayTime;

                    SetCoolTime(rewardTime);

                    if (rewardTime >= 5000)
                    {
                        // 2시간 이상 경과
                        DataController.Instance.gold += DataController.Instance.masterDamage * 5000 / 3.8f *
                                                        DataController.Instance.collectionGoldRising;

                        DataController.Instance.compensationGold = DataController.Instance.masterDamage * 5000 / 3.8f *
                                                                   DataController.Instance.collectionGoldRising;

                        CompensationPanel.SetActive(true);
                        CompensationText.text =
                            DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage * 5000 / 3.8f *
                                                                  DataController.Instance.collectionGoldRising) +
                            "G 획득!!";

                        if ( DataController.Instance.skipCoupon == 0)
                        {
                            DataController.Instance.couponTime = 1800;
                            DataController.Instance.skipCoupon += 3;
                        }
                        else if (DataController.Instance.skipCoupon == 1)
                        {
                            DataController.Instance.couponTime = 1800;
                            DataController.Instance.skipCoupon += 2;
                        }
                        else if (DataController.Instance.skipCoupon == 2)
                        {
                            DataController.Instance.couponTime = 1800;
                            DataController.Instance.skipCoupon += 1;
                        }
                    }
                    else
                    {
                        // 2시간 미만

                        DataController.Instance.gold += DataController.Instance.masterDamage * rewardTime / 3.8f *
                                                        DataController.Instance.collectionGoldRising;

                        DataController.Instance.compensationGold =
                            DataController.Instance.masterDamage * rewardTime / 3.8f *
                            DataController.Instance.collectionGoldRising;

                        CompensationPanel.SetActive(true);
                        CompensationText.text =
                            DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage * rewardTime /
                                                                  3.8f *
                                                                  DataController.Instance.collectionGoldRising) +
                            "G 획득!!";

                        if (rewardTime < 1800 && DataController.Instance.couponTime < 3)
                        {
                            DataController.Instance.couponTime -= rewardTime;
                        }
                        else if (rewardTime >= 1800 && rewardTime < 3600)
                        {
                            if (DataController.Instance.skipCoupon < 3)
                            {
                                DataController.Instance.couponTime = 1800 - (rewardTime - 1800);
                                DataController.Instance.skipCoupon += 1;
                            }
                        }
                        else
                        {
                            if (DataController.Instance.skipCoupon < 2)
                            {
                                DataController.Instance.couponTime = 1800;
                                DataController.Instance.skipCoupon += 2;
                            }
                            else if (DataController.Instance.skipCoupon < 3)
                            {
                                DataController.Instance.couponTime = 1800;
                                DataController.Instance.skipCoupon += 1;
                            }
                        }
                    }
                }
                else
                {
                    SetCoolTime(compensationTime);

                    // 당일 재접속
                    if (compensationTime >= 5000)
                    {
                        // 2시간 이상 경과

                        DataController.Instance.gold += DataController.Instance.masterDamage * 5000 / 3.8f *
                                                        DataController.Instance.collectionGoldRising;

                        DataController.Instance.compensationGold = DataController.Instance.masterDamage * 5000 / 3.8f *
                                                                   DataController.Instance.collectionGoldRising;

                        CompensationPanel.SetActive(true);
                        CompensationText.text =
                            DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage * 5000 / 3.8f *
                                                                  DataController.Instance.collectionGoldRising) +
                            "G 획득!!";
                        
                        if ( DataController.Instance.skipCoupon == 0)
                        {
                            DataController.Instance.couponTime = 1800;
                            DataController.Instance.skipCoupon += 3;
                        }
                        else if (DataController.Instance.skipCoupon == 1)
                        {
                            DataController.Instance.couponTime = 1800;
                            DataController.Instance.skipCoupon += 2;
                        }
                        else if (DataController.Instance.skipCoupon == 2)
                        {
                            DataController.Instance.couponTime = 1800;
                            DataController.Instance.skipCoupon += 1;
                        }
                    }
                    else
                    {
                        // 2시간 미만 경과

                        DataController.Instance.gold += DataController.Instance.masterDamage * compensationTime / 3.8f *
                                                        DataController.Instance.collectionGoldRising;

                        DataController.Instance.compensationGold =
                            DataController.Instance.masterDamage * compensationTime / 3.8f *
                            DataController.Instance.collectionGoldRising;

                        CompensationPanel.SetActive(true);
                        CompensationText.text =
                            DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage *
                                                                  compensationTime / 3.8f *
                                                                  DataController.Instance.collectionGoldRising) +
                            "G 획득!!";
                        
                        if (compensationTime < 1800 && DataController.Instance.couponTime < 3)
                        {
                            DataController.Instance.couponTime -= compensationTime;
                        }
                        else if (compensationTime >= 1800 && compensationTime < 3600)
                        {
                            if (DataController.Instance.skipCoupon < 3)
                            {
                                DataController.Instance.couponTime = 1800 - (compensationTime - 1800);
                                DataController.Instance.skipCoupon += 1;
                            }
                        }
                        else
                        {
                            if (DataController.Instance.skipCoupon < 2)
                            {
                                DataController.Instance.couponTime = 1800;
                                DataController.Instance.skipCoupon += 2;
                            }
                            else if (DataController.Instance.skipCoupon < 3)
                            {
                                DataController.Instance.couponTime = 1800;
                                DataController.Instance.skipCoupon += 1;
                            }
                        }
                    }
                }
                
                CompensationPanel.SetActive(true);
            }

            DataController.Instance.lastPlayTime = float.Parse(TimeSpan
                .Parse(time.Add(TimeSpan.FromHours(14)).ToString().Split(' ')[1]).TotalSeconds.ToString());

            print("시간 -> sec : " + DataController.Instance.lastPlayTime);
            InvokeRepeating("RecordTime", 0, 5);
        }
        catch (Exception e)
        {
        }


        yield return null;
    }

    public void SetCoolTime(float time)
    {
        DataController.Instance.skill_1_cooltime -= time;
        DataController.Instance.skill_2_cooltime -= time;
        DataController.Instance.skill_3_cooltime -= time;
        DataController.Instance.skill_4_cooltime -= time;
        DataController.Instance.skill_5_cooltime -= time;
        DataController.Instance.skill_6_cooltime -= time;

        for (var i = 0; i < 5; i++)
        {
            if (PlayerPrefs.GetFloat("HuntCoolTime_" + i, 0) > 0)
            {
                PlayerPrefs.SetFloat("HuntCoolTime_" + i,
                    PlayerPrefs.GetFloat("HuntCoolTime_" + i, 0) - time);
            }
        }

        for (var i = 0; i < 3; i++)
        {
            if (PlayerPrefs.GetFloat("BossCoolTime_" + i, 0) > 0)
            {
                PlayerPrefs.SetFloat("BossCoolTime_" + i,
                    PlayerPrefs.GetFloat("BossCoolTime_" + i, 0) - time);
            }
        }
    }

    public IEnumerator AttendanceChack()
    {
        print("3");
        WebRequest request = WebRequest.Create(_url);
        WebResponse response = request.GetResponse();
        StreamReader stream = new StreamReader(response.GetResponseStream());
        print("4");
        Debug.Log("==> step 1. Getting info from internet now!");
        try
        {
            Debug.Log("==> step 2. Got the info from internet!");
            _timeData = "";
            _timeData += stream.ReadLine();

            string[] words = _timeData.Split('/');
            //timerTestLabel.text = www.text;
            Debug.Log("The date is : " + words[0]);
            Debug.Log("The time is : " + words[1]);

            var time = Convert.ToDateTime(words[0].Replace('-', '/') + " " + words[1]);

            Debug.Log("The time is : " + time.Add(TimeSpan.FromHours(14)));

            serverTime = int.Parse(time.Add(TimeSpan.FromHours(14)).ToString().Split('/')[1]);

            print("현재 시간 : " + serverTime);

            // 출석체크
            if (DataController.Instance.lastAttendance == 0)
            {
                // 게임을 키고 처음 출석을 할 때
                DataController.Instance.lastAttendance = serverTime;
                DataController.Instance.attendanceIndex++;

                DataController.Instance.ruby += attendanceRuby[(int) DataController.Instance.attendanceIndex - 1];

                NotificationManager.Instance.SetNotification(
                    "루비 " + attendanceRuby[(int) DataController.Instance.attendanceIndex - 1] + "개 획득!!");

                AttendancePanel.SetActive(PlayerPrefs.GetInt("FirstOpenGame", 0) != 0);

                DataController.Instance.faustCount = 10;
            }
            else
            {
                // 출석체크
                if (serverTime - DataController.Instance.lastAttendance == 1)
                {
                    // 연속 출석체크
                    if (DataController.Instance.attendanceIndex < 7)
                    {
                        // 7일차 이전
                        DataController.Instance.lastAttendance = serverTime;
                        DataController.Instance.attendanceIndex++;
                        
                        DataController.Instance.ruby += attendanceRuby[(int) DataController.Instance.attendanceIndex - 1];

                        NotificationManager.Instance.SetNotification(
                            "루비 " + attendanceRuby[(int) DataController.Instance.attendanceIndex - 1] + "개 획득!!");
                    
                        AttendancePanel.SetActive(PlayerPrefs.GetInt("FirstOpenGame", 0) != 0);
                        DataController.Instance.faustCount = 10;
                    }
                    else
                    {
                        // 7일차 출석까지 한 단계에서는 1일차로 돌아간다
                        DataController.Instance.lastAttendance = serverTime;
                        DataController.Instance.attendanceIndex = 1;
                        
                        DataController.Instance.ruby += attendanceRuby[(int) DataController.Instance.attendanceIndex - 1];

                        NotificationManager.Instance.SetNotification(
                            "루비 " + attendanceRuby[(int) DataController.Instance.attendanceIndex - 1] + "개 획득!!");
                    
                        AttendancePanel.SetActive(PlayerPrefs.GetInt("FirstOpenGame", 0) != 0);
                        DataController.Instance.faustCount = 10;
                    }
                }
                else if (serverTime - DataController.Instance.lastAttendance == 0)
                {
                    // 출석한 당일 연속 접속 (출석체크x)
                    print("4");
                }
                else
                {
                    // 출석한 다음날 연속 접속 안 함
                    DataController.Instance.lastAttendance = serverTime;
                    DataController.Instance.attendanceIndex = 1;
                    
                    DataController.Instance.ruby += attendanceRuby[(int) DataController.Instance.attendanceIndex - 1];

                    NotificationManager.Instance.SetNotification(
                        "루비 " + attendanceRuby[(int) DataController.Instance.attendanceIndex - 1] + "개 획득!!");
                    
                    AttendancePanel.SetActive(PlayerPrefs.GetInt("FirstOpenGame", 0) != 0);
                    DataController.Instance.faustCount = 10;
                }
            }

            // 접속하지 않은 동안 벌린 돈


            //setting current time
            _currentDate = words[0];
            _currentTime = words[1];
        }
        catch (Exception e)
        {
        }

        yield return null;
    }
}