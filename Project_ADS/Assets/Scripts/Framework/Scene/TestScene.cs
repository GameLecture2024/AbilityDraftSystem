using UnityEngine;

public class TestScene : BaseScene
{

    private void Start()
    {
        // 씬이 열렸을 떄 해야할 모든일을 여기다 정의.

        // 필수적인 프레임워크들을 전부 유니티 씬 올려놔야 된다.

        ResourceManager resourceManager = new ResourceManager();
        DataManager dataManager = new DataManager();

        //ResourceManager.Instance.LoadAll<GameObject>("")
        ResourceManager.Instance.LoadAll<TextAsset>("Data");
        ResourceManager.Instance.LoadAll<GameObject>("Prefabs");
        DataManager.Instance.Init();

        // Contents

        ResourceManager.Instance.Instantiate("@UI_Root");

        TestSceneUI testSceneUI = UIManager.Instance.ShowSceneUI<TestSceneUI>("TestUI_Scene");

        testSceneUI.Init();

        // Text Prefab. [1] [2] 정보가 들어가야 한다. UI_... 디테일한 정보를 전달해주자.

        //PrintAllMonsterNames();
        // 콘텐츠 제작. UIManager ObjectManager PoolManager 

        //SceneManagerEx.Instance.LoadScene(Defines.EScene.MAINSCENE);
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

