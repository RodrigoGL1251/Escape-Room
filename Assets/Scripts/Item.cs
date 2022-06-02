using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    [SerializeField]
    protected Sprite sprite;


    public override void OnInteraction()
    {
        base.OnInteraction();
        PickUp();
    }

    void PickUp()
    {
        Inventory.SaveItem(this);
        StartCoroutine("DesactivarObjeto");
    }

    IEnumerator DesactivarObjeto()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(base.audioSwitch.length);

        gameObject.SetActive(false);
    }

    public Sprite GetSpriteItem()
    {
        return sprite;
    }
}
