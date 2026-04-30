아래는 제공해주신 분석 내용을 `.md` 파일로 바로 저장하거나 활용하실 수 있도록 **마크다운(Markdown) 문법**으로 작성한 소스 코드입니다.

```markdown
# 🎮 타워 디펜스: JS to Unity 이식 개발 계획서

이 문서는 HTML5/JavaScript 기반의 타워 디펜스 게임 로직을 유니티(Unity) 2D 환경으로 전환하기 위한 기술적 가이드라인을 담고 있습니다.

---

## 1. 프로젝트 개요 (Setup)
- **엔진**: Unity 2022.3 LTS 이상 (2D Template)
- **해상도**: 800x600 (고정) 또는 16:9 가변 대응
- **언어**: C#
- **주요 목표**: JS의 데이터 중심 설계(Data-driven)를 유니티의 **ScriptableObject**와 **Prefab** 시스템으로 최적화하여 구현함.

---

## 2. 핵심 아키텍처 매핑 (Architecture Mapping)

| 기능 분류 | JS 원본 소스 (기존) | 유니티 구현 방식 (변경) |
| :--- | :--- | :--- |
| **데이터 관리** | `TOWER_TYPES`, `ENEMY_TYPES` | `ScriptableObject` (TowerData, EnemyData) |
| **그리드 시스템** | `Grid`, `Tile` 클래스 | `Tilemap` 시스템 + `GridManager.cs` |
| **이동 경로** | `PathManager`, `WAYPOINTS` | `LineRenderer` 시각화 + `WaypointPath.cs` |
| **적(Enemy)** | `Enemy` 클래스 | `Enemy` Prefab + `EnemyController.cs` |
| **타워(Tower)** | `Tower` 클래스 | `Tower` Prefab + `TowerController.cs` |
| **투사체** | `Projectile` 클래스 | `Projectile` Prefab + `Projectile.cs` |
| **게임 관리** | `Game`, `WaveManager` | `GameManager.cs` (Singleton), `WaveManager.cs` |
| **UI 시스템** | `UIManager` 클래스 | Unity UI (Canvas, Buttons, TextMeshPro) |

---

## 3. 단계별 구현 세부 계획

### 1단계: 데이터 레이어 (Data Layer)
유니티 에디터에서 수치를 쉽게 수정하기 위해 ScriptableObject를 생성합니다.
- **EnemyData**: HP, 속도, 방어력, 보상, 아이콘(Sprite).
- **TowerData**: 단계별 업그레이드 수치(데미지, 사거리, 쿨다운), 설치 비용.
- **WaveData**: 웨이브별 적의 종류 및 스폰 간격 리스트.

### 2단계: 환경 및 경로 시스템 (Environment)
1. **타일맵 설정**: `TILE_MAP` 배열 구조를 참조하여 'Build' 레이어(잔디)와 'Path' 레이어(길)를 구분하여 배치.
2. **경로 생성**: `PATH_WAYPOINTS` 좌표를 Unity World Space 좌표로 변환하여 에디터상에 배치.
3. **그리드 로직**: 마우스 클릭 위치를 `Tilemap.WorldToCell`로 변환하여 타워 설치 가능 여부 확인.

### 3단계: 적 시스템 (Enemy System)
1. **이동 엔진**: JS의 `distanceTraveled` 개념을 유지하되, `Vector3.MoveTowards`를 사용하여 웨이포인트를 순회.
2. **상태 관리**: `Enemy.cs`에서 체력 계산, 슬로우 상태(속도 배율 적용), 방어력 및 특수 능력(재생, 실드 등) 구현.
3. **시각화**: 적 상단에 `World Space Canvas`를 배치하여 HP바를 실시간 갱신.

### 4단계: 타워 및 전투 시스템 (Combat System)
1. **타겟팅**: `Physics2D.OverlapCircleAll` 또는 거리 체크를 사용하여 사거리 내 적을 감지.
   - **우선순위**: JS 로직을 계승하여 `distanceTraveled`가 가장 높은(가장 멀리 간) 적을 타겟팅.
2. **타워 공격 로직**:
   - **Archer**: 단일 타겟 발사.
   - **Mage**: 관통(Pierce) 및 마법 피해 구현.
   - **Ice**: 슬로우 디버프(Co아래는 제공해주신 분석 내용을 `.md` 파일로 바로 저장하거나 활용하실 수 있도록 **마크다운(Markdown) 문법**으로 작성한 소스 코드입니다.

```markdown
# 🎮 타워 디펜스: JS to Unity 이식 개발 계획서

이 문서는 HTML5/JavaScript 기반의 타워 디펜스 게임 로직을 유니티(Unity) 2D 환경으로 전환하기 위한 기술적 가이드라인을 담고 있습니다.

---

## 1. 프로젝트 개요 (Setup)
- **엔진**: Unity 2022.3 LTS 이상 (2D Template)
- **해상도**: 800x600 (고정) 또는 16:9 가변 대응
- **언어**: C#
- **주요 목표**: JS의 데이터 중심 설계(Data-driven)를 유니티의 **ScriptableObject**와 **Prefab** 시스템으로 최적화하여 구현함.

---

## 2. 핵심 아키텍처 매핑 (Architecture Mapping)

| 기능 분류 | JS 원본 소스 (기존) | 유니티 구현 방식 (변경) |
| :--- | :--- | :--- |
| **데이터 관리** | `TOWER_TYPES`, `ENEMY_TYPES` | `ScriptableObject` (TowerData, EnemyData) |
| **그리드 시스템** | `Grid`, `Tile` 클래스 | `Tilemap` 시스템 + `GridManager.cs` |
| **이동 경로** | `PathManager`, `WAYPOINTS` | `LineRenderer` 시각화 + `WaypointPath.cs` |
| **적(Enemy)** | `Enemy` 클래스 | `Enemy` Prefab + `EnemyController.cs` |
| **타워(Tower)** | `Tower` 클래스 | `Tower` Prefab + `TowerController.cs` |
| **투사체** | `Projectile` 클래스 | `Projectile` Prefab + `Projectile.cs` |
| **게임 관리** | `Game`, `WaveManager` | `GameManager.cs` (Singleton), `WaveManager.cs` |
| **UI 시스템** | `UIManager` 클래스 | Unity UI (Canvas, Buttons, TextMeshPro) |

---

## 3. 단계별 구현 세부 계획

### 1단계: 데이터 레이어 (Data Layer)
유니티 에디터에서 수치를 쉽게 수정하기 위해 ScriptableObject를 생성합니다.
- **EnemyData**: HP, 속도, 방어력, 보상, 아이콘(Sprite).
- **TowerData**: 단계별 업그레이드 수치(데미지, 사거리, 쿨다운), 설치 비용.
- **WaveData**: 웨이브별 적의 종류 및 스폰 간격 리스트.

### 2단계: 환경 및 경로 시스템 (Environment)
1. **타일맵 설정**: `TILE_MAP` 배열 구조를 참조하여 'Build' 레이어(잔디)와 'Path' 레이어(길)를 구분하여 배치.
2. **경로 생성**: `PATH_WAYPOINTS` 좌표를 Unity World Space 좌표로 변환하여 에디터상에 배치.
3. **그리드 로직**: 마우스 클릭 위치를 `Tilemap.WorldToCell`로 변환하여 타워 설치 가능 여부 확인.

### 3단계: 적 시스템 (Enemy System)
1. **이동 엔진**: JS의 `distanceTraveled` 개념을 유지하되, `Vector3.MoveTowards`를 사용하여 웨이포인트를 순회.
2. **상태 관리**: `Enemy.cs`에서 체력 계산, 슬로우 상태(속도 배율 적용), 방어력 및 특수 능력(재생, 실드 등) 구현.
3. **시각화**: 적 상단에 `World Space Canvas`를 배치하여 HP바를 실시간 갱신.

### 4단계: 타워 및 전투 시스템 (Combat System)
1. **타겟팅**: `Physics2D.OverlapCircleAll` 또는 거리 체크를 사용하여 사거리 내 적을 감지.
   - **우선순위**: JS 로직을 계승하여 `distanceTraveled`가 가장 높은(가장 멀리 간) 적을 타겟팅.
2. **타워 공격 로직**:
   - **Archer**: 단일 타겟 발사.
   - **Mage**: 관통(Pierce) 및 마법 피해 구현.
   - **Ice**: 슬로우 디버프(Coroutine 또는 Timer 기반) 적용.
   - **Cannon**: 범위 피해(`Physics2D.OverlapCircleAll`) 처리.
3. **투사체**: 타겟 방향으로 이동하며 거리 체크(`dist < 0.1f`)를 통해 충돌 및 데미지 로직 실행.

### 5단계: 게임 루프 및 UI (Game Management)
1. **상태 머신**: `Build`, `Wave`, `GameOver`, `Victory` 상태를 `enum`으로 정의하여 게임 흐름 제어.
2. **배속 기능**: `Time.timeScale`을 조절하여 일시정지(0), 1배속(1), 2배속(2) 기능 구현.
3. **UI 연동**: 골드 잔액에 따른 타워 버튼 활성화/비활성화 및 웨이브 클리어 팝업 구현.

---

## 4. 코드 변환 예시 (JS vs C#)

### 타겟팅 알고리즘 비교

**JavaScript (원본)**
```javascript
findTarget(enemies, range) {
  let best = null;
  for (const e of enemies) {
    const d = dist(this.x, this.y, e.x, e.y);
    if (d <= range && e.distanceTraveled > (best?.distanceTraveled ?? -Infinity)) {
      best = e;
    }
  }
  return best;
}
```

**C# (유니티 변환)**
```csharp
public EnemyController FindTarget(float range) {
    EnemyController bestTarget = null;
    float maxDist = -1f;

    // 사거리 내의 모든 적(Collider2D) 검색
    Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);
    
    foreach (var target in targets) {
        if (target.TryGetComponent<EnemyController>(out var enemy)) {
            // 가장 멀리 이동한 적을 선택 (JS 로직과 동일)
            if (enemy.DistanceTraveled > maxDist) {
                maxDist = enemy.DistanceTraveled;
                bestTarget = enemy;
            }
        }
    }
    return bestTarget;
}
```

---

## 5. 유니티 특화 개선 제안
- **오브젝트 풀링(Object Pooling)**: 빈번하게 생성/소멸되는 적(Enemy)과 투사체(Projectile)의 성능 최적화.
- **이펙트 강화**: 투사체 충돌 시 파티클 시스템(Particle System)을 사용하여 타격감 향상.
- **애니메이션**: `Animator`를 사용하여 타워의 공격 반동 및 적의 움직임 구현.
- **사운드 관리**: `AudioSource`와 `AudioMixer`를 이용해 배경음 및 효과음 제어.
```outine 또는 Timer 기반) 적용.
   - **Cannon**: 범위 피해(`Physics2D.OverlapCircleAll`) 처리.
3. **투사체**: 타겟 방향으로 이동하며 거리 체크(`dist < 0.1f`)를 통해 충돌 및 데미지 로직 실행.

### 5단계: 게임 루프 및 UI (Game Management)
1. **상태 머신**: `Build`, `Wave`, `GameOver`, `Victory` 상태를 `enum`으로 정의하여 게임 흐름 제어.
2. **배속 기능**: `Time.timeScale`을 조절하여 일시정지(0), 1배속(1), 2배속(2) 기능 구현.
3. **UI 연동**: 골드 잔액에 따른 타워 버튼 활성화/비활성화 및 웨이브 클리어 팝업 구현.

---

## 4. 코드 변환 예시 (JS vs C#)

### 타겟팅 알고리즘 비교

**JavaScript (원본)**
```javascript
findTarget(enemies, range) {
  let best = null;
  for (const e of enemies) {
    const d = dist(this.x, this.y, e.x, e.y);
    if (d <= range && e.distanceTraveled > (best?.distanceTraveled ?? -Infinity)) {
      best = e;
    }
  }
  return best;
}
```

**C# (유니티 변환)**
```csharp
public EnemyController FindTarget(float range) {
    EnemyController bestTarget = null;
    float maxDist = -1f;

    // 사거리 내의 모든 적(Collider2D) 검색
    Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);
    
    foreach (var target in targets) {
        if (target.TryGetComponent<EnemyController>(out var enemy)) {
            // 가장 멀리 이동한 적을 선택 (JS 로직과 동일)
            if (enemy.DistanceTraveled > maxDist) {
                maxDist = enemy.DistanceTraveled;
                bestTarget = enemy;
            }
        }
    }
    return bestTarget;
}
```

---

## 5. 유니티 특화 개선 제안
- **오브젝트 풀링(Object Pooling)**: 빈번하게 생성/소멸되는 적(Enemy)과 투사체(Projectile)의 성능 최적화.
- **이펙트 강화**: 투사체 충돌 시 파티클 시스템(Particle System)을 사용하여 타격감 향상.
- **애니메이션**: `Animator`를 사용하여 타워의 공격 반동 및 적의 움직임 구현.
- **사운드 관리**: `AudioSource`와 `AudioMixer`를 이용해 배경음 및 효과음 제어.
```