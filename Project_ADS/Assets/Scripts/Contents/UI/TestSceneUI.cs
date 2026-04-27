using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// UI_Scene은 UI_Base를 상속받은 상태여야 합니다.
public class TestSceneUI : UI_scene
{
    // UI 요소들을 관리하기 위한 Enum 정의
    enum Texts
    {
        TitleText
    }

    enum Images
    {
        ProfileImage
    }

    enum Buttons
    {
        BackButton
    }

    public override void Init()
    {
        base.Init();

        // UI_Base의 Bind 기능을 사용하여 리소스 연결
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));

        TextMeshProUGUI title = Get<TextMeshProUGUI>((int)Texts.TitleText);
        if (title != null)
        {

            title.text = "Title";
        }

        // 버튼 이벤트 바인딩 예시
        Button backBtn = Get<Button>((int)Buttons.BackButton);
        if (backBtn != null)
            backBtn.onClick.AddListener(OnBackButtonClicked);

        Debug.Log("TestSceneUI 초기화 완료");
    }

    private void OnBackButtonClicked()
    {
        Debug.Log("뒤로 가기 버튼이 클릭되었습니다.");

    }


}
