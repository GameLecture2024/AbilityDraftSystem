# 📝 Project Overview: Ability Draft Prototype

## 1. 개요 (Introduction)
본 프로젝트는 유니티 엔진을 활용하여 플레이어가 스킬을 직접 조합하는 **'Ability Draft'** 시스템의 핵심 루프를 구현합니다. 3일간 총 6시간의 집중 개발을 통해 실제 구동되는 프로토타입 빌드를 출력합니다.

## 2. 핵심 목표 (Core Objectives)
*   **Modular Data**: ScriptableObject를 활용한 독립적인 스킬 데이터 설계.
*   **Draft Sequence**: 플레이어 간 순차적 선택을 관리하는 턴 매니저 구현.
*   **Runnable Output**: 드래프트 결과가 반영된 유니티 실행 파일(Build) 생성.

## 3. 개발 계획 (Development Plan)


| 일정 | 단계 | 주요 작업 내용 | 산출물 |
| :--- | :--- | :--- | :--- |
| **Day 1** | **Base & Data** | • `ScriptableObject` 기반 스킬 데이터 스키마 설계<br>• 드래프트 UI 레이아웃(Grid View) 구성<br>• 캐릭터 스킬 슬롯 시스템 기초 작업 | 스킬 DB 및 기초 UI |
| **Day 2** | **Core Logic** | • `Queue`를 이용한 턴 제어(Turn Manager) 로직<br>• 스킬 선택 시 데이터 바인딩 및 중복 선택 방지<br>• 선택 결과 시각화(아이콘 반영 등) | 드래프트 로직 |
| **Day 3** | **Build & Test** | • 선택된 스킬의 인게임 기능(발동/로그) 연결<br>• 드래프트 결과 유지 및 씬 전환(Transition) 처리<br>• PC 환경 독립 실행 파일(.exe) 출력 및 검증 | **프로토타입 빌드** |

## 4. 기술 스택 (Technical Stack)
*   **Engine**: Unity 2022.3+ (LTS)
*   **Language**: C#
*   **Pattern**: ScriptableObject Architecture, Observer Pattern (Events)
*   **UI**: UGUI (Auto Layout)

## 5. 성공 척도 (Success Metrics)
- [ ] 4개 이상의 고유 스킬이 정상적으로 데이터베이스화 되었는가?
- [ ] 정해진 순서에 따라 플레이어가 스킬을 선택하고 리스트에서 제외되는가?
- [ ] 빌드된 파일에서 드래프트 완료 후 캐릭터가 해당 스킬을 소유하는가?

---
**Next Step:** 이제 **Day 1**의 핵심인 **스킬 데이터 구조(ScriptableObject)** 설계를 시작해 보겠습니다. 어떤 속성(이름, 데미지, 쿨타임, 아이콘 등)을 기본으로 포함할까요?
