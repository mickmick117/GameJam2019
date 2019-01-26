using UnityEngine;
using UnityEngine.UI;

public class InteractiveController : MonoBehaviour
{
    public GameObject objectToPickup;
    public int keyID;
    public Text triggerEnterText;
    public string triggerEnterPrompt;

    private bool isPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        TogglePlayerRangePrompt(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetAxis("Interact") > 0.0f)
        {
            objectToPickup.SetActive(false);
            TogglePlayerRangePrompt(false);
            Inventory.instance.addKey(keyID);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TogglePlayerRangePrompt(true);
    }

    private void OnTriggerExit(Collider other)
    {
        TogglePlayerRangePrompt(false);
    }

    private void TogglePlayerRangePrompt(bool isInRange)
    {
        triggerEnterText.text = (isInRange && objectToPickup.activeSelf) ? triggerEnterPrompt : "";
        isPlayerInRange = isInRange;
    }
}
