using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onceshooter : MonoBehaviour
{
    [Header("Object creation")]
    private Animator anime;
    public GameObject prefabToSpawn;
    // The key to press to create the objects/projectiles
    public KeyCode keyToPress = KeyCode.Space;

    [Header("Other options")]
    // The rate of creation, as long as the key is pressed
    public float creationRate = .5f;
    // The speed at which the object are shot along the Y axis
    public float shootSpeed = 5f;
    public Vector2 shootDirection = new Vector2(0f, 2f);
    public bool relativeToRotation = true;
    private float timeOfLastSpawn;
    // Will be set to 0 or 1 depending on how the GameObject is tagged
    private int playerNumber;
    public GameObject Money;
    public Text Text;
    int TotalMoney=0;


    public int bullets;
    int Ori;

    void Start()
    {
        timeOfLastSpawn = -creationRate;
        Ori=bullets;
        anime = transform.root.gameObject.GetComponent<Animator>();
        anime.SetBool("Attack", false);
    }
    void Update()
    {
        if (Input.GetKeyUp(keyToPress))
        {
            anime.SetBool("Attack", false);
        }
        if (bullets >= 1)
        {
            if (Input.GetKeyDown(keyToPress)
               && Time.time >= timeOfLastSpawn + creationRate)
            {
                anime.SetBool("Attack", true);
                Invoke("AAA",0.8f);
                

                timeOfLastSpawn = Time.time;
                bullets -= 1;
                TotalMoney++;
                Text.text = TotalMoney + "–œ‰~";
               
            }


        }
    }void AAA()
    {
        Vector2 actualBulletDirection = (relativeToRotation) ? (Vector2)(Quaternion.Euler(0, 0, transform.eulerAngles.z) * shootDirection) : shootDirection;

        GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
        newObject.transform.position = this.transform.position;
        newObject.transform.eulerAngles = new Vector3(0f, 0f, Utils.Angle(actualBulletDirection));
        newObject.tag = "Bullet";

        // push the created objects, but only if they have a Rigidbody2D
        Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {

            rigidbody2D.AddForce(actualBulletDirection * shootSpeed, ForceMode2D.Impulse);
        }
        if (bullets <= 0)
        {

            GameObject cannon = GameObject.Find("Player/Cannon-Sword");
            bullets = Ori;
            anime.SetBool("Attack", false);
            cannon.SetActive(false);
            Money.SetActive(true);
        }
        else return;
    }
}

