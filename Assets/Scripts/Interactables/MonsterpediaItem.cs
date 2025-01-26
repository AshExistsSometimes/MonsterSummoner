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
    public void Interact()
    {
        OnInteract.Invoke();
        Time.timeScale = 0f;
        MonsterpediaOpen = true;
    }

    public void OnSelect()
    {
        outline.OutlineWidth = outlineWidth;
    }

    public void OnDeselect()
    {
        outline.OutlineWidth = 0;
    }



    private void Update()
    {
        if (MonsterpediaOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            OnExitMonsterpedia.Invoke();
            Time.timeScale = 1.0f;
            MonsterpediaOpen = false;
        }
    }
}
