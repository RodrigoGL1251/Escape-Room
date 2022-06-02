using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    Interactable interactable, lastInteractable;
    bool interactionIsEnable = false;

    [SerializeField]
    GameObject interactionMessage, npcMessage;

    void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2)) //Si hay objeto al alcance
        {
            Debug.DrawLine(ray.origin, hit.point); //Dibuja linea en el editor             
            interactable = hit.transform.gameObject.GetComponent<Interactable>(); //Obtener referencia del objeto
        
            if (!interactable) //Si el objeto no es interactuable salir
            {
                Desactivar();
                return;
            }

            if (lastInteractable)
            {
                if (lastInteractable.gameObject == interactable.gameObject) //Si el objeto anterior y el actual son iguales
                {                    
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        interactable.OnInteraction();
                        Desactivar();
                    }
                    else
                        return;
                }
            }                 
            else
            {
                Activar();               
            }
        }
        else
            Desactivar();
    }

    private void Desactivar()
    {
        interactionMessage.SetActive(false);

        if (lastInteractable)
        {
            lastInteractable.OnBeingLook(false);
            lastInteractable = null;
        }
    }

    void Activar()
    {
        lastInteractable = interactable;
        interactionMessage.SetActive(true);
        interactable.OnBeingLook(true);
    }


    //Codigo para el NPC
    NPC currentNPC;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            currentNPC = other.GetComponent<NPC>();
            npcMessage.SetActive(true);
            currentNPC.IsNear(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            npcMessage.SetActive(false);
            currentNPC.GetDialogBox().SetActive(false);
            currentNPC.IsNear(false);
            currentNPC = null;
        }
    }
}