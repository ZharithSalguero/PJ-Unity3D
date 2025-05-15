using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryBar : MonoBehaviour
{
    public GameObject slotPrefab;   
    public int numberOfSlots = 5;   

    private List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, transform);
            slots.Add(newSlot);
        }
    }
}

