using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    [SerializeField] GameObject ClearTx;
    [SerializeField] GameObject Restart;
    [SerializeField] GameObject Quit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

 private void OnCollisionEnter2D(Collision2D other)
    {
        ClearTx.SetActive(true);
        Restart.SetActive(true);
        Quit.SetActive(true);
        Time.timeScale = 0f;
        Destroy(gameObject);
    }
}
