using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class pickAndDrop : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject DropFirstText;
    public GameObject item;
    public Transform itemParent;
    private bool equipped;
    private bool canInteract; // New boolean variable to track if the player can interact with the trigger

    // Start is called before the first frame update
    void Start()
    {
        item.GetComponent<Rigidbody>().isKinematic = true;
        PickUpText.SetActive(false);
        DropFirstText.SetActive(false);
        equipped = false;
        canInteract = false; // Initialize canInteract to false
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }

        if (canInteract && Input.GetKeyDown(KeyCode.E)) // Check if the player can interact and handle input in Update
        {
            Debug.Log("pressed e");
            Equip();
            PickUpText.SetActive(false);
            canInteract = false; // Prevent further interactions until the player leaves the trigger area
        }
    }

    void Drop()
    {
        itemParent.DetachChildren();
        item.transform.eulerAngles = new Vector3(item.transform.position.x, item.transform.position.z, item.transform.position.y);
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<MeshCollider>().enabled = true;
    }

    // to use with drop item before picking up next item
    private IEnumerator DisplayDropFirstText()
    {
        DropFirstText.SetActive(true);
        yield return new WaitForSeconds(1f); // Wait for 1 second
        DropFirstText.SetActive(false);
    }

    void Equip()
    {
        if (itemParent.childCount == 0)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.position = itemParent.transform.position;
            item.transform.rotation = itemParent.transform.rotation;
            item.GetComponent<MeshCollider>().enabled = false;
            item.transform.SetParent(itemParent);
            DropFirstText.SetActive(false);
            Debug.Log("call1");
        }
        else
        {
            Debug.Log("call2");
            StartCoroutine(DisplayDropFirstText());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
            canInteract = true; // Set canInteract to true when the player enters the trigger area
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // to make sure the text disappears when I walk away
        PickUpText.SetActive(false);
        canInteract = false; // Reset canInteract to false when the player leaves the trigger area
    }
}