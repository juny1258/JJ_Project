using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text GoldView;
    public Text RubyView;

    public Image Skill1;
    public Image Skill2;
    public Image Skill3;
    public Image Skill4;
    public Image Skill5;
    public Image Skill6;

    public GameObject AutoSkill;

    public Image PlayerStateImage;
    public Image PlayerStateImage1;

    public Transform Panels;
    public GameObject MenuPanel;
    public GameObject RankPanel;

    public Animator FlyingRewardAnimation;

    public GameObject StartInfoPanel;

    public GameObject BanPanel;

    public GameObject QuitPanel;

    private DatabaseReference userReference;

    private void Awake()
    {
        if (Social.localUser.authenticated)
        {
            userReference = FirebaseManager.Instance.Reference.Child("FaustRank1");
        }
    }

    // Use this for initialization
    void Start()
    {
        // 첫 실행 시 튜토리얼 진행
        if (PlayerPrefs.GetInt("FirstOpenGame", 0) == 0)
        {
            DataController.Instance.isTutorial = true;

            StartInfoPanel.SetActive(true);
        }

        if (PlayerPrefs.GetFloat("Merchant", 0) == 0)
        {
            if (AndroidUtil.IsAppInstalled("com.juny.merchant"))
            {
                PlayerPrefs.SetFloat("Merchant", 1);
                DataController.Instance.ruby += 2000;
                NotificationManager.Instance.SetNotification2("루비 2,000개가 지급되었습니다.");
            }
        }

        SetCostume();

        EventManager.AutoClickEvent += SetAutoClick;

        EventManager.SelectCostumeEvent += SetCostume;

        EventManager.SelectSkinEvent += SetCostume;

        EventManager.PlaySkillEvent += ShowSkillCoolTime;

        InvokeRepeating("FlyRewardPlay", 60, 180);

        InvokeRepeating("ShowSkillCoolTime", 0, 0.2f);

        InvokeRepeating("AddCool", 1, 1);

        if (Social.localUser.authenticated)
        {
            userReference.Child(PlayGamesPlatform.Instance.localUser.id).GetValueAsync().ContinueWith(
                task =>
                {
                    if (task.IsCompleted)
                    {
                        var userData = JsonUtility.FromJson<UserRankData>(task.Result.GetRawJsonValue());
                        if (userData.isHack >= 1)
                        {
                            BanPanel.SetActive(true);
                            task.Result.Child("isHack").Reference.SetValueAsync(2);
                        }
                    }
                });   
        }
    }

    private void OnDestroy()
    {
        EventManager.AutoClickEvent -= SetAutoClick;

        EventManager.SelectCostumeEvent -= SetCostume;

        EventManager.SelectSkinEvent -= SetCostume;

        EventManager.PlaySkillEvent -= ShowSkillCoolTime;
    }

    private void SetAutoClick()
    {
        // 오토클릭 상품 결제 시 버프 이펙트 띄우기
        AutoSkill.SetActive(DataController.Instance.useAutoClick);
        Invoke("StopAutoClick", 180 + 30 * DataController.Instance.autoClickLevel);

        // 물약 사용 횟수 증가
        DataController.Instance.autoClickIndex++;
        if (DataController.Instance.autoClickIndex == 10)
        {
            // 사용 횟수 10 달성 시 지속시간 증가
            DataController.Instance.autoClickIndex = 0;
            DataController.Instance.autoClickLevel++;
        }
    }

    private void SetCostume()
    {
        if (DataController.Instance.skinIndex == 0)
        {
            PlayerStateImage.sprite =
                Resources.Load("Player/Costume" + DataController.Instance.costumeIndex + "/Costume",
                    typeof(Sprite)) as Sprite;

            PlayerStateImage1.sprite =
                Resources.Load("Player/Costume" + DataController.Instance.costumeIndex + "/Costume",
                    typeof(Sprite)) as Sprite;
        }
        else
        {
            PlayerStateImage.sprite =
                Resources.Load("Player/Skin" + DataController.Instance.skinIndex + "/Costume",
                    typeof(Sprite)) as Sprite;

            PlayerStateImage1.sprite =
                Resources.Load("Player/Skin" + DataController.Instance.skinIndex + "/Costume",
                    typeof(Sprite)) as Sprite;
        }
    }

    private void StopAutoClick()
    {
        AutoSkill.SetActive(false);
        DataController.Instance.useAutoClick = false;
    }

    private void ShowSkillCoolTime()
    {
        if (DataController.Instance.skill_1_cooltime > 0)
        {
            Skill1.fillAmount = DataController.Instance.skill_1_cooltime * 0.0167f;
        }
        else
        {
            Skill1.fillAmount = 0;
        }

        if (DataController.Instance.skill_2_cooltime > 0)
        {
            Skill2.fillAmount = DataController.Instance.skill_2_cooltime * 0.0167f;
        }
        else
        {
            Skill2.fillAmount = 0;
        }

        if (DataController.Instance.skill_3_cooltime > 0)
        {
            Skill3.fillAmount = DataController.Instance.skill_3_cooltime * 0.0167f;
        }
        else
        {
            Skill3.fillAmount = 0;
        }

        if (DataController.Instance.skill_4_cooltime > 0)
        {
            Skill4.fillAmount = DataController.Instance.skill_4_cooltime * 0.0167f;
        }
        else
        {
            Skill4.fillAmount = 0;
        }

        if (DataController.Instance.skill_5_cooltime > 0)
        {
            Skill5.fillAmount = DataController.Instance.skill_5_cooltime * 0.0167f;
        }
        else
        {
            Skill5.fillAmount = 0;
        }

        if (DataController.Instance.skill_6_cooltime > 0)
        {
            Skill6.fillAmount = DataController.Instance.skill_6_cooltime * 0.0167f;
        }
        else
        {
            Skill6.fillAmount = 0;
        }
    }

    private void AddCool()
    {
        DataController.Instance.huntCool++;
        DataController.Instance.bossCool++;
        DataController.Instance.skipCool++;
    }

    // Update is called once per frame
    void Update()
    {
        GoldView.text = DataController.Instance.FormatGoldTwo(DataController.Instance.gold) + " G";
        RubyView.text = DataController.Instance.FormatGoldTwo(DataController.Instance.ruby);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var i = 0;
            foreach (Transform panel in Panels)
            {
                if (!panel.gameObject.active)
                {
                    i++;
                    if (i == Panels.childCount)
                    {
                        if (!MenuPanel.active && !RankPanel.active)
                        {
                            QuitPanel.SetActive(true);
                        }
                    }
                }
            }
        }
    }

    public void FlyRewardPlay()
    {
        FlyingRewardAnimation.Play("FlyReward", 0, 0);
    }
}