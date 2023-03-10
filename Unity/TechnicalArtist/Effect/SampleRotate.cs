using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveAxisSate{
    X,Y,Z
}


public class SampleRotate : MonoBehaviour {
    public float RotateSpeed = 0.0f;
    public MoveAxisSate Axis;

    private void Update() {
        if(Axis == MoveAxisSate.X){
            transform.Rotate(Vector3.right * Time.deltaTime * RotateSpeed);
        }
        if(Axis == MoveAxisSate.Y){
            transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
        }
        if(Axis == MoveAxisSate.Z){
            transform.Rotate(Vector3.forward * Time.deltaTime * RotateSpeed);
        }
    }    
}