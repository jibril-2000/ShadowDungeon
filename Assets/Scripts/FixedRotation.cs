using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour
{

    public float maxAngle = 15.0f;		//�ő�̌X�����̊p�x������ϐ�maxAngle
    public float minAngle = -15.0f;		 //�ŏ��̌X�����̊p�x������ϐ�minAngle
    public float speed = 1.5f;       //�p�x��ς���l������ϐ�speed
    public float BulletSpeed;
    private float angleZ;                           // ���������_�^�̕ϐ�angleZ
    private float rotateZ;
    public float rapid;
    public GameObject ballObj;          // �@����������Prefab//�@�{�[�����o����悤�ɂȂ�܂ł̎��ԁ@float�^�̕ϐ���p�ӂ��܂�
    private float oriRapid;// ���������_�^�̕ϐ�rotateZ

    void Start()
    {
        oriRapid = rapid;
    }
    void FixedUpdate()
    {
        float deltaZ = Input.GetAxis("Horizontal");�@�@//�@���������̓��͂̒l���i�[����ϐ�deltaZ��p�ӂ��āA���͂��ꂽ�l�����܂��܂�
        if (transform.eulerAngles.z > 180)�@�@�@�@�@//�@����transform�̊p�x�i�I�C���[�\���̊p�x�j��180�x���傫����΁E�E
        {
            rotateZ = transform.eulerAngles.z - 360;�@�@//�@���̊p�x����360��������0�`180�x�ɏC�������l��ϐ�rotateZ�ɓ���܂��@
        }
        rotateZ = transform.eulerAngles.z;                  //�@�ϐ�rotateZ�Ɍ��݂�transform�̊p�x�i�I�C���[�\���̊p�x�j�����܂�
        angleZ = Mathf.Clamp(rotateZ - deltaZ * speed, minAngle, maxAngle);
        //�uMath.Clamp�v�͔͈͓��̐��l�����ɐ�������֐��A�@�ϐ�a = Mathf.Clamp(����ꂽ�l�A�ŏ��l�A�ő�l);�Ə���
        //�@�ϐ�angleZ�ɕϐ�rotateZ�̒l��speed�ϐ����|�����l���AminAngle��MaxAngle�̊Ԃ̒l�Ȃ炻������A����ȊO�͍ő�l�A�ŏ��l�@�@
        //�����܂�
        if (angleZ < 0)
        {
            angleZ = angleZ + 360;              // angleZ�̒l��0��菬������΁A360�𑫂����l����܂��i�Ⴄ�Ȃ炻�̂܂܂̒l�����܂��j
        }
        transform.rotation = Quaternion.Euler(0, 0, angleZ);�@�@�@//�@�I�C���[�p���N�I�[�^�j�I���i4�����j�ɕϊ�����rotation�ɓ���܂�
        float canonRad = this.transform.eulerAngles.z * Mathf.Deg2Rad;        // canon�̌X�����烉�W�A�������߂܂�
        Vector3 canonAngle = new Vector3(Mathf.Cos(canonRad), Mathf.Sin(canonRad), 0).normalized;
        rapid -= 0.05f;
        /*if (rapid <= 0&&Input.GetKey("space"))
        {
            GameObject ball = Instantiate(ballObj, this.transform.position, this.transform.rotation);
            //�@muzzle�̈ʒu�Ƀ{�[���𐶐����܂�
            Debug.Log(canonAngle);
            ball.GetComponent<Rigidbody2D>().AddForce(canonAngle * BulletSpeed);
            //�@�{�[����rigidbody2D������āAcanonAngle�̕����ɗ͂������܂�		
            rapid = oriRapid;            //�@rapid�Ɍ���oriRapid�̒l�����Ė߂��܂��@

        }*/
    }
}
