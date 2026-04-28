using System;
using System.Collections.Generic;

[Serializable]
public class AbilityData
{
    public int id;
    public string name;
    public string description;
    public string levelInfo;
    public string iconName;
    public float effectValue;
    public string attributeType;
}

[Serializable]
public class AbilityDataLoader : IDataLoader<int, AbilityData>
{
    // JSON의 최상위 키값과 매칭됩니다. 
    // 리스트 변수명을 'abilities' 대신 'Abilities'로 변경하여 클래스명과 구분합니다.
    public List<AbilityData> Abilities = new List<AbilityData>();

    public Dictionary<int, AbilityData> MakeDict()
    {
        Dictionary<int, AbilityData> dict = new Dictionary<int, AbilityData>();

        foreach (AbilityData ability in Abilities)
        {
            if (!dict.ContainsKey(ability.id))
                dict.Add(ability.id, ability);
        }

        return dict;
    }
}
