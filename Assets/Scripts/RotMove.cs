using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotMove : MonoBehaviour
{
    public GameObject centerObj;�@�@//���S�ƂȂ�I�u�W�F�N�g�����܂�
    public float angle ;           //��]�X�s�[�h	
    Vector3 target;         //���S�ƂȂ�I�u�W�F�N�g�̍��W�����܂�

    private void Start()
    {
        target = centerObj.transform.position;�@�@ //���S�ƂȂ�I�u�W�F�N�g�̍��W����荞�݂܂�
    }

    void Update()
    {
        //���̃I�u�W�F�N�g��Transform���uRotateAround(���S�̏ꏊ,��,��]�p�x)�v�Ŗ��t���[�����������܂�
        transform.RotateAround(target, Vector3.forward, angle * Time.deltaTime);
    }
}


