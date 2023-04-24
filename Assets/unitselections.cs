using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class unitselections : MonoBehaviour
{
    public List<GameObject> unitlist = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    private static unitselections _instance;
    public  static  unitselections Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
           Destroy(this.gameObject); 
        }
        else
        {
            _instance = this;
        }
    }

    public void clickselect(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<PlayerMovement>().enabled = true;
    }
    
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if(!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add((unitToAdd));
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<PlayerMovement>().enabled = true;
        }
        else
        {
            unitToAdd.GetComponent<PlayerMovement>().enabled = false;
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitsSelected.Remove(unitToAdd);
            
        }
    }
    
    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            unit.GetComponent<PlayerMovement>().enabled = false;
            unit.transform.GetChild(1).gameObject.SetActive(true);
        }
        unitsSelected.Clear();
    }

    public void Deselect(GameObject unitToDeselect)
    {
        
    }
}
