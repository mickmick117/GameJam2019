using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{

	public List<Light> lights;
	public Light light;

	public Transform target;
	public Transform character;
	public CanvasGroup canvas;
	public Image panel;
	public float FadeDuration = 1.5f;

	private float initialDistance = 0;
	public float newDistance = 0;

	private bool isEntered = false;
	private bool isFinished = false;
	private const float marge = 3;

	private float iniIntensity;
	private float iniRange;
	public float multiplier = 25;
	private bool changeScene = false;
	public Text text;

	private void Start()
	{
		initialDistance = Vector3.Distance(character.position, target.position);

		iniIntensity = light.intensity;
		iniRange = light.range;
	}

	void Update()
    {
		if (isEntered && !isFinished )
		{
			ChangeLight();
		}
    }

	private void ChangeLight()
	{
		 newDistance = Vector3.Distance(character.position, target.position);
		light.intensity = iniIntensity + (initialDistance - newDistance) / (initialDistance - marge) * multiplier;
		light.range = iniRange + (initialDistance - newDistance) / (initialDistance - marge) * multiplier*3;

		if (newDistance < marge)
		{
			isFinished = true;
			StartCoroutine(FinishGame());
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		isEntered = true;
	}

	IEnumerator FinishGame ()
	{
		StartCoroutine(LoadScene(0));
		yield return StartCoroutine(FadeOut());
		yield return StartCoroutine(PlayText());
		changeScene = true;
	}

	IEnumerator FadeOut()
	{
		while (panel.color.a < 1)
		{
			//canvas.alpha += Time.deltaTime / FadeDuration;
			panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + Time.deltaTime / FadeDuration);
			yield return null;
		}
		
	}

	IEnumerator PlayText()
	{
		//text.color = Color.black;
		text.text = "Before, I felt trapped. Jack's death bestowed darkness upon me.";
		yield return new WaitForSeconds(4f);
		text.text = "In reminiscence, we're finally together.";
		yield return new WaitForSeconds(3f);
		text.text = "He's my home and he means everything to me.";
		yield return new WaitForSeconds(3f);
	}

	IEnumerator LoadScene(int sceneLevel)
	{
		yield return null;

		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneLevel);
		asyncOperation.allowSceneActivation = false;

		while (!asyncOperation.isDone)
		{
			if (asyncOperation.progress >= 0.9f)
			{
				if (changeScene == true)
					asyncOperation.allowSceneActivation = true;
			}

			yield return null;
		}
	}
}
