using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour	 //　Scrollという名のクラスです
{
    public float speed = 1.0f;  //　浮動小数点型の変数speedを用意して、1.0f　を入れます
    private Vector3 oriPos;            //   Vector3型の変数oriPosを用意します
    public GameObject enemy;
    void Start()
    {
        oriPos = gameObject.transform.position;      //   開始時のこのオブジェクトの位置データを取り込みます
    }
    void Update()		 //　毎フレーム実行されるUpdate()メソッド
    {
        transform.position -= new Vector3(0f, Time.deltaTime * speed, 0f);　//　このオブジェクトの位置座標（x,y,z）の各値に、(0,フレームごとの経過時間×変数speed,0)を引いて、入れ直します

        if (transform.position.y <= -100.0f)　 //　もし、y座標の値が―100より小さければ・・
        {
            if (gameObject.tag == "Ground")　　//　もしこのゲームオブジェクトのtagが”Ground”なら・・
            {
                Destroy(gameObject);　　　 　             //　このゲームオブジェクトを破壊します 　
            }
            transform.position = new Vector3(Random.Range(0,200), 100.0f, 0f);　 
            
            if (this.gameObject.tag == "EnemyPlane")
            {
                Instantiate(enemy, this.transform.position, enemy.transform.rotation=Quaternion.Euler(0.0f, 0.0f, -90));
            }
        }
        if (this.gameObject.tag=="EnemyShip"&&transform.position.y <= 13)
        {

            this.gameObject.GetComponent<Scroll>().enabled = false;
        }
    }
}
