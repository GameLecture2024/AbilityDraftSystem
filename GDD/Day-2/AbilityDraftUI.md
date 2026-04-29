# UI 구현 명세서: LevelUp Popup

이미 구현된 `UIManager` 프레임워크(UI_Scene, UI_Popup, UI_SubItem) 구조에 맞춘 레벨업 화면 설계도입니다.

---

## 1. UI 계층 구조 (Hierarchy)

전체 팝업은 `UI_Popup`을 상속받으며, 각 아이템 항목은 `UI_SubItem`으로 분리하여 재사용합니다.

### [Prefab] UI_LevelUpPopup (UI_Popup)
- **GameObject**: `UI_LevelUpPopup`
    - `Image_Dimmer` (배경 암전 효과)
    - `Group_Window` (중앙 팝업 창)
        - `Text_Title` (텍스트: "레벨 업!")
        - `Content_ItemList` (Vertical Layout Group: 아이템 항목들 배치)
            - `UI_LevelUpItem_01` (UI_SubItem 참조)
            - `UI_LevelUpItem_02` (UI_SubItem 참조)
            - `UI_LevelUpItem_03` (UI_SubItem 참조)
        - `Text_FooterDesc` (하단 안내 문구: "버튼을 누르면...")

### [Prefab] UI_LevelUpItem (UI_SubItem)
- **GameObject**: `UI_LevelUpItem`
    - `Button_Select` (항목 전체 클릭 버튼)
    - `Image_Icon` (아이템 아이콘 이미지)
    - `Text_Name` (아이템 이름)
    - `Text_Level` (현재 레벨/상태 정보)
    - `Text_Description` (아이템 상세 효과 설명)

---

## 2. 오브젝트 네이밍 및 컴포넌트 맵핑


| 계층 구분 | 오브젝트 이름 | UI 컴포넌트 | 비고 |
| :--- | :--- | :--- | :--- |
| **Popup** | `Text_Title` | TextMeshProUGUI | "레벨 업!" |
| **Popup** | `Content_ItemList` | RectTransform | 아이템 프리팹이 생성될 부모 |
| **SubItem** | `Button_Select` | Button | 클릭 시 해당 아이템 선택 로직 |
| **SubItem** | `Image_Icon` | Image | 아이템 스프라이트 할당 |
| **SubItem** | `Text_Name` | TextMeshProUGUI | 아이템 이름 (Ex. Magic Wand) |
| **SubItem** | `Text_Level` | TextMeshProUGUI | 레벨 정보 (Ex. 레벨 2) |
| **SubItem** | `Text_Description` | TextMeshProUGUI | 효과 (Ex. 투사체 1개 증가) |

---

## 3. 리소스 경로 (Resources)

`UIManager`의 `Show` 방식 호출을 위해 아래 경로에 프리팹을 위치시킵니다.

- **메인 팝업**: `Resources/Prefabs/UI/Popup/UI_LevelUpPopup`
- **개별 항목**: `Resources/Prefabs/UI/SubItem/UI_LevelUpItem`

---

## 4. 데이터 바인딩 가이드 (C# Reference)

```csharp
// UI_LevelUpPopup.cs 예시
protected override void Init()
{
    base.Init();
    Bind<TextMeshProUGUI>(typeof(Texts));
    GetText((int)Texts.Text_Title).text = "레벨 업!";
}

// UI_LevelUpItem.cs 예시
public void SetItemInfo(string name, string level, string desc)
{
    GetText((int)Texts.Text_Name).text = name;
    GetText((int)Texts.Text_Level).text = level;
    GetText((int)Texts.Text_Description).text = desc;
}
```
