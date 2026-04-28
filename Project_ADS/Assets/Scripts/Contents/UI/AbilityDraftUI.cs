using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityDraftUI : UI_popup
{
    // Enum을 통해 하위 오브젝트 바인딩 관리
    enum Texts
    {
        Text_Title,
        Text_Guide
    }

    enum GameObjects
    {
        Grid_AbilityContainer
    }

    public override void Init()
    {
        base.Init();

        // 1. 컴포넌트 바인딩
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        // 2. 초기 데이터 세팅 예시
        Get<Text>((int)Texts.Text_Title).text = "레벨 업!";

        // 3. 아이템 생성 (SubItem 호출)
        RefreshAbilityList();
    }

    public void RefreshAbilityList()
    {
        GameObject container = Get<GameObject>((int)GameObjects.Grid_AbilityContainer);

        // 기존 리스트 초기화
        foreach (Transform child in container.transform)
            Managers.Resource.Destroy(child.gameObject);

        // 데이터에 따라 UI_SubItem 생성 (예시: 3회 반복)
        for (int i = 0; i < 3; i++)
        {
            Managers.UI.MakeSubItem<UI_AbilityItem>(container.transform);
        }
    }
}
