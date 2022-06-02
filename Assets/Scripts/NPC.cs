using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField]
    string name;

    [SerializeField]
    string [] dialogs;

    [SerializeField]
    GameObject dialogBoxPanel;

    [SerializeField]
    TMP_Text nameTMP, dialogTMP;
    
    Animator animator;

    bool isNear = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetInteger("state", 1);
            ShowDialogBox();
        }
    }

    //Dialogos secuenciales
    int index = 0;
    void ShowDialogBox()
    {
        if (!isNear)
            return;

        if(index >= dialogs.Length)
        {
            index = 0;
            dialogBoxPanel.SetActive(false);
            return;
        }

        dialogBoxPanel.SetActive(true); 
        nameTMP.text = name;
        dialogTMP.text = dialogs[index];
        index++;
        //Dialogos random
        /*
        int dice = Random.Range(0, dialogs.Length);
        dialogTMP.text = dialogs[dice];*/
    }

    public GameObject GetDialogBox()
    {
        return dialogBoxPanel;
    }

    public void IsNear(bool isNear)
    {
        this.isNear = isNear;
    }
}
