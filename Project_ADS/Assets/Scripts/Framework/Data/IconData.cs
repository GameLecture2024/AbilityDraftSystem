using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IconData : IValidation
{
    public string iconName; // 리소스 파일 이름 (Key)
    public string description; // 아이콘 설명 (선택 사항)

    public Sprite iconSprite;

    public bool Validate()
    {
        // 이름이 비어있거나 리소스 매니저에 해당 리소스가 없는지 체크 가능
        if (string.IsNullOrEmpty(iconName)) return false;
        return true;
    }
}

[Serializable]
public class IconDataLoader : IDataLoader<string, IconData>
{
    // JSON 구조가 { "Icons": [...] } 형태라고 가정
    public List<IconData> Icons = new List<IconData>();

    public Dictionary<string, IconData> MakeDict()
    {
        Dictionary<string, IconData> dict = new Dictionary<string, IconData>();

        foreach (var icon in Icons)
        {
            if (!dict.ContainsKey(icon.iconName))
            {
                // 1. 리소스 매니저에서 Texture2D를 가져옴
                Texture2D tex = ResourceManager.Instance.Get<Texture2D>(icon.iconName);

                if (tex != null)
                {
                    // 2. 즉시 Sprite로 변환하여 할당 (피벗은 중앙 0.5f)
                    icon.iconSprite = Sprite.Create(
                        tex,
                        new Rect(0, 0, tex.width, tex.height),
                        new Vector2(0.5f, 0.5f)
                    );
                }

                dict.Add(icon.iconName, icon);
            }
        }
        return dict;
    }
}
