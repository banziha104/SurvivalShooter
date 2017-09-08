# SurvivalShooter

### Awake vs Start

<li> Awake : 스크립트가 비활성화 되어도, 시작할대 호출됨
<li> Start : 활성화 상태일 때 호출됨

### Update vs FixedUpdate()
<li> update : 업데이트는 시간 간격으로 호출되지 않음
<li> FixedUpdate : 일정한 시간 간격으로 호출됨. 

### 벡터

<li> Magnitude : 두 점사이를 이은 선
<li> Velocity : 시간에 따른 위치의 변화

### Active

<li> gameobject.activeSelf : 자기자신이 활성화 상태인지
<li> gameobject.activeInHierarchy: 부모오브젝트가 꺼져있는지
<li> gameobject.setActivity(true/false) : 활성화/비활성화

### Translate && Rotation

```c#
transform.Translate(new Vector3(0.0.1)*Time.deltaTime);
```

```c#
transform.Rotate(Vector3.up,-turnSpeed * Time.deltaTime); //회전축 속
```

### LookAt

```c#
void Update()
{
    transform.LookAt(target); 
}
```

### Destory

Destroy(GameObject/ Component, Time)

```c#
 Destory(GetComponet<RigidBody>,3f);
```

### Axis
<li> -1 1 사이의 부동값을 반환함.


### Linear Interpolation

### FixedUpdate()

### Input.GetAxisRaw()

### movement.nomalized

### Nav Mash Agent