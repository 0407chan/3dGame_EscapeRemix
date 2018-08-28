using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPC : MonoBehaviour {
    public GameObject bomb;
    public float power = 10.0f;
    public float raduis = 5.0f;
    public float upforce = 1.0f;

	
	// Update is called once per frame
	void FixedUpdate () {
		if (bomb == enabled)
        {
            Invoke("Detonate", 5);
        }
	}
    void Detonate()
    {
        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, raduis);
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, raduis, upforce, ForceMode.Impulse);
            }
        }
    }
    

}
