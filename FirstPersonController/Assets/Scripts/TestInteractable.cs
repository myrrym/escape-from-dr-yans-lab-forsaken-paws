using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interactable
{
    public override void OnFocus()
    {
        print("Looking AT " + gameObject.name);
    }

    public override void OnInteract()
    {
        print("INTERACTED AT " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("STOPPED Looking AT " + gameObject.name);
    }
}
