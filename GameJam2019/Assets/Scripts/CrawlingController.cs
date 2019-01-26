using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingController : MonoBehaviour
{
	public float speed = 5;
	public Animator crawlingAnimator;
	public Transform destination;
	public GameObject character;
	public bool isTrigger = false;
	public float soundDelay;


	private void Start()
	{
		character.SetActive(false);
	}

	public void StartCrawling()
	{
		character.SetActive(true);
		crawlingAnimator.SetBool("Start", true);
		StartCoroutine(CrawlingThread());
	}

	IEnumerator CrawlingThread ()
	{
		//yield return new WaitForSeconds(1);
		while ( Vector3.Distance(character.transform.position, destination.position) > 0.1f)
		{
			character.transform.position = Vector3.MoveTowards(character.transform.position, destination.position, speed * Time.deltaTime);
			yield return null;
		}
		character.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!isTrigger)
		{
			isTrigger = true;
			StartCrawling();
		}		
	}
}
