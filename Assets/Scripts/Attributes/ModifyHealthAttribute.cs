﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Modify Health")]
public class ModifyHealthAttribute : MonoBehaviour
{
	public ParticleSystem pointEffect;
	public bool destroyWhenActivated = false;
	public int healthChange = -1;
	Vector2 Ppos;
	public GameObject Player;

	void Start()
    {
		Ppos = Player.transform.position;
    }

	//This will create a dialog window asking for which dialog to add
	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, true);
	}

	// This function gets called everytime this object collides with another
	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		HealthSystemAttribute healthScript = collisionData.gameObject.GetComponent<HealthSystemAttribute>();
		if (healthScript != null)
		{
			// subtract health from the player
			healthScript.ModifyHealth(healthChange);
			//pointEffect.transform.position = this.transform.position;
			//pointEffect = Instantiate(pointEffect);
			//pointEffect.Play();
			collisionData.transform.position = Ppos;
			if (destroyWhenActivated)
			{
				Destroy(this.gameObject);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D colliderData)
	{
		
	}
}
