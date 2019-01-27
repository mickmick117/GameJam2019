using UnityEngine;
using UnityEngine.UI;

public class InteractiveChest : MonoBehaviour
{
    public GameObject chestToOpen;
    public Text triggerEnterText;
    public string triggerEnterPrompt;
    public string triggerCantEnterPrompt;
    public Renderer objectRenderer;

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
                chestToOpen.SetActive(false);
                TogglePlayerRangePrompt();
                GameManager.instance.OpenFinalRoom();
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
        bool isActiveAndInRange = isPlayerInRange && chestToOpen.activeSelf && objectRenderer.isVisible && Inventory.instance.items.Count == 6;
        if(isPlayerInRange && chestToOpen.activeSelf && objectRenderer.isVisible && Inventory.instance.items.Count == 6)
        {
            triggerEnterText.text = triggerEnterPrompt;
        }
        else if(isPlayerInRange && chestToOpen.activeSelf && objectRenderer.isVisible && Inventory.instance.items.Count != 6)
        {
            triggerEnterText.text = triggerCantEnterPrompt;
        }
        else
        {
            triggerEnterText.text = "";
        }

        return isActiveAndInRange;
    }
}
