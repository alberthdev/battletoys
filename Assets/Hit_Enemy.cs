using UnityEngine;
using System.Collections;
using VibrationType = Thalmic.Myo.VibrationType;

namespace CompleteProject
{
	public class Hit_Enemy : MonoBehaviour {
		void OnCollisionEnter (Collision col)
		{
			if(col.gameObject.tag == "Enemy")
			{
				Debug.Log ("Enemy hit delected! Enemy: " + col.gameObject.name);

				EnemyHealth enemyHealth = col.gameObject.GetComponent <EnemyHealth> ();
				
				// If the EnemyHealth component exist...
				if(enemyHealth != null)
				{
					Debug.Log (" -> This enemy is taking damage! Health: " + enemyHealth.currentHealth);
					ThalmicMyo thalmicMyo = GameObject.Find ("Myo").GetComponent<ThalmicMyo> ();
					thalmicMyo.Vibrate (VibrationType.Medium);
					// ... the enemy should take damage.
					var contact = new Vector3(0, 0, 0);
					enemyHealth.TakeDamage (20, contact);
				} else {
					Debug.Log (" -> This enemy heath is NULL");
				}
			}
		}
	}
}