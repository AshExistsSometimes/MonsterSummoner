using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickupController : MonoBehaviour, IInteractable
{
    [Header("References")]
    public HoldableItem itemScript;
    public Rigidbody rb;
    public BoxCollider collider;
    public Transform Player, Socket, PlayerCam;
    public Outline outline;
    public float outlineWidth = 10f;

    [Header("Values")]
    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;
    [Space]
    public bool equipped;
    public static bool handsFull;

    //////////////

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        BoxCollider collider = rb.GetComponent<BoxCollider>();

        if (!equipped)
        {
            itemScript.enabled = false;
            rb.isKinematic = false;
            collider.isTrigger = false;
        }
        if (equipped)
        {
            itemScript.enabled = true;
            rb.isKinematic = true;
            collider.isTrigger = true;
            handsFull = true;
        }
    }

    public void Interact()
    {
        if (!equipped && !handsFull)
        {
            PickUp();
        }
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
        if(equipped)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
            collider.enabled = false;
        }
        
        // Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = Player.position - transform.position;
        

        // Drop held item when "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            DropHeldItem();
        }

        if (distanceToPlayer.magnitude <= pickUpRange)
        {
            outline.enabled = true;
        }
        else
        {
            outline.enabled = false;
        }
    }

    private void PickUp()
    {
        Debug.Log("ITEM PICKED UP");
        equipped = true;
        handsFull = true;

        // Put Item in Socket
        transform.SetParent(Socket);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        //transform.localScale = Vector3.one;

        rb.isKinematic = true;
        rb.useGravity = false;
        collider.enabled = false;

        // Enable Item Script
        itemScript.enabled = true;
    }

    private void DropHeldItem()
    {
        equipped = false;
        handsFull = false;

        // Remove Item from Socket
        transform.SetParent(null);

        rb.isKinematic = false;
        rb.useGravity = true;
        collider.enabled = true;
        collider.isTrigger = false;

        // Item carries momentum of player
        rb.velocity = Player.GetComponent<Rigidbody>().velocity;

        // Add Force
        rb.AddForce(PlayerCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(PlayerCam.up * dropUpwardForce, ForceMode.Impulse);
        // Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10f);

        // Disable Item Script
        itemScript.enabled = false;
    }
}
