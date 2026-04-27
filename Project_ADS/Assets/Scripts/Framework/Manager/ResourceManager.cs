using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    // 로드된 리소스를 관리하는 캐시 사전
    private Dictionary<string, Object> _resources = new Dictionary<string, Object>();

    // [LoadAll] 특정 경로의 모든 리소스를 로드하여 캐싱
    public void LoadAll<T>(string path) where T : Object
    {
        T[] assets = Resources.LoadAll<T>(path);
        foreach (T asset in assets)
        {
            if (!_resources.ContainsKey(asset.name))
                _resources.Add(asset.name, asset);
        }
    }

    // [Get<T>] 캐시에서 리소스를 반환 (없으면 Resources.Load 시도)
    public T Get<T>(string name) where T : Object
    {
        if (!_resources.ContainsKey(name))
        {
            T asset = Resources.Load<T>(name);
            if (asset == null) return null;
            _resources.Add(name, asset);
        }
        return _resources[name] as T;
    }

    // [Instantiate] 프리팹을 생성 (문자열 이름으로 생성 가능)
    public GameObject Instantiate(string name, Transform parent = null)
    {
        GameObject prefab = Get<GameObject>(name);
        if (prefab == null)
        {
            Debug.LogError($"Failed to load prefab : {name}");
            return null;
        }
        return Object.Instantiate(prefab, parent);
    }

    // [Destroy] 오브젝트 파괴 (GameObject 전용)
    public void Destroy(GameObject go)
    {
        if (go == null) return;
        Object.Destroy(go);
    }

    // [ReleaseAll] 캐시 비우기 및 메모리 정리
    public void ReleaseAll()
    {
        _resources.Clear();
        Resources.UnloadUnusedAssets();
    }
}
