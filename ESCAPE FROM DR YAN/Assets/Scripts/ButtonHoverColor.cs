using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverColor : MonoBehaviour
{
    // Define the normal color and hover color for the buttons
    public Color normalColor = Color.white;
    public Color hoverColor = Color.green;

    // Reference to the button's Image component
    private Image buttonImage;

    private void Start()
    {
        // Get the Image component of the button
        buttonImage = GetComponent<Image>();

        // Set the initial color to normalColor
        buttonImage.color = normalColor;
    }

    public void OnPointerEnter()
    {
        // Called when the mouse pointer enters the button
        buttonImage.color = hoverColor;
    }

    public void OnPointerExit()
    {
        // Called when the mouse pointer exits the button
        buttonImage.color = normalColor;
    }
}