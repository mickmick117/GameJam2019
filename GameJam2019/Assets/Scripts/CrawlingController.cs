using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingController : MonoBehaviour
{
	public float speed = 5;
	public Animator crawlingAnimator;
	public Transform destination;

    void Start()
    {
        
    }

    void Update()
    {
		//pMenu.transform.position = Vector3.MoveTowards(pMenu.transform.position, endPosition, speed * Time.deltaTime);
	}

	public void StartCrawling()
	{
		crawlingAnimator.SetBool("Start", true);
		transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
	}
}
