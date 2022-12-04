using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotMove : MonoBehaviour
{
    public GameObject centerObj;　　//中心となるオブジェクトを入れます
    public float angle ;           //回転スピード	
    Vector3 target;         //中心となるオブジェクトの座標を入れます

    private void Start()
    {
        target = centerObj.transform.position;　　 //中心となるオブジェクトの座標を取り込みます
    }

    void Update()
    {
        //このオブジェクトのTransformを「RotateAround(中心の場所,軸,回転角度)」で毎フレーム書き換えます
        transform.RotateAround(target, Vector3.forward, angle * Time.deltaTime);
    }
}


