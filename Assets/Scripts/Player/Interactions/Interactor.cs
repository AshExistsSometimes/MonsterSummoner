using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface IInteractable
{
    public void Interact();

    public void OnSelect();

    public void OnDeselect();
}

public class Interactor : MonoBehaviour
{
    private IInteractable currentlySelected = null;


    public Transform InteractorSource; // Where interactor comes from
    public float InteractRange = 5f;//interactor distance

    private void Update()
    {
        Ray r = (Camera.main.ScreenPointToRay(Input.mousePosition));//raycast made with position and direction of source
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.transform.GetComponent<IInteractable>() != null)// tells us if object is IInteractable
            {
                if (currentlySelected != null)
                {
                    currentlySelected.OnDeselect();
                }

                currentlySelected = hitInfo.transform.GetComponent<IInteractable>();

                if (currentlySelected != null)
                {
                    currentlySelected.OnSelect();
                }
            }

            else
            {
                if (currentlySelected != null)
                {
                    currentlySelected.OnDeselect();
                }

                currentlySelected = null;
            }
        }
        else
        {
            if (currentlySelected != null)
            {
                currentlySelected.OnDeselect();
            }

            currentlySelected = null;
        }

        if (currentlySelected != null && Input.GetKeyDown(KeyCode.E))
        {
            currentlySelected.Interact();
        }
    }
}
