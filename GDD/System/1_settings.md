# 🛠 Settings.md: Day 1 Environment Setup

## 1. 프레임워크 구조 (Framework Architecture)
본 프로젝트는 기구축된 **Scene / Resource / Data** 기반 프레임워크를 엄격히 준수하여 세팅됩니다. 모든 작업은 해당 디렉토리 구조 내에서 진행됩니다.

*   **Scene**: `Scenes/DraftScene` - 드래프트 로직이 구동되는 메인 씬.
*   **Resource**: `Resources/Skills/` - 스킬 아이콘, 이펙트 프리팹 등 런타임 로드 에셋.
*   **Data**: `Data/Definitions/` - 스킬 속성을 정의한 ScriptableObject 에셋.

## 2. 환경 설정 워크플로우 (1-Hour Workflow)
기존 프레임워크를 기반으로 시스템 기반을 60분 안에 구축하기 위한 단계별 계획입니다.


| 시간 | 단계 | 작업 내용 (Workflow) | 관련 위치 |
| :--- | :--- | :--- | :--- |
| **00~15m** | **Data Definition** | • `SkillData.cs` 클래스 설계 (ScriptableObject)<br>• 스킬 ID, 이름, 설명, 타입 등 데이터 필드 정의 | `/Scripts/Data` |
| **15~30m** | **Resource Entry** | • 샘플 스킬 에셋(4~8개) 생성 및 데이터 기입<br>• 프레임워크 로더가 인식할 경로에 에셋 배치 | `/Resources/Skills` |
| **30~50m** | **Scene Structure** | • `DraftScene` 내 기본 UI 레이아웃(Grid View) 배치<br>• 프레임워크 싱글톤 매니저(Scene Manager 등) 초기화 | `/Scenes` |
| **50~60m** | **Data Link Test** | • 프레임워크 로딩 기능을 통한 Resource 로드 확인<br>• 콘솔창을 이용한 데이터 출력 및 바인딩 검증 | `Unity Console` |

## 3. 핵심 구현 가이드

### 3.1 Skill Data 구조
프레임워크의 Data 관리 방식에 따라 아래 스키마를 기본으로 사용합니다.
```csharp
[CreateAssetMenu(fileName = "Skill_", menuName = "AbilityDraft/SkillData")]
public class SkillData : ScriptableObject 
{
    [Header("Basic Info")]
    public int skillID;
    public string skillName;
    public Sprite icon;

    [Header("Combat Stats")]
    public float cooldown;
    public float power;
}
```

### 3.2 Resource 관리 규칙
*   모든 스킬 관련 프리팹 및 에셋은 프레임워크 로더(Resource Manager)의 경로 규칙인 `Resources/Skills/` 하위에 위치시킵니다.

### 3.3 UI Scene 구성 요소
*   **Skill_Pool_Grid**: 스킬 카드들이 동적으로 생성될 공간 (`GridLayoutGroup` 사용).
*   **Player_Hand_Slot**: 플레이어가 선택한 스킬이 담길 인벤토리 UI 영역.

---
**Next Step:** 

- Framework - Plan 결합하는 방법을 생각하기.
