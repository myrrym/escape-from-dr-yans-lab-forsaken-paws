using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AN

public class FlickerControl : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isFlickering = false;
    public float timeDelay;

    // Update is called once per frame
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.4f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
