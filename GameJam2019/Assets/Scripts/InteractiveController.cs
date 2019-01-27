using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveController : MonoBehaviour
{
    public GameObject objectToPickup;
    public Text triggerEnterText;
    public string triggerEnterPrompt;
    public Renderer objectRenderer;
    public float outlineValue;
    public Light light;

    public Text StoryTextObj;
    private string StoryText = "Press R to investigate";
    public float TextShowTime = 4f;

    static bool investigateTip = false;
    private bool isPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        TogglePlayerRangePrompt();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            if (TogglePlayerRangePrompt() && Input.GetAxis("Interact") > 0.0f)
            {
                Inventory.instance.addItem(objectToPickup.tag);
                Debug.Log(Inventory.instance.items.Count);
                objectToPickup.SetActive(false);
                TogglePlayerRangePrompt();
                GetComponent<AudioSource>().Play();
                if (light != null)
                {
                    light.gameObject.SetActive(true);
                }
                if (!investigateTip && !CompareTag("Flashlight"))

                {

                    investigateTip = true;

                    StartCoroutine(ShowText());

                }
            }
        }
    }

    public IEnumerator ShowText()

    {

        StoryTextObj.text = StoryText;

        yield return new WaitForSeconds(TextShowTime);

        StoryTextObj.text = "";





    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerInRange = true;
        TogglePlayerRangePrompt();
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInRange = false;
        TogglePlayerRangePrompt();
    }

    private bool TogglePlayerRangePrompt()
    {
        bool isActiveAndInRange = isPlayerInRange && objectToPickup.activeSelf && objectRenderer.isVisible;

        triggerEnterText.text = (isActiveAndInRange) ? triggerEnterPrompt : "";
        objectRenderer.material.SetFloat("_Outline", (isActiveAndInRange) ? outlineValue : 0.0f);

        return isActiveAndInRange;
    }
}

