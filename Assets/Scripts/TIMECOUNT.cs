using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIMECOUNT : MonoBehaviour
{
    //�J�E���g�_�E��
    public float countdown;
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject Restart;
    [SerializeField] GameObject Quit;

    //���Ԃ�\������Text�^�̕ϐ�
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
        //���Ԃ��J�E���g�_�E������
        countdown -= Time.deltaTime;

        //���Ԃ�\������
        timeText.text = countdown.ToString("f1");

        //countdown��0�ȉ��ɂȂ����Ƃ�
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
