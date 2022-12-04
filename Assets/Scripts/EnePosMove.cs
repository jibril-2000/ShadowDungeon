using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnePosMove : MonoBehaviour
{
    public GameObject enemy;        //�@�G�l�~�[�̃I�u�W�F�N�g������ϐ���p�ӂ��܂�
    private Vector2 enePos;      //�@���݂̃|�W�V�������i�[����ϐ���p�ӂ��܂�
    private Vector3 targetPos;       //�@Player�I�u�W�F�N�g�̃|�W�V�������i�[����ϐ���p�ӂ��܂�
    private float rad;           //�@�����������̃��W�A�����i�[����ϐ���p�ӂ��܂�
    public float speed;      //�@�G�l�~�[�̈ړ����x(������l)���i�[����ϐ���p�ӂ��܂�
    public GameObject particleObj;
    GameObject Player;

    void Start()
    {
        particleObj = GameObject.Find("P_Explosion");
        //�@�ϐ�targetPos�Ƀv���C���[�I�u�W�F�N�g���̈ʒu�f�[�^��T���ē���܂�
        targetPos = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        //�@�ڕW�ƂȂ�I�u�W�F�N�g�̂����W�̍���x���W�̍���p���āA����2�̐��̍��p�x�̃��W�A�������߂܂�
        rad = Mathf.Atan2(targetPos.y - this.transform.position.y, targetPos.x - this.transform.position.x);
    }
    void Update()
    {

        enePos = this.transform.position;          //�@�ϐ�enePos�Ɍ��݂̃G�l�~�[�̈ʒu�����܂� 
        enePos.x += speed * Mathf.Cos(rad);         //�@�ϐ�enePos��x�l�Ɂux�������̑傫���~speed�v�����܂�  
        enePos.y += speed * Mathf.Sin(rad);    //�@�ϐ�enePos��x�l�Ɂuy�������̑傫���~speed�v�����܂� 
        this.transform.position = enePos;   //�@���݂̈ʒu�ɁA�v�Z���ē���ꂽposition�l�����܂�

        if (this.gameObject.transform.position.y <= -100f)
        {
            Destroy(this.gameObject);

        }

        speed = 0.1f;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            ParticleSystem particle = particleObj.GetComponent<ParticleSystem>();
            particle.transform.position = other.gameObject.transform.position;
            particle.Play();
            //explosion�G�t�F�N�g���Đ����܂�
            //explosion�G�t�F�N�g���Đ����܂�
            Destroy(this.gameObject);

        }
    }
}

