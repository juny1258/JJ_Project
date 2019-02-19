using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	private static EventManager instance;

	public static EventManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<EventManager>();
				if (instance == null)
				{
					var container = new GameObject("EventManager");
					instance = container.AddComponent<EventManager>();
				}
			}

			return instance;
		}
	}
	
	public delegate void Event();

	public delegate void EventWithFloat(float index);
	public delegate void EventWithFloat2(float index1, float index2);
	
	public delegate void EventWithInt(int index);

	public static event EventWithFloat MonsterAttackEvent;

	public static event Event StartHuntEvent;
	
	public static event EventWithFloat2 ShackScreenEvent;

	public static event EventWithInt UseSkillEvent;

	public static event Event SelectAttackEvent;

	public static event Event SelectCostumeEvent;

	public static event Event EndGameEvnet;
	
	public static event Event RewardClickEvent;

	public static event Event UpgradeSkillEvent;

	public static event Event RebirtButtonClickEvent;

	public static event EventWithFloat BossAttackEvent;

	public static event Event GetCollectionItemEvent;
	
	public static event Event GetAdvancedItemEvent;

	public static event Event RebirthEvent;

	public static event Event AutoClickEvent;
	

	public void MonsterAttack(float damage)
	{
		if (MonsterAttackEvent != null)
		{
			MonsterAttackEvent(damage);
		}
	}
	
	public void StartHunt()
	{
		if (StartHuntEvent != null)
		{
			StartHuntEvent();
		}
	}
	
	public void UseSkill(int index)
	{
		if (UseSkillEvent != null)
		{
			UseSkillEvent(index);
		}
	}
	
	public void ShackScreen(float amount, float duration)
	{
		if (ShackScreenEvent != null)
		{
			ShackScreenEvent(amount, duration);
		}
	}
	
	public void SelectAttack()
	{
		if (SelectAttackEvent != null)
		{
			SelectAttackEvent();
		}
	}
	
	public void SelectCostume()
	{
		if (SelectCostumeEvent != null)
		{
			SelectCostumeEvent();
		}
	}
	
	public void EndGame()
	{
		if (EndGameEvnet != null)
		{
			EndGameEvnet();
		}
	}
	
	public void RewardClick()
	{
		if (RewardClickEvent != null)
		{
			RewardClickEvent();
		}
	}
	
	public void UpgradeSkill()
	{
		if (UpgradeSkillEvent != null)
		{
			UpgradeSkillEvent();
		}
	}
	
	public void RebirtButtonClick()
	{
		if (RebirtButtonClickEvent != null)
		{
			RebirtButtonClickEvent();
		}
	}
	
	public void BossAttack(float damage)
	{
		if (BossAttackEvent != null)
		{
			BossAttackEvent(damage);
		}
	}
	
	public void GetCollectionItem()
	{
		if (GetCollectionItemEvent != null)
		{
			GetCollectionItemEvent();
		}
	}
	
	public void GetAdvancedItem()
	{
		if (GetAdvancedItemEvent != null)
		{
			GetAdvancedItemEvent();
		}
	}
	
	public void Rebirth()
	{
		if (RebirthEvent != null)
		{
			RebirthEvent();
		}
	}
	
	public void AutoClick()
	{
		if (AutoClickEvent != null)
		{
			AutoClickEvent();
		}
	}
}
