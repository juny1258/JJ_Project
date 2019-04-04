using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Coupon : MonoBehaviour
{
    private DatabaseReference couponReference;

    public Text InputText;

    private void Start()
    {
        couponReference = FirebaseManager.Instance.Reference.Child("coupon");
    }

    public void OKButton()
    {
        if (InputText.text.Contains("DevilCoupon"))
        {
            if (PlayerPrefs.GetFloat("OverlapCoupon", 0) == 0)
            {
                // 중복쿠폰
                DataController.Instance.ruby += 1000;
                PlayerPrefs.SetFloat("OverlapCoupon", 1);

                NotificationManager.Instance.SetNotification2("루비 1,000개 획득!!");
            }
            else
            {
            }
        }
        else if (InputText.text.Contains("skinpakage_ssucksso"))
        {
            if (PlayerPrefs.GetFloat("SsuckSso", 0) == 0)
            {
                DataController.Instance.ruby += 1000;

                DataController.Instance.skinDamage += 1;

                DataController.Instance.UpdateDamage();
                DataController.Instance.UpdateCritical();
                DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();
                
                PlayerPrefs.SetFloat("Skin_100", 1);

                DataController.Instance.skinIndex = 100;

                EventManager.Instance.SelectSkin();

                NotificationManager.Instance.SetNotification2("상단 메뉴에서 스킨을 바꿀 수 있습니다.");

                PlayerPrefs.SetFloat("SsuckSso", 1);
            }
            else
            {
                NotificationManager.Instance.SetNotification("이미 사용된 쿠폰입니다.");
            }
        }
        else if (InputText.text.Contains("startpakage_"))
        {
            couponReference.GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    NotificationManager.Instance.SetNotification(task.Exception.Message);
                }
                else if (task.IsCompleted)
                {
                    // success
                    var dataSnapshot = task.Result;

                    foreach (var coupon in dataSnapshot.Children)
                    {
                        if (coupon.Key.Contains(InputText.text))
                        {
                            if (int.Parse(coupon.Value.ToString()) == 1)
                            {
                                if (PlayerPrefs.GetFloat("NoAds", 0) == 0)
                                {
                                    coupon.Reference.SetValueAsync(0);
                                    PlayerPrefs.SetFloat("NoAds", 1);
                                    DataController.Instance.ruby += 4000;
                                    DataController.Instance.sapphire += 2000;
                                    DataController.Instance.devilStone += 2000;
                                    NotificationManager.Instance.SetNotification2("아이템이 지급되었습니다.");
                                }
                                else
                                {
                                    coupon.Reference.SetValueAsync(2);
                                    NotificationManager.Instance.SetNotification("이미 아이템을 소유하고 계십니다.");
                                }
                            }
                            else
                            {
                                NotificationManager.Instance.SetNotification("이미 사용한 쿠폰입니다.");
                            }
                        }
                    }
                }
            });
        }
        else if (InputText.text.Contains("skinpakage_"))
        {
            couponReference.GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    NotificationManager.Instance.SetNotification(task.Exception.Message);
                }
                else if (task.IsCompleted)
                {
                    // success
                    var dataSnapshot = task.Result;

                    foreach (var coupon in dataSnapshot.Children)
                    {
                        if (coupon.Key.Contains(InputText.text))
                        {
                            if (int.Parse(coupon.Value.ToString()) == 1)
                            {
                                if (PlayerPrefs.GetFloat("Skin_1", 0) == 0)
                                {
                                    coupon.Reference.SetValueAsync(0);

                                    DataController.Instance.ruby += 30000;
                                    DataController.Instance.skinDamage += 5;
                                    DataController.Instance.skinCriticalPer += 10;

                                    DataController.Instance.UpdateDamage();
                                    DataController.Instance.UpdateCritical();

                                    PlayerPrefs.SetFloat("Skin_1", 1);

                                    DataController.Instance.skinIndex = 1;

                                    EventManager.Instance.SelectSkin();

                                    NotificationManager.Instance.SetNotification2("상단 메뉴에서 스킨을 바꿀 수 있습니다.");
                                }
                                else
                                {
                                    coupon.Reference.SetValueAsync(10);
                                    NotificationManager.Instance.SetNotification("이미 아이템을 소유하고 계십니다.");
                                }
                            }
                            else if (int.Parse(coupon.Value.ToString()) == 2)
                            {
                                if (PlayerPrefs.GetFloat("Skin_2", 0) == 0)
                                {
                                    coupon.Reference.SetValueAsync(0);

                                    DataController.Instance.ruby += 30000;
                                    DataController.Instance.skinDamage += 5;
                                    DataController.Instance.skinCriticalPer += 10;

                                    DataController.Instance.UpdateDamage();
                                    DataController.Instance.UpdateCritical();

                                    PlayerPrefs.SetFloat("Skin_2", 1);

                                    DataController.Instance.skinIndex = 2;

                                    EventManager.Instance.SelectSkin();

                                    NotificationManager.Instance.SetNotification2("상단 메뉴에서 스킨을 바꿀 수 있습니다.");
                                }
                                else
                                {
                                    coupon.Reference.SetValueAsync(10);
                                    NotificationManager.Instance.SetNotification("이미 아이템을 소유하고 계십니다.");
                                }
                            }
                        }
                    }
                }
            });
        }
        else if (InputText.text.Contains("ruby_"))
        {
            couponReference.GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    NotificationManager.Instance.SetNotification(task.Exception.Message);
                }
                else if (task.IsCompleted)
                {
                    // success
                    var dataSnapshot = task.Result;

                    foreach (var coupon in dataSnapshot.Children)
                    {
                        if (coupon.Key.Contains(InputText.text))
                        {
                            if (int.Parse(coupon.Value.ToString()) > 0)
                            {
                                DataController.Instance.ruby += int.Parse(coupon.Value.ToString());
                                NotificationManager.Instance.SetNotification2(
                                    "루비 " + int.Parse(coupon.Value.ToString()) + "개 획득!!");

                                coupon.Reference.SetValueAsync(0);
                            }
                            else
                            {
                                NotificationManager.Instance.SetNotification("이미 사용한 쿠폰입니다.");
                            }
                        }
                    }
                }
            });
        }
        else if (InputText.text.Contains("sapphire_"))
        {
            couponReference.GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    NotificationManager.Instance.SetNotification(task.Exception.Message);
                }
                else if (task.IsCompleted)
                {
                    // success
                    var dataSnapshot = task.Result;

                    foreach (var coupon in dataSnapshot.Children)
                    {
                        if (coupon.Key.Contains(InputText.text))
                        {
                            if (int.Parse(coupon.Value.ToString()) > 0)
                            {
                                DataController.Instance.sapphire += int.Parse(coupon.Value.ToString());
                                NotificationManager.Instance.SetNotification2(
                                    "사파이어 " + int.Parse(coupon.Value.ToString()) + "개 획득!!");

                                coupon.Reference.SetValueAsync(0);
                            }
                            else
                            {
                                NotificationManager.Instance.SetNotification("이미 사용한 쿠폰입니다.");
                            }
                        }
                    }
                }
            });
        }
        else if (InputText.text.Contains("skipcoupon_"))
        {
            couponReference.GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    NotificationManager.Instance.SetNotification(task.Exception.Message);
                }
                else if (task.IsCompleted)
                {
                    // success
                    var dataSnapshot = task.Result;

                    foreach (var coupon in dataSnapshot.Children)
                    {
                        if (coupon.Key.Contains(InputText.text))
                        {
                            if (int.Parse(coupon.Value.ToString()) > 0)
                            {
                                DataController.Instance.skipCoupon += int.Parse(coupon.Value.ToString());
                                NotificationManager.Instance.SetNotification2(
                                    "소탕권 " + int.Parse(coupon.Value.ToString()) + "개 획득!!");

                                coupon.Reference.SetValueAsync(0);
                            }
                            else
                            {
                                NotificationManager.Instance.SetNotification("이미 사용한 쿠폰입니다.");
                            }
                        }
                    }
                }
            });
        }
        else if (InputText.text.Contains("potion_"))
        {
            couponReference.GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    NotificationManager.Instance.SetNotification(task.Exception.Message);
                }
                else if (task.IsCompleted)
                {
                    // success
                    var dataSnapshot = task.Result;

                    foreach (var coupon in dataSnapshot.Children)
                    {
                        if (coupon.Key.Contains(InputText.text))
                        {
                            if (int.Parse(coupon.Value.ToString()) > 0)
                            {
                                DataController.Instance.autoClickPotion += int.Parse(coupon.Value.ToString());
                                DataController.Instance.goldBuffPotion += int.Parse(coupon.Value.ToString());

                                NotificationManager.Instance.SetNotification2(
                                    "물약 " + int.Parse(coupon.Value.ToString()) + "개 획득!!");

                                coupon.Reference.SetValueAsync(0);
                            }
                            else
                            {
                                NotificationManager.Instance.SetNotification("이미 사용한 쿠폰입니다.");
                            }
                        }
                    }
                }
            });
        }
        else if (InputText.text.Contains("devilstone_"))
        {
            couponReference.GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    NotificationManager.Instance.SetNotification(task.Exception.Message);
                }
                else if (task.IsCompleted)
                {
                    // success
                    var dataSnapshot = task.Result;

                    foreach (var coupon in dataSnapshot.Children)
                    {
                        if (coupon.Key.Contains(InputText.text))
                        {
                            if (int.Parse(coupon.Value.ToString()) > 0)
                            {
                                DataController.Instance.devilStone += int.Parse(coupon.Value.ToString());
                                NotificationManager.Instance.SetNotification2(
                                    "데빌스톤 " + int.Parse(coupon.Value.ToString()) + "개 획득!!");

                                coupon.Reference.SetValueAsync(0);
                            }
                            else
                            {
                                NotificationManager.Instance.SetNotification("이미 사용한 쿠폰입니다.");
                            }
                        }
                    }
                }
            });
        }
        else if (InputText.text.Contains("huntReset_"))
        {
            couponReference.GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    NotificationManager.Instance.SetNotification(task.Exception.Message);
                }
                else if (task.IsCompleted)
                {
                    // success
                    var dataSnapshot = task.Result;

                    foreach (var coupon in dataSnapshot.Children)
                    {
                        if (coupon.Key.Contains(InputText.text))
                        {
                            if (int.Parse(coupon.Value.ToString()) == 1)
                            {
                                coupon.Reference.SetValueAsync(0);
                                DataController.Instance.finalHuntLevel = 0;
                                DataController.Instance.finalBossLevel = 0;

                                NotificationManager.Instance.SetNotification2("데이터 안정화 완료");
                            }
                        }
                    }
                }
            });
        }
        else if (InputText.text.Contains("petStone_"))
        {
            couponReference.GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    NotificationManager.Instance.SetNotification(task.Exception.Message);
                }
                else if (task.IsCompleted)
                {
                    // success
                    var dataSnapshot = task.Result;

                    foreach (var coupon in dataSnapshot.Children)
                    {
                        if (coupon.Key.Contains(InputText.text))
                        {
                            if (int.Parse(coupon.Value.ToString()) > 0)
                            {
                                DataController.Instance.petStone += int.Parse(coupon.Value.ToString());
                                NotificationManager.Instance.SetNotification2(
                                    "영혼석 " + int.Parse(coupon.Value.ToString()) + "개 획득!!");

                                coupon.Reference.SetValueAsync(0);
                            }
                            else
                            {
                                NotificationManager.Instance.SetNotification("이미 사용한 쿠폰입니다.");
                            }
                        }
                    }
                }
            });
        }
        else if (InputText.text.Contains("challenge_"))
        {
            couponReference.GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    NotificationManager.Instance.SetNotification(task.Exception.Message);
                }
                else if (task.IsCompleted)
                {
                    // success
                    var dataSnapshot = task.Result;

                    foreach (var coupon in dataSnapshot.Children)
                    {
                        if (coupon.Key.Contains(InputText.text))
                        {
                            if (int.Parse(coupon.Value.ToString()) > 0)
                            {
                                DataController.Instance.faustCount = 10;
                                DataController.Instance.dungeonCount = 10;
                                NotificationManager.Instance.SetNotification2("도전 횟수 초기화 완료!!");

                                coupon.Reference.SetValueAsync(0);
                            }
                            else
                            {
                                NotificationManager.Instance.SetNotification("이미 사용한 쿠폰입니다.");
                            }
                        }
                    }
                }
            });
        }
        else if (InputText.text.Contains("spritstone_"))
        {
            couponReference.GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    NotificationManager.Instance.SetNotification(task.Exception.Message);
                }
                else if (task.IsCompleted)
                {
                    // success
                    var dataSnapshot = task.Result;

                    foreach (var coupon in dataSnapshot.Children)
                    {
                        if (coupon.Key.Contains(InputText.text))
                        {
                            if (int.Parse(coupon.Value.ToString()) > 0)
                            {
                                DataController.Instance.petStone += int.Parse(coupon.Value.ToString());
                                NotificationManager.Instance.SetNotification2(
                                    "영혼석 " + int.Parse(coupon.Value.ToString()) + "개 획득!!");

                                coupon.Reference.SetValueAsync(0);
                            }
                            else
                            {
                                NotificationManager.Instance.SetNotification("이미 사용한 쿠폰입니다.");
                            }
                        }
                    }
                }
            });
        }
        else
        {
            NotificationManager.Instance.SetNotification("존재하지 않는 쿠폰입니다.");
        }
    }
}