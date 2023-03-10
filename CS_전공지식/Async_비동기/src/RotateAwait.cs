using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;

public class RotateAwait : MonoBehaviour
{
    public void rotateObject(float _i, float _k){
        float rotateAmount =  360 * (_i / _k);
        transform.rotation = Quaternion.Euler(0,0,rotateAmount % 360f);
    }
    public UnityAction<float, float> HandleRotate;
    public async UniTask MiniUpdate(float _second, UnityAction<float, float> _CallBack){
        float passedTime = 0;
        while(passedTime < _second){
            passedTime += Time.deltaTime;
            _CallBack(passedTime, _second);
            await UniTask.Yield();
        }
    }
    private void Awake() {
        HandleRotate = rotateObject;
    }
}
