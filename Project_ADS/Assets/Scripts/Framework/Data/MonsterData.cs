using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterData : IValidation
{
    public string category;
    public string name;
    public string hp; // "40-44" 형태이므로 string 처리 후 파싱 권장
    public string features;

    public bool Validate()
    {
        if (string.IsNullOrEmpty(name)) return false;
        // HP 형식이 올바른지 등 추가 검증 로직
        return true;
    }
}

[Serializable]
public class MonsterDataLoader : IDataLoader<string, MonsterData>
{
    // JSON의 키값인 "Act1"과 일치해야 함
    public List<MonsterData> Act1 = new List<MonsterData>();

    public Dictionary<string, MonsterData> MakeDict()
    {
        Dictionary<string, MonsterData> dict = new Dictionary<string, MonsterData>();
        foreach (var monster in Act1)
        {
            // 이름이나 별도의 고유 ID를 키로 사용
            if (!dict.ContainsKey(monster.name))
                dict.Add(monster.name, monster);
        }
        return dict;
    }
}