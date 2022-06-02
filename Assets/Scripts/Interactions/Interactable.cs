using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    protected GameObject outline;

    [SerializeField]
    protected AudioClip audioLook, audioSwitch;

    protected AudioSource audioSource;

    private void Start()
    {
        outline = gameObject.transform.GetChild(0).gameObject;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public virtual void OnBeingLook(bool state)
    {
        outline.SetActive(state);

        if (state)
        {
            if (audioSource.isPlaying)
                return;

            audioSource.clip = audioLook;
            audioSource.Play();  
        }        
    }
    public virtual  void OnInteraction()
    {
        audioSource.clip = audioSwitch;
        audioSource.Play(); 
    }
}
