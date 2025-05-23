using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ObjectGrabber : MonoBehaviour
{
    public float grabDistance = 3f;
    public Transform holdPoint;
    public LayerMask grabbableLayer; // Capa "Grabbable"
    public TMP_Text interactionText;
    public TMP_Text inventoryText;
    public Transform pivot;
    public float rotationSpeed = 100f; // Nueva variable para ajustar la rotación

    private Rigidbody grabbedObject;
    private GameObject objectToPick;
    private List<string> inventory = new List<string>();

    void Update()
    {
        RaycastForObject();

        if (objectToPick != null && grabbedObject == null)
        {
            interactionText.text = "Presiona [E] para coger el objeto";

            if (Input.GetKeyDown(KeyCode.E))
            {
                GrabObject();
            }
        }
        else if (grabbedObject != null)
        {
            interactionText.text = "Presiona [ESC] para guardar en inventario";
            MoveObject();

            // Nueva funcionalidad: rotar con R mientras se sostiene
            if (Input.GetKey(KeyCode.R))
            {
                grabbedObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StoreObjectInInventory();
            }
        }
        else
        {
            interactionText.text = "";
        }
    }

    void RaycastForObject()
    {
        Ray ray = new Ray(pivot.position, pivot.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, grabDistance, grabbableLayer))
        {
            objectToPick = hit.collider.gameObject;
        }
        else
        {
            objectToPick = null;
        }
    }

    void GrabObject()
    {
        if (objectToPick != null)
        {
            grabbedObject = objectToPick.GetComponent<Rigidbody>();
            if (grabbedObject != null)
            {
                grabbedObject.useGravity = false;
                grabbedObject.freezeRotation = true;
            }
        }
    }

    void MoveObject()
    {
        Vector3 direction = (holdPoint.position - grabbedObject.position);
        grabbedObject.linearVelocity = direction * 10f;
    }

    void StoreObjectInInventory()
    {
        if (grabbedObject != null)
        {
            inventory.Add(grabbedObject.name);
            grabbedObject.gameObject.SetActive(false);
            UpdateInventoryText();
            Debug.Log("Objeto guardado en el inventario: " + grabbedObject.name);
            grabbedObject = null;
        }
    }

    void UpdateInventoryText()
    {
        inventoryText.text = "Inventario:\n";
        foreach (string itemName in inventory)
        {
            inventoryText.text += "- " + itemName + "\n";
        }
    }
}
