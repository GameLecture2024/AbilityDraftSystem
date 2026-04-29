using UnityEngine;

public class TestScene : BaseScene
{

    private void Awake()
    {
        Managers.Init();


    }

    public void PrintAllMonsterNames()
    {
        // 데이터 유무 확인
        if (DataManager.Instance.MonsterDict == null || DataManager.Instance.MonsterDict.Count == 0)
        {
            Debug.LogWarning("[DataManager] 출력할 몬스터 데이터가 없습니다.");
            return;
        }

        Debug.Log($"<color=cyan>==== 1챕터 몬스터 리스트 (총 {DataManager.Instance.MonsterDict.Count}종) ====</color>");

        // Dictionary의 Value들을 순회하며 이름 출력
        foreach (MonsterData monster in DataManager.Instance.MonsterDict.Values)
        {
            // 카테고리(일반/엘리트/보스)와 이름을 함께 출력하면 더 식별이 쉽습니다.
            Debug.Log($"[{monster.category}] {monster.name}");
        }

        Debug.Log("<color=cyan>==========================================</color>");
    }

}

