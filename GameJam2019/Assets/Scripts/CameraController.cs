using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private struct PointInSpace
	{
		public Quaternion rotation;
		public float Time;
	}

	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;
	public GameObject character;
	public GameObject flashLight;
	public float delay = 0.5f;
	public float speed = 5;

	private Vector2 mouseDirection;
	public float md;

    public GameObject inventoryMenu;

    private Queue<PointInSpace> pointsInSpace = new Queue<PointInSpace>();

	private void LateUpdate()
	{
        if (!inventoryMenu.activeSelf)
		    MoveCamera();
	}

	public void MoveCamera()
	{
		mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		mouseDirection = Vector2.Scale(mouseDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

		smoothV.x = Mathf.Lerp(smoothV.x, mouseDirection.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp(smoothV.y, mouseDirection.y, 1f / smoothing);
		mouseLook += smoothV;

		flashLight.transform.position = transform.position;
		character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

		if (Mathf.Abs(-mouseLook.y) <= 90)
		{
			transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		}
		pointsInSpace.Enqueue(new PointInSpace() { rotation =  Quaternion.Euler(transform.eulerAngles.x, character.transform.eulerAngles.y, flashLight.transform.eulerAngles.z), Time = Time.time });

		while (pointsInSpace.Count > 0 && pointsInSpace.Peek().Time <= Time.time - delay + Mathf.Epsilon)
		{
			flashLight.transform.localRotation = Quaternion.Lerp(flashLight.transform.localRotation, pointsInSpace.Dequeue().rotation, Time.deltaTime * speed);
		}
	}
}