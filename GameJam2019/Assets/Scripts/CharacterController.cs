using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public float speed = 10.0f;
	private float translation = 0f;
	private float walking = 0f;

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

		if (Input.GetKeyDown("escape"))
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
