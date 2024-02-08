using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTrigger : MonoBehaviour
{
    public int slotNumber;
    public int points;

    void OnTriggerEnter(Collider other){
        Debug.Log($"Entered slot {slotNumber} and got {points} points");
    }
}
