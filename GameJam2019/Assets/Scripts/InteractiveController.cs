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
            }
        }
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
