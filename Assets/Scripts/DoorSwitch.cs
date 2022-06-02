using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : Interactable
{
    public override void OnInteraction()
    {
        base.OnInteraction();

        Debug.Log("Intentando abrir...");

        if (Inventory.HasKey("USB"))
        {
            Debug.Log("Puerta abierta");
            GetComponent<Animator>().SetBool("Open", true);
            
        }
        else  Debug.Log("Acceso denegado");
    }
}
