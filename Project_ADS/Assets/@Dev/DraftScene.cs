using UnityEngine;

public class DraftScene : MonoBehaviour
{
    void Start()
    {
        // 1. 프레임워크 초기화 (Managers 접근 시 자동 Init)
        Debug.Log($"[DraftScene] Framework loading...");

        // 2. 리소스 일괄 로드 예시 (Data 폴더 내 JSON 파일들)
        // ResourceManager에 LoadAll이 구현되어 있으므로 경로를 지정해 미리 캐싱합니다.
        Managers.Init();

        // 3. 데이터 로드 및 검증 (DataManager.Init은 Managers.InitAllManagers에서 호출됨)
        var monsterDict = Managers.Data.MonsterDict;

        if (monsterDict != null && monsterDict.Count > 0)
        {
            Debug.Log("--- Data Validation Start ---");
            foreach (var monster in monsterDict.Values)
            {
                Debug.Log($"몬스터 확인: ID={monster.name}, HP={monster.hp}");
            }
            Debug.Log("--- Data Validation Success ---");
        }
        else
        {
            Debug.LogError("데이터가 로드되지 않았습니다. JSON 파일명과 경로를 확인하세요.");
        }

        // 4. 리소스 매니저를 통한 오브젝트 생성 예시
        // Managers.Resource.Instantiate("MonsterPrefab");
    }
}


