using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject particleObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
            ParticleSystem particle = particleObj.GetComponent<ParticleSystem>();
            particle.transform.position = other.gameObject.transform.position;
            particle.Play();
        //explosionエフェクトを再生します
        //
        //this.GetComponent<SpriteRenderer>().enabled = false;
        //Destroy(other.gameObject);

        
    }
}
