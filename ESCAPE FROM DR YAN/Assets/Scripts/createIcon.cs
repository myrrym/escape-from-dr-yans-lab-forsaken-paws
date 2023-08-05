
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class createIcon : MonoBehaviour
{
    // Prefix: This is the prefix for the generated icon file name.
    public string prefix = "ItemIcon_";

    // Path: This is the relative path where the generated icons will be saved.
    public string path = "Assets/Icons/";

    // The item's unique ID or name (you can change this based on your item system)
    public string itemID;

    // Cache the Renderer component during Start
    private Camera itemRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Cache the Renderer component for later use
        itemRenderer = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Takes a screenshot and saves it with the specified file name
    [ContextMenu("Take Item Icon Screenshot")]
    public void TakeItemIconScreenshot()
    {
        if (itemRenderer == null)
        {
            itemRenderer = GetComponent<Camera>();
        }

        // Ensure the itemRenderer is enabled before taking the screenshot
        itemRenderer.enabled = true;

        RenderTexture rt = new RenderTexture(256, 256, 24);
        Camera cam = Camera.main; // You can use a specific camera for screenshot if needed
        cam.targetTexture = rt;
        Texture2D screenShot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        cam.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        cam.targetTexture = null;
        RenderTexture.active = null;

        // Disable the itemRenderer again after taking the screenshot
        itemRenderer.enabled = false;

        if (Application.isEditor)
        {
            DestroyImmediate(rt);
        }
        else
        {
            Destroy(rt);
        }

        // Check if the file already exists
        string fullPath = path + prefix + itemID + ".png";
        int count = 1;
        while (System.IO.File.Exists(fullPath))
        {
            fullPath = path + prefix + itemID + "_" + count + ".png";
            count++;
        }

        byte[] bytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fullPath, bytes);

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
