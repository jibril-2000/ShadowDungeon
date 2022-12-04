using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour	 //�@Scroll�Ƃ������̃N���X�ł�
{
    public float speed = 1.0f;  //�@���������_�^�̕ϐ�speed��p�ӂ��āA1.0f�@�����܂�
    private Vector3 oriPos;            //   Vector3�^�̕ϐ�oriPos��p�ӂ��܂�
    public GameObject enemy;
    void Start()
    {
        oriPos = gameObject.transform.position;      //   �J�n���̂��̃I�u�W�F�N�g�̈ʒu�f�[�^����荞�݂܂�
    }
    void Update()		 //�@���t���[�����s�����Update()���\�b�h
    {
        transform.position -= new Vector3(0f, Time.deltaTime * speed, 0f);�@//�@���̃I�u�W�F�N�g�̈ʒu���W�ix,y,z�j�̊e�l�ɁA(0,�t���[�����Ƃ̌o�ߎ��ԁ~�ϐ�speed,0)�������āA���꒼���܂�

        if (transform.position.y <= -100.0f)�@ //�@�����Ay���W�̒l���\100��菬������΁E�E
        {
            if (gameObject.tag == "Ground")�@�@//�@�������̃Q�[���I�u�W�F�N�g��tag���hGround�h�Ȃ�E�E
            {
                Destroy(gameObject);�@�@�@ �@             //�@���̃Q�[���I�u�W�F�N�g��j�󂵂܂� �@
            }
            transform.position = new Vector3(Random.Range(0,200), 100.0f, 0f);�@ 
            
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
