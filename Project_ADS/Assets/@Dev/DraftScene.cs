using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DraftScene : MonoBehaviour
{
    void Start()
    {
        // 1. 초기화 및 UI_Root 생성 확인
        Managers.Init();

        // 2. Draft UI 팝업 실행
        // ShowPopupUI는 내부적으로 Resources/Prefabs/UI/Popup/AbilityDraftUI를 로드합니다.
        AbilityDraftUI draftUI = Managers.UI.ShowPopupUI<AbilityDraftUI>();

        // 3. 데이터 로드 및 아이템 생성 지시
        if (draftUI != null)
        {
            // DataManager에 로드된 능력치 중 랜덤으로 3개 추출
            List<AbilityData> randomAbilities = Managers.Data.AbilityDict.Values
                .OrderBy(x => Random.value)
                .Take(3)
                .ToList();

            draftUI.RefreshAbilityList();
        }
    }

}
