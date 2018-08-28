using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remix : MonoBehaviour {

    public GameObject target;
	public Animator anim;
    public GameObject shot;
    public Transform shotSpawn;
	public GameObject RemMan;
	public static bool isMap3;

	public bool isDone;
    public float throwPower = 1F;
    public float upPower = 1F;
    public float nextFire = 0.0F;
    public float fireRate = 0.5F;
    public float distance;
	public float waitTime;
	Vector3 direction;

	// Use this for initialization
	private void Start () {
		anim = GetComponent<Animator>();
		waitTime = 0.8f;
		StartCoroutine(UpdateCoroutine());
		direction = (target.transform.position - transform.position).normalized;
		isMap3 = false;

		isDone = RemMan.GetComponent<RemixManager>().GetDone();
	}

	IEnumerator UpdateCoroutine()
	{
		while (true)
		{
			FaceTarget();
			distance = Vector3.Distance(this.transform.position, target.transform.position);
			if (isMap3)
			{
				if (Time.time > nextFire)
				{
					anim.SetBool("Throw", true);
					nextFire = Time.time + fireRate;
					if (isDone)
					{
						RemMan.GetComponent<RemixManager>().RemixOff();
						RemMan.GetComponent<RemixManager>().SetDone();
					}
					
					yield return new WaitForSeconds(waitTime);
					GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
					//clone.GetComponent<Rigidbody>().AddForce(transform.up * throwPower, ForceMode.Impulse);
					clone.GetComponent<Rigidbody>().AddForce(transform.forward * distance * throwPower, ForceMode.Impulse);
					clone.GetComponent<Rigidbody>().AddForce(transform.up * upPower, ForceMode.Impulse);
					anim.SetBool("Throw", false);
				}
			}
			
			yield return null;
		}
	}

	public void FireRateFaster()
	{
		fireRate--;
	}
	public void FireRateLower()
	{
		fireRate++;
	}

    public void FaceTarget()
    {
        direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 20f);
    }

	
}
