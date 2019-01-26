using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public float speed = 10.0f;
	private float translation = 0f;
	private float walking = 0f;
    public bool isWalking = false;

    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
		DirectionController();
	}

	public void DirectionController()
	{
		translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		walking = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.Translate(walking, 0, translation);

        if ((translation != 0 || walking != 0) && !isWalking)
        {
            isWalking = true;
            GetComponent<AudioSource>().Play();
        }
        else if (translation == 0 && walking == 0)
        {
            GetComponent<AudioSource>().Stop();
            isWalking = false;
        }

        if (Input.GetKeyDown("escape"))
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
