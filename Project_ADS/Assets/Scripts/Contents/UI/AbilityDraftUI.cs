using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDraftUI : UI_popup
{
    // Enum을 통해 하위 오브젝트 바인딩 관리
    enum Texts
    {
        Text_Title
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
        Get<TextMeshProUGUI>((int)Texts.Text_Title).text = "레벨 업!";

        // 3. 아이템 생성 (SubItem 호출)
        RefreshAbilityList();
    }

    public void RefreshAbilityList()
    {
        GameObject container = Get<GameObject>((int)GameObjects.Grid_AbilityContainer);

        // 기존 리스트 초기화
        foreach (Transform child in container.transform)
            Managers.Resource.Destroy(child.gameObject);


        // DataManager에 있는 Ability에서 중복이 되지 않게 3개를 뽑아오는 코드가 필요하다.
        // DataManager에 로드된 능력치 중 랜덤으로 3개 추출
        List<AbilityData> randomAbilities = Managers.Data.AbilityDict.Values
            .OrderBy(x => Random.value)
            .Take(3)
            .ToList();

        // 3. 추출된 데이터를 바탕으로 UI 생성 및 데이터 바인딩
        foreach (AbilityData ability in randomAbilities)
        {
            // UI_AbilityItem 생성
            UI_AbilityItem item = Managers.UI.MakeSubItem<UI_AbilityItem>(container.transform);
            item.Init();
            // 데이터 주입
            if (item != null)
            {
                item.SetInfo(ability);
            }
        }
    }
}
