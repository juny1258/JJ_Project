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

	private void Start()
	{
		InvokeRepeating("SetNotice", 0, 40);
	}

	private void SetNotice()
	{
		NoticeText.text = noticeStrings[Random.Range(0, noticeStrings.Length)];
		NoticeAnimator.Play("NoticeAnimation", 0, 0);
	}
}
