## 2시간 안에 목표치를 할 수 있는가?

 - SubItemUI 실제 데이터랑 연동 / 바인딩
    - Icon(Image)를 Resources Load하기
    - DataManager가 메모리에 읽을 수 있도록 세팅하기 - @@Dict 가져올 수 있다.
    - Resources/Sprite/UI 폴더 안에 있는 icon. texture2D를 DataManager에서 읽어올 수 있어야 한다.
    - JSON에 있는 IconName을 Key값으로 사용할 수 있는 구조를 만들어야 한다.

- 느낀점
    - sprite타입과 texture2D가 있는데, icon과 같은 경우는 sprite이기 때문에 iconData 클래스 타입에서 sprite로 저장하도록 코드를 작성해야한다.