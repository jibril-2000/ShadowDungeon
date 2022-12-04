using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIMECOUNT : MonoBehaviour
{
    //カウントダウン
    public float countdown;
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject Restart;
    [SerializeField] GameObject Quit;

    //時間を表示するText型の変数
    public Text timeText;
    void Start()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1");

        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            timeText.text = "OVER";
            Lose.SetActive(true);
            Restart.SetActive(true);
            Quit.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
