using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
    public class ExplosionPhysicsForce : MonoBehaviour
    {
		
        public float explosionForce = 4;
        public float UpForce = 1.0f;
        public float radius = 1.0f;
		public float power = 10f;
		

        private IEnumerator Start()
        {
            // wait one frame because some explosions instantiate debris which should then
            // be pushed by physics force
            yield return null;

            addforce();
        }

        public void addforce()
        {
            
            var cols = Physics.OverlapSphere(transform.position, radius);
            var rigidbodies = new List<Rigidbody>();
            foreach (var col in cols)
            {
				if (col.gameObject.tag == "Player")
				{
					if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
					{
						rigidbodies.Add(col.attachedRigidbody);
					}
				}
            }
            foreach (var rb in rigidbodies)
            {
				//rb.AddExplosionForce(explosionForce, transform.position, radius, UpForce, ForceMode.Impulse);
				Vector3 moveDirection = rb.transform.position - this.transform.position;
				//rb.AddForce(transform.up * UpForce, ForceMode.Impulse);
				rb.AddForce(moveDirection.normalized * power , ForceMode.Impulse);
			}
        }

    }
}
