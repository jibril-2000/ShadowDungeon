using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPbar : MonoBehaviour
{
    [SerializeField] Image HPber;
    [SerializeField] GameObject HPberObj;
    public GameObject Player;
    [SerializeField] float Ypos;
    HealthSystemAttribute EneHP ;
    float Num,EnemyHP,EnemyMax;

    void Start()
    {
        EneHP =Player.GetComponent<HealthSystemAttribute>();

        
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (EneHP.health >= 1&&EneHP!=null)
        {


            var PlayerPos = new Vector2(Player.transform.position.x, Player.transform.position.y + Ypos);
            HPberObj.transform.position = PlayerPos;
            EnemyHP = EneHP.health;
            EnemyMax = EneHP.maxHealth;
            Num = EnemyHP / EnemyMax;
            HPber.fillAmount = Num;
            //Debug.Log(Num);
        }
    }
}
