# Random.Range()

## 1. 정의

**Random.Range(min,max)를 사용하여 min과 max 사이의 값 중 랜덤값을 골라낼 수 있다.**

## 2. 사용 예시

```csharp
void RandomNumber
{
int randomNum;
randomNum = Random.Range(0,10):
}
```

▲ **int형 변수 randomNum에 0에서 10 사이의 난수를 할당하는 과정이다.**

## 3. float형과 int형의 범위 차이

### ▶️ 만약  범위를 int형으로 했을 경우

- **Random.Range(1, 10)의 반환 값은 1~10 사이의 값을 포함하되 최댓값 10은 포함하지 않는다(0~9까지만)**

### ▶️ 만약  범위를 float형으로 했을 경우

- **Random.Range(1.0f, 10.0f)의 반환 값은 1.0~10.0 사이의 값을 포함하되 1.0과 10.0 양쪽 모두 포함한다.**

### ⭐ Random.Range()를 사용하는 과정에서 float형과 int형, 즉 실수형과 정수형   의 범위가 각각 다르다는 것을 인지하여야 한다.