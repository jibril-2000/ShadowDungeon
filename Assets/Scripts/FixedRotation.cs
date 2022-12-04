using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour
{

    public float maxAngle = 15.0f;		//最大の傾く時の角度を入れる変数maxAngle
    public float minAngle = -15.0f;		 //最小の傾く時の角度を入れる変数minAngle
    public float speed = 1.5f;       //角度を変える値を入れる変数speed
    public float BulletSpeed;
    private float angleZ;                           // 浮動小数点型の変数angleZ
    private float rotateZ;
    public float rapid;
    public GameObject ballObj;          // 　生成したいPrefab//　ボールを出せるようになるまでの時間　float型の変数を用意します
    private float oriRapid;// 浮動小数点型の変数rotateZ

    void Start()
    {
        oriRapid = rapid;
    }
    void FixedUpdate()
    {
        float deltaZ = Input.GetAxis("Horizontal");　　//　水平方向の入力の値を格納する変数deltaZを用意して、入力された値を入れますます
        if (transform.eulerAngles.z > 180)　　　　　//　もしtransformの角度（オイラー表示の角度）が180度より大きければ・・
        {
            rotateZ = transform.eulerAngles.z - 360;　　//　その角度から360を引いて0～180度に修正した値を変数rotateZに入れます　
        }
        rotateZ = transform.eulerAngles.z;                  //　変数rotateZに現在のtransformの角度（オイラー表示の角度）を入れます
        angleZ = Mathf.Clamp(rotateZ - deltaZ * speed, minAngle, maxAngle);
        //「Math.Clamp」は範囲内の数値だけに制限する関数、　変数a = Mathf.Clamp(得られた値、最小値、最大値);と書く
        //　変数angleZに変数rotateZの値にspeed変数を掛けた値が、minAngleとMaxAngleの間の値ならそれを入れ、それ以外は最大値、最小値　　
        //を入れます
        if (angleZ < 0)
        {
            angleZ = angleZ + 360;              // angleZの値が0より小さければ、360を足した値を入ます（違うならそのままの値を入れます）
        }
        transform.rotation = Quaternion.Euler(0, 0, angleZ);　　　//　オイラー角をクオータニオン（4元数）に変換してrotationに入れます
        float canonRad = this.transform.eulerAngles.z * Mathf.Deg2Rad;        // canonの傾きからラジアンを求めます
        Vector3 canonAngle = new Vector3(Mathf.Cos(canonRad), Mathf.Sin(canonRad), 0).normalized;
        rapid -= 0.05f;
        /*if (rapid <= 0&&Input.GetKey("space"))
        {
            GameObject ball = Instantiate(ballObj, this.transform.position, this.transform.rotation);
            //　muzzleの位置にボールを生成します
            Debug.Log(canonAngle);
            ball.GetComponent<Rigidbody2D>().AddForce(canonAngle * BulletSpeed);
            //　ボールにrigidbody2Dをいれて、canonAngleの方向に力を加えます		
            rapid = oriRapid;            //　rapidに元のoriRapidの値を入れて戻します　

        }*/
    }
}
