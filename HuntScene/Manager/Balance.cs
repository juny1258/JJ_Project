using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
//        if (Debug.isDebugBuild)
//        {
//            for (int i = 0; i < 16; i++)
//            {
//                PlayerPrefs.SetInt("CollectionItem_" + i , 50);
//            }
//        }
        
        if (PlayerPrefs.GetInt("CollectionItem_4", 0) >= 20)
        {
            PlayerPrefs.SetInt("CollectionItem_4", 20);
            DataController.Instance.collectionCoolTime = 40;
        }

        DataController.Instance.collectionDamage = 0f;
        DataController.Instance.collectionFaustDamage = 0.5f;
        DataController.Instance.collectionGoldRising = 1;

        DataController.Instance.collectionRebirthRising = 1;

        for (int i = 0; i < 16; i++)
        {
            print(i);
            if (PlayerPrefs.GetInt("CollectionItem_" + i, 0) < 50)
            {
                DataController.Instance.collectionDamage += 
                    PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.03f;
                
                switch (i)
                {
                    case 0:
                        DataController.Instance.collectionHp = PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.02f;
                        break;
                    case 1:
                        DataController.Instance.collectionCriticalPer = PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.5f;
                        break;
                    case 2:
                        DataController.Instance.collectionAngerTime = PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.01f;
                        break;
                    case 3:
                        DataController.Instance.collectionGoldRising += PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.01f;
                        break;
                    case 4:
                        DataController.Instance.collectionCoolTime = PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 2;
                        break;
                    case 5:
                        DataController.Instance.collectionAngerDamage = PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.02f;
                        break;
                    case 6:
                        DataController.Instance.collectionRubyRising = PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 1;
                        break;
                    case 7:
                        DataController.Instance.collectionSappaireRising = PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 1;
                        break;
                    case 8:
                        DataController.Instance.collectionGoldRising += PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.01f;
                        break;
                    case 9:
                        DataController.Instance.collectionDevilStoneRising = PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 1;
                        break;
                    case 10:
                        DataController.Instance.collectionRebirthRising += PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.02f;
                        break;
                    case 11:
                        DataController.Instance.collectionCriticalDamage = PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.03f;
                        break;
                    case 12:
                        DataController.Instance.collectionDamage += PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.03f;
                        break;
                    case 13:
                        DataController.Instance.collectionFaustDamage += PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.02f;
                        break;
                    case 14:
                        DataController.Instance.collectionFaustDamage += PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.02f;
                        break;
                    case 15:
                        DataController.Instance.collectionFaustDamage += PlayerPrefs.GetInt("CollectionItem_" + i, 0) * 0.02f;
                        break;
                }
            }
            else if (PlayerPrefs.GetInt("CollectionItem_" + i, 0) >= 50)
            {
                PlayerPrefs.SetInt("CollectionItem_" + i, 50);

                DataController.Instance.collectionDamage += 50 * 0.03f;

                switch (i)
                {
                    case 0:
                        DataController.Instance.collectionHp = 50 * 0.02f;
                        break;
                    case 1:
                        DataController.Instance.collectionCriticalPer = 50 * 0.5f;
                        break;
                    case 2:
                        DataController.Instance.collectionAngerTime = 50 * 0.01f;
                        break;
                    case 3:
                        DataController.Instance.collectionGoldRising += 50 * 0.01f;
                        break;
                    case 4:
                        DataController.Instance.collectionCoolTime = 50 * 2;
                        break;
                    case 5:
                        DataController.Instance.collectionAngerDamage = 50 * 0.02f;
                        break;
                    case 6:
                        DataController.Instance.collectionRubyRising = 50 * 1;
                        break;
                    case 7:
                        DataController.Instance.collectionSappaireRising = 50 * 1;
                        break;
                    case 8:
                        DataController.Instance.collectionGoldRising += 50 * 0.01f;
                        break;
                    case 9:
                        DataController.Instance.collectionDevilStoneRising = 50 * 1;
                        break;
                    case 10:
                        DataController.Instance.collectionRebirthRising += 50 * 0.02f;
                        break;
                    case 11:
                        DataController.Instance.collectionCriticalDamage = 50 * 0.03f;
                        break;
                    case 12:
                        DataController.Instance.collectionDamage += 50 * 0.03f;
                        break;
                    case 13:
                        DataController.Instance.collectionFaustDamage += 50 * 0.02f;
                        break;
                    case 14:
                        DataController.Instance.collectionFaustDamage += 50 * 0.02f;
                        break;
                    case 15:
                        DataController.Instance.collectionFaustDamage += 50 * 0.02f;
                        break;
                }

                DataController.Instance.UpdateDamage();
                DataController.Instance.UpdateCritical();

                DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();
            }
        }
    }
}