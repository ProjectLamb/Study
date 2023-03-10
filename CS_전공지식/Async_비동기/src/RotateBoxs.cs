using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class RotateBoxs : MonoBehaviour {
    public RotateAwait[] boxs;
    public GameObject Text;
    private List<UniTask> taskList;
    public async void SequenceRotate(){
        int i = 3;
        foreach(RotateAwait E in boxs){
            await E.MiniUpdate(i, E.HandleRotate); // 병렬과 차이점은 넣을때는 Forget을 넣지는 않는다.
            i+=2;
        }
        Text.SetActive(true);
    }

    public void ParallelRotate(){
        int i = 3;
        foreach(RotateAwait E in boxs){
            E.MiniUpdate(i, E.HandleRotate).Forget();
            i += 2;
        }   
    }
    public async void ParallelRotate2(){
        int i = 3;
        foreach(RotateAwait E in boxs){
            taskList.Add(E.MiniUpdate(i, E.HandleRotate)); // 병렬과 차이점은 넣을때는 Forget을 넣지는 않는다.
            i+=2;
        }
        await UniTask.WhenAll(taskList);
        Text.SetActive(true);
    }
    void Awake(){
        taskList = new List<UniTask>();
    }
    /*
    * Task를 통해서 리턴값을 얻어내는 방법
    */

    public int AddSequnce(int _num){
        int res = 0;
        for(int i = 0 ; i <= _num; i++){res += i; }
        return res;
    }
    public async UniTask<int> AsyncRandSunNum(){
        int random = UnityEngine.Random.Range(50, 1000);
        var task = Task.Run(() => AddSequnce(random));
        var result = await task;
        if(task.IsCanceled || task.IsFaulted) {
            return -1;
        }
        return result;
    } 

    public async UniTask AsyncGetNum(){
        int RandSum = await AsyncRandSunNum();
        Debug.Log(RandSum);
    }

    void Start(){
        //ParallelRotate();
        //ParallelRotate2();
        //SequenceRotate();
    }
    
    private void Update() {    
        if(Input.GetKeyDown(KeyCode.R)){
            AsyncGetNum().Forget();
        }
    }

}