using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateParent : MonoBehaviour
{



    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D other)	 　　//　何かがトリガーに当たった場合・・
    {
        if (other.gameObject.tag == "Player")      //　当たったオブジェクトのTagが”Player”なら・・
        {
            other.transform.parent = this.transform;
        }
    }
    public void OnCollisionExit2D(Collision2D other)	 　　//　何かがトリガーに当たった場合・・
    {
        if (other.gameObject.tag == "Player")      //　当たったオブジェクトのTagが”Player”なら・・
        {
            other.transform.parent = null;
        }
    }
}
