using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{

	public List<Light> lights;
	public Light light;

	public Transform target;
	public Transform character;
	public Color finalLightsColor;
	private Color initialLightsColor;
	private float initialDistance = 0;
	public float newDistance = 0;

	private bool isEntered = false;
	private bool isFinished = false;
	private const float marge = 3;

	private float iniIntensity;
	private float iniRange;
	public float multiplier = 25;

	private void Start()
	{
		initialDistance = Vector3.Distance(character.position, target.position);
		initialLightsColor = lights[0].color;

		iniIntensity = light.intensity;
		iniRange = light.range;
	}

	void Update()
    {
		if (isEntered )
		{
			ChangeLight();
		}

		if (isFinished)
		{

		}
    }

	private void ChangeLight()
	{
		 newDistance = Vector3.Distance(character.position, target.position);

		/*for (int i = 0; i < lights.Count; i++)
		{
			lights[i].color = Color.Lerp(finalLightsColor, initialLightsColor, newDistance / (initialDistance-marge));
			lights[i].intensity = (initialDistance - newDistance) / (initialDistance - marge) * 100;
		}*/

		light.intensity = iniIntensity + (initialDistance - newDistance) / (initialDistance - marge) * multiplier;
		light.range = iniRange + (initialDistance - newDistance) / (initialDistance - marge) * multiplier;

		if (newDistance < marge)
		{
			isFinished = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		isEntered = true;
	}
}
