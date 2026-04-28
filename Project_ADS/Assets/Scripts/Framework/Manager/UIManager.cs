using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    // UI 최상위 루트 관리
    private GameObject _uiRoot;
    public GameObject Root
    {
        get
        {
            // _uiRoot가 없으면 초기화 함수를 실행해라
            if (_uiRoot == null)
                InitRoot();

            return _uiRoot;
        }
    }

    public void InitRoot()
    {
        if (_uiRoot != null) return;

        // 1. 하이어라키에서 이미 존재하는지 확인 (중복 생성 방지)
        _uiRoot = GameObject.Find("@UI_Root");

        // 2. 없다면 프리팹 로드 및 생성
        if (_uiRoot == null)
        {
            GameObject rootPrefab = Resources.Load<GameObject>("Prefabs/UI/UI_Root");
            if (rootPrefab != null)
            {
                _uiRoot = Object.Instantiate(rootPrefab);
                _uiRoot.name = "@UI_Root";
            }
            else
            {
                // 프리팹이 없을 경우를 대비한 기본 빈 오브젝트 생성
                _uiRoot = new GameObject { name = "@UI_Root" };
                Debug.LogWarning("UI_Root 프리팹을 찾을 수 없어 빈 오브젝트를 생성했습니다.");
            }
        }

        // --- 좌표 및 크기 설정 코드 추가 ---
        Canvas canvas = _uiRoot.GetComponent<Canvas>();
        if (canvas != null)
        {
            // UI_Root가 Canvas를 가지고 있다면 RectTransform을 1920x1080으로 맞춤
            RectTransform rect = _uiRoot.GetComponent<RectTransform>();
            rect.localPosition = Vector3.zero; // 중심점 0,0,0
            rect.sizeDelta = new Vector2(1920, 1080); // 가로 1920, 세로 1080
        }
    }

    // --- 1. Scene UI: 씬 전환 시 주로 하나만 존재 ---
    public T ShowSceneUI<T>(string name = null) where T : UI_scene
    {
        if (string.IsNullOrEmpty(name)) name = typeof(T).Name;

        GameObject go = Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Scene/{name}")); 
        go.transform.SetParent(Root.transform);

        T sceneUI = go.GetComponent<T>();
        sceneUI.Init(); // UI_Base의 바인딩 로직 실행
        return sceneUI;
    }

    // --- 2. Popup UI: 스택 구조로 쌓이는 팝업 ---
    public T ShowPopupUI<T>(string name = null) where T : UI_popup
    {
        if (string.IsNullOrEmpty(name)) name = typeof(T).Name;

        GameObject go = Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Popup/{name}"));
        go.transform.SetParent(Root.transform);

        T popup = go.GetComponent<T>();
        popup.Init();
        return popup;
    }

    // --- 3. SubItem: 스크롤 뷰의 리스트 아이템 등 ---
    public T MakeSubItem<T>(Transform parent, string name = null) where T : UI_subItem
    {
        if (string.IsNullOrEmpty(name)) name = typeof(T).Name;

        GameObject go = Instantiate(Resources.Load<GameObject>($"Prefabs/UI/SubItem/{name}"));
        if (parent != null) go.transform.SetParent(parent);

        T subItem = go.GetComponent<T>();
        subItem.Init();
        return subItem;
    }
}
