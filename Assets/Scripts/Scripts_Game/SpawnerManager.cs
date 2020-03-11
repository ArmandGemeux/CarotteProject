using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyToInstantiate; // doit devenir un enum pour les différents types de Lapin

    public SlotManager slotManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstantiateAnEnemy()
    {
          GameObject newEnemy = Instantiate(enemyToInstantiate, spawnPoint) as GameObject;
          newEnemy.transform.parent = null;
          newEnemy.transform.localScale = enemyToInstantiate.transform.localScale;
    }
}