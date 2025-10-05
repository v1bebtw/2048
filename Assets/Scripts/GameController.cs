using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject fillPrefab;
    [SerializeField] private Transform[] allCells;
    
    private void Start()
    {
        SpawnFill();
        SpawnFill();
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFill();
        }
    }*/
    
    public void SpawnFill()
    {
        int whichSpawn = Random.Range(0, allCells.Length);
        if (allCells[whichSpawn].childCount != 0)
        {
            Debug.Log("Already filled");
            SpawnFill();
            return;
        }
        float chance = Random.Range(0f, 1f);
        if (chance < 0.8f)
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);
            Fill tempFillValue = tempFill.GetComponent<Fill>();
            tempFillValue.FillValueUpdate(2);
        }
        else
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);
            Fill tempFillValue = tempFill.GetComponent<Fill>();
            tempFillValue.FillValueUpdate(4);
        }
    }
}
