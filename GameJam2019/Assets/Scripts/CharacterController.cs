using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public float speed = 10.0f;
	private float translation = 0f;
	private float walking = 0f;
    public bool isWalking = false;
    public GameObject inventoryMenu;
    public GameObject pauseMenu;
	public GameObject MainMenu;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inventoryMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    void Update()
    {
		if (!MainMenu.activeSelf)
		{
			DirectionController();
		}		
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
            Time.timeScale = 0.0f;
			Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
        }

        if (Input.GetKeyDown("r") && !pauseMenu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            inventoryMenu.SetActive(true);
        }
    }
}
