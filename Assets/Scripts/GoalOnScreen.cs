using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalOnScreen : MonoBehaviour
{
    public float timeCount = 100.0f;		// �S�[�����o���܂ł̎��Ԃ�����ϐ�timeCount��p�ӂ���60�����܂� 
    public GameObject goalObj;      //�@�Q�[���I�u�W�F�N�g�^�̕ϐ�goalObje��p�ӂ��܂�


    void Start()				//�@Start()���\�b�h�ł��B�J�n���Ɉ�񂾂��ǂݍ��܂�܂�
    {
        goalObj.SetActive(false);		//�@goalObj�ϐ����̃I�u�W�F�N�g���\���ɂ��܂�
    }


    void Update()				//�@���t���[���Ăяo�����Update() ���\�b�h�ł��B���t���[����������܂��B
    {
        timeCount -= 0.1f;			//�@�ϐ�timeCount����0.1���������čs���܂�
        if (timeCount <= 0f)		//�@�����AtimeCount�̒l���O�ȉ��ɂȂ�����E�E
        {
            goalObj.SetActive(true);		 //�@goalObj�ϐ����̃I�u�W�F�N�g��\�����܂�
        }
    }
}
