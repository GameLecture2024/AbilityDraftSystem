using System.Collections.Generic;
using UnityEngine;

public interface IDataLoader<TKey, TValue>
{
    // 데이터를 Dictionary 형태로 변환하여 반환
    Dictionary<TKey, TValue> MakeDict();
}

public interface IValidation
{
    // 데이터 로드 후 유효성 검증 (예: ID 중복, 참조 리소스 누락 등)
    bool Validate();
}

public class DataManager : Singleton<DataManager>
{
    // 외부에서 접근할 몬스터 딕셔너리
    public Dictionary<string, MonsterData> MonsterDict { get; private set; } = new Dictionary<string, MonsterData>();
    public Dictionary<int, SkillData> SkillDict { get; private set; } = new Dictionary<int, SkillData>();
    public Dictionary<int, AbilityData> AbilityDict { get; private set; } = new Dictionary<int, AbilityData>();

    // ResourceManager는 이미 로드를 완료하여 메모리에 에셋이 있다고 가정합니다.
    public void Init()
    {
        // JSON 리소스 로드 및 데이터화
        MonsterDict = LoadJson<MonsterDataLoader, string, MonsterData>("MonsterData");
        SkillDict = LoadJson<SkillDataLoader, int, SkillData>("SkillData");
        AbilityDict = LoadJson<AbilityDataLoader, int, AbilityData>("AbilityDdata");
     
        if (MonsterDict == null )
        {
            Debug.Log("MonsterDict을 찾을 수 없습니다.");
        }

        Debug.Log($"몬스터 데이터 로드 완료: {MonsterDict.Count}개");
    }

    private Dictionary<TKey, TValue> LoadJson<TLoader, TKey, TValue>(string path)
        where TLoader : IDataLoader<TKey, TValue>
    {
        // 1> ResourceManager를 통해 TextAsset 가져오기 (이미 메모리에 올라와 있음)
        TextAsset textAsset = ResourceManager.Instance.Get<TextAsset>(path);
        if (textAsset == null) return null;

        // 2> JSON 역직렬화
        TLoader loader = JsonUtility.FromJson<TLoader>(textAsset.text);

        // 3> Dictionary 변환
        Dictionary<TKey, TValue> dict = loader.MakeDict();

        // 4> IValidation 체크
        foreach (var data in dict.Values)
        {
            if (data is IValidation validator)
            {
                if (!validator.Validate())
                    Debug.LogError($"[Validation Failed] {path} 에 유효하지 않은 데이터가 있습니다.");
            }
        }

        return dict;
    }
}
