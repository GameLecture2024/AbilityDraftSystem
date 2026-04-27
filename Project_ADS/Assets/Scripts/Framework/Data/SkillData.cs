using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillData : IValidation
{
    [Header("Basic Info")]
    public int skillID;
    public string skillName;
    public string iconPath; // JSON에는 에셋 경로(또는 이름)를 저장
    public Sprite icon;     // 런타임에 할당될 실제 리소스

    [Header("Combat Stats")]
    public float cooldown;
    public float power;

    public bool Validate()
    {
        // ID가 0이거나 이름이 비어있으면 유효하지 않음
        if (skillID <= 0 || string.IsNullOrEmpty(skillName)) return false;

        // 쿨타임이 음수인지 확인
        if (cooldown < 0) return false;

        return true;
    }
}

[Serializable]
public class SkillDataLoader : IDataLoader<int, SkillData>
{
    // JSON의 루트 배열 키값 (예: "Skills": [...])
    public List<SkillData> Skills = new List<SkillData>();

    public Dictionary<int, SkillData> MakeDict()
    {
        Dictionary<int, SkillData> dict = new Dictionary<int, SkillData>();
        foreach (var skill in Skills)
        {
            if (!dict.ContainsKey(skill.skillID))
            {
                // 아이콘 리소스를 이름 기반으로 로드 (필요 시)
                // skill.icon = ResourceManager.Instance.Load<Sprite>(skill.iconPath);
                dict.Add(skill.skillID, skill);
            }
        }
        return dict;
    }
}

