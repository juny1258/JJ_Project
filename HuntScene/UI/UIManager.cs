using System.Collections;
using System.Collections.Generic;
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

    public int HuntIndex;
    public int BossIndex;

    public Image PlayerStateImage;
    public Image PlayerStateImage1;

    public Transform Panels;
    public GameObject MenuPanel;
    public GameObject RankPanel;

    public Animator FlyingRewardAnimation;

    public GameObject StartInfoPanel;

    // Use this for initialization
    void Start()
    {
        // 첫 실행 시 튜토리얼 진행
        if (PlayerPrefs.GetInt("FirstOpenGame", 0) == 0)
        {
            DataController.Instance.isTutorial = true;
            
            StartInfoPanel.SetActive(true);
        }

        EventManager.AutoClickEvent += () =>
        {
            // 오토클릭 상품 결제 시 버프 이펙트 띄우기
            AutoSkill.SetActive(DataController.Instance.useAutoClick);
            Invoke("StopAutoClick", 180 + 30 * DataController.Instance.autoClickLevel);
        };

        // 실행 시 현재 코스튬 적용
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

        EventManager.SelectCostumeEvent += () =>
        {
            // 코스튬 교체 이벤트
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
        };
        
        EventManager.SelectSkinEvent += () =>
        {
            // 코스튬 교체 이벤트
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
        };
        
        InvokeRepeating("FlyRewardPlay", 60, 180);
    }

    private void StopAutoClick()
    {
        AutoSkill.SetActive(false);
        DataController.Instance.useAutoClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        GoldView.text = DataController.Instance.FormatGoldTwo(DataController.Instance.gold) + " G";
        RubyView.text = DataController.Instance.FormatGoldTwo(DataController.Instance.ruby);

        if (DataController.Instance.skill_1_cooltime > 0)
        {
            Skill1.fillAmount = DataController.Instance.skill_1_cooltime * 0.0055555556f;
        }

        if (DataController.Instance.skill_2_cooltime > 0)
        {
            Skill2.fillAmount = DataController.Instance.skill_2_cooltime * 0.0055555556f;
        }

        if (DataController.Instance.skill_3_cooltime > 0)
        {
            Skill3.fillAmount = DataController.Instance.skill_3_cooltime * 0.0055555556f;
        }

        if (DataController.Instance.skill_4_cooltime > 0)
        {
            Skill4.fillAmount = DataController.Instance.skill_4_cooltime * 0.0055555556f;
        }

        if (DataController.Instance.skill_5_cooltime > 0)
        {
            Skill5.fillAmount = DataController.Instance.skill_5_cooltime * 0.0055555556f;
        }

        if (DataController.Instance.skill_6_cooltime > 0)
        {
            Skill6.fillAmount = DataController.Instance.skill_6_cooltime * 0.0055555556f;
        }

        if (DataController.Instance.skipCoupon < 3)
        {
            DataController.Instance.couponTime -= Time.deltaTime;
            if (DataController.Instance.couponTime <= 0)
            {
                DataController.Instance.couponTime = 1800;
                DataController.Instance.skipCoupon++;
            }
        }

        for (var i = 0; i < HuntIndex; i++)
        {
            if (PlayerPrefs.GetFloat("HuntCoolTime_" + i, 0) > 0)
            {
                PlayerPrefs.SetFloat("HuntCoolTime_" + i,
                    PlayerPrefs.GetFloat("HuntCoolTime_" + i, 0) - Time.deltaTime);
            }
        }

        for (var i = 0; i < BossIndex; i++)
        {
            if (PlayerPrefs.GetFloat("BossCoolTime_" + i, 0) > 0)
            {
                PlayerPrefs.SetFloat("BossCoolTime_" + i,
                    PlayerPrefs.GetFloat("BossCoolTime_" + i, 0) - Time.deltaTime);
            }
        }
        
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
                            Application.Quit();
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