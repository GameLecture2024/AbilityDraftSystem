using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_AbilityItem : UI_subItem
{
    // 바인딩할 오브젝트 네이밍 규칙
    enum Texts
    {
        Text_Name,
        Text_Level,
        Text_Description
    }

    enum Images
    {
        Image_Icon
    }

    enum Buttons
    {
        Button_Select
    }

    // 선택 시 외부(AbilityDraftUI)로 알리기 위한 콜백
    private Action _onSelected;

    public override void Init()
    {
        // 1. 컴포넌트 자동 바인딩
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));

        // 2. 버튼 클릭 이벤트 리스너 등록
        // Event는 EventManager가 담당하기 때문에 Button 연결 기능을 Event로 처리하는 코드로 해줘.
        // 
        Get<Button>((int)Buttons.Button_Select).onClick.AddListener(OnClickSelectItem);
    }

    /// <summary>
    /// 아이템의 정보를 UI에 세팅하는 함수
    /// </summary>
    public void SetInfo(string name, string level, string desc, Sprite icon, Action onSelected)
    {
        Get<Text>((int)Texts.Text_Name).text = name;
        Get<Text>((int)Texts.Text_Level).text = level;
        Get<Text>((int)Texts.Text_Description).text = desc;
        Get<Image>((int)Images.Image_Icon).sprite = icon;

        _onSelected = onSelected;
    }

    private void OnClickSelectItem()
    {
        Debug.Log($"아이템 선택됨: {Get<Text>((int)Texts.Text_Name).text}");

        // 콜백 실행 (데이터 적용 및 팝업 닫기 등)
        _onSelected?.Invoke();
    }
}
