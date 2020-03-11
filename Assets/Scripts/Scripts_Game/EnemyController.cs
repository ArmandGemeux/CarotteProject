using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //public GameObject gameObjectToLookAt = null;
    private GameObject target = null;

    private float pathTime = 0f;
    private int slot = -1;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Carrot");
        //gameObjectToLookAt = GameObject.Find("Carrot");
    }

    // Update is called once per frame
    void Update()
    {
        //Vérifie la présence d'un slot libre toutes les 0.5 secondes...
        pathTime += Time.deltaTime;
        if (pathTime > 0.5f)
        {
            pathTime = 0;
            var slotManager = target.GetComponent<SlotManager>();
            if (slotManager != null)
            {
                if (slot == -1)
                    //... si un slot est libre, le réserve...
                    slot = slotManager.ReserveASlot(gameObject);
                if (slot == -1)
                    //... si un slot est encore libre, ne fait rien.
                    return;
                var agent = GetComponent<NavMeshAgent>();
                if (agent == null)
                    return;
                agent.destination = slotManager.GetSlotPosition(slot);
            }
        }
        transform.LookAt(target.transform);
    }
}