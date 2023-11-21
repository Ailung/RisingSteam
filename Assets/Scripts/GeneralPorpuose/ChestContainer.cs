using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ChestContainer : MonoBehaviour
{
    private Animator animator;
    private bool InChestRad;
    public bool InsideChestRaius()
    {
        return InChestRad;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InChestRad = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InChestRad = false;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InChestRad && Input.GetButtonDown("Interact"))
        {
            animator.SetTrigger("isOpening"); ;
        }
        
    }
}