using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemContainer : MonoBehaviour
{
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItemImage(Sprite sprite)
    {
        image.sprite = sprite;
        image.enabled = true;
    }
    
    public Image GetImage()
    {
        return image;
    }
}
