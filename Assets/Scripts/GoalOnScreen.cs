using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalOnScreen : MonoBehaviour
{
    public float timeCount = 100.0f;		// ゴールを出すまでの時間を入れる変数timeCountを用意して60を入れます 
    public GameObject goalObj;      //　ゲームオブジェクト型の変数goalObjeを用意します


    void Start()				//　Start()メソッドです。開始時に一回だけ読み込まれます
    {
        goalObj.SetActive(false);		//　goalObj変数内のオブジェクトを非表示にします
    }


    void Update()				//　毎フレーム呼び出されるUpdate() メソッドです。毎フレーム処理されます。
    {
        timeCount -= 0.1f;			//　変数timeCountから0.1だけ引いて行きます
        if (timeCount <= 0f)		//　もし、timeCountの値が０以下になったら・・
        {
            goalObj.SetActive(true);		 //　goalObj変数内のオブジェクトを表示します
        }
    }
}
