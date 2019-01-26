using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dolly : MonoBehaviour
{
	float recul = 10;
	float fov = 20;
	float currentfov = 0;
	float duree = 2;
    // Start is called before the first frame update
    void Start()
    {
        currentfov = GetComponent<Camera>().fieldOfView;
		StartCoroutine(dollyzoom());
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator dollyzoom ()
	{
		while (GetComponent<Camera>().fieldOfView > currentfov-fov)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - Time.deltaTime/duree * recul);
			GetComponent<Camera>().fieldOfView -= Time.deltaTime/duree * fov;
			yield return null;
		}
		
	}
}
