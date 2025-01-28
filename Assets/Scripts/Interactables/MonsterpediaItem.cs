using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MonsterpediaItem : MonoBehaviour, IInteractable
{
    [Header("References")]
    public Outline outline;
    public float outlineWidth = 10f;

    [Header("Events")]
    public UnityEvent OnInteract;
    [Space]
    public UnityEvent OnExitMonsterpedia;

    private bool MonsterpediaOpen = false;
    private bool playerLookingAtMe = false;
    public void Interact()
    {
        OnInteract.Invoke();
        Time.timeScale = 0f;
        MonsterpediaOpen = true;
    }

    public void OnSelect()
    {
        outline.enabled = true;
        playerLookingAtMe = true;
    }

    public void OnDeselect()
    {
        outline.enabled = false;
        playerLookingAtMe = false;
    }



    private void Update()
    {
        if (MonsterpediaOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            OnExitMonsterpedia.Invoke();
            Time.timeScale = 1.0f;
            MonsterpediaOpen = false;
        }

        if (!playerLookingAtMe)
        {
            outline.enabled = false;
        }
    }
}
