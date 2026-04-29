using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers _instance;
    private static Managers Instance { get {  return _instance; } }

    private DataManager _data;
    private ResourceManager _resource;
    private SceneManagerEx _scene;
    private UIManager _ui;

    // 개별 매니저 속성 (기존 싱글톤 인스턴스 연결)
    public static DataManager Data => Instance?._data;
    public static ResourceManager Resource => Instance?._resource;
    public static SceneManagerEx Scene => Instance?._scene;
    public static UIManager UI => Instance?._ui;

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
        _resource = CreateManagerChild<ResourceManager>();
        _data = CreateManagerChild<DataManager>();
        _scene = CreateManagerChild<SceneManagerEx>();
        _ui = CreateManagerChild<UIManager>();

        Resource.LoadAll<TextAsset>("Data");
        Resource.LoadAll<Texture2D>("Sprite");
        
        // 데이터 매니저 초기화 (JSON 로드 등)
        _data.Init();
        UI.InitRoot();
        Debug.Log("Framework: All Managers Initialized.");
    }

    private T CreateManagerChild<T>() where T : Component
    {
        // 이미 자식으로 해당 이름의 오브젝트가 있는지 체크
        Transform child = transform.Find(typeof(T).Name);
        GameObject go;

        if (child != null)
        {
            go = child.gameObject;
        }
        else
        {
            // 없으면 새로 생성 후 부모 설정
            go = new GameObject { name = typeof(T).Name };
            go.transform.SetParent(this.transform);
        }

        // 컴포넌트가 있으면 가져오고 없으면 추가
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();

        return component;
    }
}

