using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlterPillars : MonoBehaviour, IInteractable
{
    public PlayerMovement player;


    public Transform ItemHolder;


    public Outline outline;
    public float outlineThickness = 10f;

    [HideInInspector]
    public bool PlayerHasItem = false;

    private bool PillarHasItem = false;
    private bool playerLookingAtMe = false;

    private void Update()
    {
        if (!playerLookingAtMe) { outline.enabled = false; }

        if (player.isHoldingItem)
        {
            PlayerHasItem = true;
        }
        else
        {
            PlayerHasItem = false;
        }
    }


    public void Interact()
    {
        if (PlayerHasItem)
        {
            Debug.Log("PLACED ITEM");
        }
    }

    public void OnSelect()
    {
        if (PlayerHasItem)
        {
            outline.enabled = true;
            playerLookingAtMe = true;
        }
    }

    public void OnDeselect()
    {
        outline.enabled = false;
        playerLookingAtMe = false;
    }
}
