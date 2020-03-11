using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [Header("Attack Slots Properties")]
    public List<GameObject> slots;
    public int slotNumber = 6;
    public float distanceBetweenSlots = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //Crée une liste de slots, si ces derniers sont "null", alors ils sont vides.
        slots = new List<GameObject>();
        for (int i = 0; i < slotNumber; ++i)
        {
            slots.Add(null);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Place les slots et stocke leur position leur position...
    public Vector3 GetSlotPosition(int index) 
    {
        float degreesPerIndex = 180 / slotNumber;
        var pos = transform.position;
        var offset = new Vector3(0f, 0f, distanceBetweenSlots);
        return pos + (Quaternion.Euler(new Vector3(0f, degreesPerIndex * index, 0f)) * offset);
    }

    //Un ennemi reserve un slot pour s'y placer
    public int ReserveASlot(GameObject attacker) 
    {
        var bestPosition = transform.position;
        var offset = (attacker.transform.position - bestPosition).normalized * distanceBetweenSlots;
        bestPosition += offset;
        int bestSlot = -1;
        float bestDist = 99999f;
        for (int index = 0; index < slots.Count; ++index)
        {
            if (slots[index] != null)
                continue;
            var dist = (GetSlotPosition(index) - bestPosition).sqrMagnitude;
            if (dist < bestDist)
            {
                bestSlot = index;
                bestDist = dist;
            }
        }
        if (bestSlot != -1)
            slots[bestSlot] = attacker;
        return bestSlot;
    }

    //Un slot devient null et est donc vide
    public void ReleaseASlot(int slot)
    {
        slots[slot] = null;
    }

    //Debug les positions des slots et leur état dans l'editor
    void OnDrawGizmosSelected() 
    {
        for (int index = 0; index < slotNumber; ++index)
        {
            if (slots == null || slots.Count <= index || slots[index] == null)
                Gizmos.color = Color.black;
            else
                Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(GetSlotPosition(index), 0.5f);
        }
    }
}
