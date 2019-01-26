using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingController : MonoBehaviour
{
	public float speed = 5;
	public Animator crawlingAnimator;
	public Transform destination;


	private void Start()
	{
		StartCrawling();
	}

	public void StartCrawling()
	{
		crawlingAnimator.SetBool("Start", true);
		StartCoroutine(CrawlingThread());
	}

	IEnumerator CrawlingThread ()
	{
		yield return new WaitForSeconds(1);
		while (transform.position != destination.position)
		{
			transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
			yield return null;
		}
	}
}
