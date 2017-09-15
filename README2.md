### Time.deltaTIme

 초당 값을 부여함, 프레임 값이 아님. smooth함

### Instantiate 

  게임 오브젝트의 클론을 만드는 함수이며 주로 프리팹을 이용해 만들어짐
  
  
```c#
 Instantiate(prefab);
 Instantiate(prefab,postion,rotation);
 
 Rigidbody rocketInstance;
 rocketInstance = Instantiate(prefab, postion, rotation) as Rigidbody;
 rocketInstance.addForce(barrelEnd.forwand * 5000)
```

### Invoke

```c#
    Invoke("method name","time"); // 리턴값이 void 인 것만 호출가능
    InvokeRepeating("method name","time","looptime"); // 첫 time 만큼 지연후 looptime 뒤에 생성함.
    CancelInvoke("method name"); //메소드 이름을 가진 것을 지
```

### Enumerations

```c#
//클래스 안에 선언함 해당 클래스만 사용가능 , 클래스밖에 선언하면 전체 가능

enum Direction {North,East,South,West};
```

### Switch