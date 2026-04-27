using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers _instance;
    private static Managers Instance { get { Init(); return _instance; } }

    // 개별 매니저 속성 (기존 싱글톤 인스턴스 연결)
    public static DataManager Data => DataManager.Instance;
    public static ResourceManager Resource => ResourceManager.Instance;
    public static SceneManagerEx Scene => SceneManagerEx.Instance;

    public static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            _instance = go.GetComponent<Managers>();

            // 초기화 순서 제어: 리소스 매니저가 먼저 데이터를 들고 있어야 데이터 매니저가 파싱 가능
            // (필요 시 ResourceManager.Instance.LoadAll<TextAsset>("Data") 등을 먼저 수행)
            _instance.InitAllManagers();
        }
    }

    private void InitAllManagers()
    {
        Resource.LoadAll<TextAsset>("Data");

        // 데이터 매니저 초기화 (JSON 로드 등)
        Data.Init();
        Debug.Log("Framework: All Managers Initialized.");
    }
}

