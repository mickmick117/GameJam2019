using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuController : MonoBehaviour
{
    public Image memoryImage;
    public Text memoryDescription;
    public Sprite[] memorySprites;
    public string[] memoryDescriptions;

    // Start is called before the first frame update
    void Start()
    {
        ToggleMemoryImage(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MemoryClicked(int buttonIndex)
    {
        if (buttonIndex < 0)
            return;

        if (buttonIndex < memorySprites.Length)
        {
            ToggleMemoryImage(1.0f);
            memoryImage.sprite = memorySprites[buttonIndex];
        }
        else
        {
            ToggleMemoryImage(0.0f);
        }

        memoryDescription.text = (buttonIndex < memoryDescriptions.Length) ? memoryDescriptions[buttonIndex] : "";
    }

    private void ToggleMemoryImage(float alpha)
    {
        Color tempColor = memoryImage.color;
        tempColor.a = alpha;
        memoryImage.color = tempColor;
    }
}
