# Space Clicker Game

> 유니티로 만든 우주 테마 클릭커 게임 포트폴리오 프로젝트
---

## 게임 소개

클릭으로 에너지를 모으고, 업그레이드를 구매해 자동 생산을 늘려가는 클릭커 게임입니다.
환생 시스템으로 영구 보너스를 쌓아가며 더 빠르게 성장할 수 있습니다.

---

## 주요 기능

### 클릭 시스템
- 화면 전체를 클릭 영역으로 활용
- 클릭 위치에 따라 FloatingText 피드백 표시
- 프레스티지 보너스 적용된 클릭당 에너지 획득

### 자동화 시스템
- ScriptableObject 기반 업그레이드 데이터 관리
- 6종류의 업그레이드 (태양광 패널 ~ 빅뱅 머신)
- 구매할수록 가격이 증가하는 동적 가격 시스템 (x1.15)
- 초당 생산량(PPS) 실시간 표시

### 세이브 시스템
- PlayerPrefs 기반 자동 저장 (30초마다)
- 게임 종료 시 자동 저장
- 오프라인 보상 (최대 8시간)

### 프레스티지 시스템
- 에너지 1M 달성 시 환생 가능
- 환생마다 클릭 보너스 +10% 영구 증가
- 환생 횟수 저장

### 업적 시스템
- 클릭 횟수 / 총 에너지 / 환생 횟수 기반 업적
- 달성 시 팝업 알림
- 리셋 시 업적도 초기화

### UI / UX
- 미니멀 플랫 디자인
- 스크롤 가능한 업그레이드 패널
- 사운드 이펙트 (클릭 / 구매 / 환생)

---

## 기술 스택

| 항목 | 내용 |
|------|------|
| 엔진 | Unity 6 |
| 언어 | C# |
| UI | uGUI (TextMeshPro) |
| 데이터 | ScriptableObject |
| 저장 | PlayerPrefs |
| 패턴 | Singleton Manager 패턴 |

---

## 📁 프로젝트 구조

```
Assets/
└── _Project/
    ├── Scripts/
    │   ├── Managers/
    │   │   ├── GameManager.cs
    │   │   ├── UpgradeManager.cs
    │   │   ├── SaveManager.cs
    │   │   ├── ResetManager.cs
    │   │   ├── PrestigeManager.cs
    │   │   ├── AchievementManager.cs
    │   │   ├── AudioManager.cs
    │   │   └── FloatingTextManager.cs
    │   ├── UI/
    │   │   ├── UpgradeButton.cs
    │   │   ├── PrestigeButton.cs
    │   │   ├── ResetButton.cs
    │   │   ├── AchievementPopup.cs
    │   │   └── FloatingText.cs
    │   └── Data/
    │       ├── UpgradeData.cs
    │       └── AchievementData.cs
    ├── ScriptableObjects/
    │   ├── Upgrades/
    │   └── Achievements/
    ├── Prefabs/
    │   └── UI/
    └── Audio/
```

---

## 실행 방법

1. Unity 6 이상 설치
2. 저장소 클론
```bash
git clone https://github.com/chun1402/Cliker_Game.git
```
3. Unity Hub에서 프로젝트 열기
4. `Assets/Scenes/SampleScene` 실행

---

## 배운 점

- ScriptableObject를 활용한 데이터 기반 설계
- Singleton 패턴으로 매니저 구조 설계
- uGUI 레이아웃 시스템 (Scroll View, Layout Group)
- PlayerPrefs를 활용한 저장 시스템
- 코루틴을 활용한 자동 생산 시스템

---

## 👤 개발자
- chun1402
- 개발 기간: 2026년 04.08 ~ 05.01
- 개발 환경: Unity 6, Visual Studio
