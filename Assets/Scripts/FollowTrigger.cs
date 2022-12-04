using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Follow Trigger")]
[RequireComponent(typeof(Rigidbody2D))]
public class FollowTrigger : Physics2DObject
{
    public Transform target;

    [Header("Movement")]
    public float speed = 1f;Å@Å@//í«Ç¢Ç©ÇØÇÈéûÇÃë¨Ç≥

    public bool lookAtTarget = false;
    public Enums.Directions useSide = Enums.Directions.Up;

    public bool isTriggered = false;


    void FixedUpdate()
    {
        if (target == null)
            return;


        if (lookAtTarget)
        {
            Utils.SetAxisTowards(useSide, transform, target.position - transform.position);
        }

        if (isTriggered == true)
        {
            rigidbody2D.MovePosition(Vector2.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed));
        }

        if (isTriggered == false)
            return;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTriggered = false;
        }
    }
}
