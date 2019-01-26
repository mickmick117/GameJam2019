using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;
	public GameObject character;

	private Vector2 mouseDirection;

    void Update()
    {
		MoveCamera();
	}

	public void MoveCamera()
	{
		mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		mouseDirection = Vector2.Scale(mouseDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

		smoothV.x = Mathf.Lerp(smoothV.x, mouseDirection.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp(smoothV.y, mouseDirection.y, 1f / smoothing);
		mouseLook += smoothV;

		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
	}
}
