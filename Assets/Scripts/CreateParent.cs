using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateParent : MonoBehaviour
{



    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D other)	 �@�@//�@�������g���K�[�ɓ��������ꍇ�E�E
    {
        if (other.gameObject.tag == "Player")      //�@���������I�u�W�F�N�g��Tag���hPlayer�h�Ȃ�E�E
        {
            other.transform.parent = this.transform;
        }
    }
    public void OnCollisionExit2D(Collision2D other)	 �@�@//�@�������g���K�[�ɓ��������ꍇ�E�E
    {
        if (other.gameObject.tag == "Player")      //�@���������I�u�W�F�N�g��Tag���hPlayer�h�Ȃ�E�E
        {
            other.transform.parent = null;
        }
    }
}
