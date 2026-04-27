using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    // UI 최상위 루트 관리
    private GameObject _uiRoot;
    public GameObject Root
    {
        get
        {
            if (_uiRoot == null) _uiRoot = ResourceManager.Instance.Instantiate("@UI_Root");
            return _uiRoot;
        }
    }

    // --- 1. Scene UI: 씬 전환 시 주로 하나만 존재 ---
    public T ShowSceneUI<T>(string name = null) where T : UI_scene
    {
        if (string.IsNullOrEmpty(name)) name = typeof(T).Name;

        GameObject go = Instantiate(Resources.Load<GameObject>($"Prefabs/UI/TestSceneUI/Scene/{name}")); 
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
