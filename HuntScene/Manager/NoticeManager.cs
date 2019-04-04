using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeManager : MonoBehaviour
{

	public Animator NoticeAnimator;
	public Text NoticeText;

	private string[] noticeStrings =
	{
		"강화 버튼을 꾹 누르면 연속으로 강화할 수 있습니다.",
		"이전 투사체를 착용해도 능력치가 줄어들지 않습니다.",
		"구글 플레이 스토어에 '상인키우기'를 검색해보세요.",
		"사냥터 및 보스 클리어 시 적은 확률로 유물을 얻을 수 있습니다.",
		"초월을 하면 힘의 원천으로 캐릭터를 업그레이드 할 수 있습니다.",
		"스킬은 결계석에게 데미지를 줄 수 없습니다.",
		"루비로 강화한 능력치는 초월을 해도 능력치가 줄어들지 않습니다.",
		"지금은 프리시즌입니다. PVP를 마음껏 즐겨주세요."
	};
	
	private string[] noticeStrings2 =
	{
		"Press and hold the Reinforce button to reinforce continuously.",
		"Even if you wear your previous projection body, your ability will not decrease.",
		"You can get artifacts by clearing hunting grounds and boss steps with a low probability.",
		"If you rebirth, you can upgrade your character as a source of strength",
		"Skill can not damage the stones.",
		"Stats reinforced with Ruby do not decrease their stats even if they pass.",
		"Now is the pre-season. Please enjoy PVP."
	};
	
	private string[] noticeStrings3 =
	{
		"強化ボタンをぎゅっと押すと、連続的に強化することができます。",
		"以前投射體を着用しても能力値が減りません。",
		"狩り場とボスをクリアすると少ない確率で遺物を得ることができます。",
		"超越をする超越の石でキャラクターをアップグレードすることができます。",
		"スキルは結界石にダメージを与えることができません。",
		"ルビーで強化した能力値は超越しても能力値が減りません。",
		"今はプレシーズンです。 PVPを存分にお楽しみください。"
	};

	private void Start()
	{
		InvokeRepeating("SetNotice", 0, 40);
	}

	private void SetNotice()
	{
		if (Application.systemLanguage == SystemLanguage.Korean)
		{
			NoticeText.text = noticeStrings[Random.Range(0, noticeStrings.Length)];
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			NoticeText.text = noticeStrings3[Random.Range(0, noticeStrings3.Length)];
		}
		else
		{
			NoticeText.text = noticeStrings2[Random.Range(0, noticeStrings2.Length)];
		}
		
		NoticeAnimator.Play("NoticeAnimation", 0, 0);	
	}
}
