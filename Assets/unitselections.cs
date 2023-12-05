using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class unitselections : MonoBehaviour
{
    public playerBehever Movement; 
        
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

    private void Start()
    {
        
    }

    public void clickselect(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        Movement._isSelected = true;
        playerBehever movement = unitToAdd.GetComponent<playerBehever>();
        if (movement != null)
        {
            movement.setSelected(true);
        }
    }
    
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if(!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add((unitToAdd));
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            playerBehever playerBehavior = unitToAdd.GetComponent<playerBehever>();
            if (playerBehavior != null)
            {
                playerBehavior.setSelected(true);
            }
        }
        else
        {
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitsSelected.Remove(unitToAdd);
            playerBehever playerBehavior = unitToAdd.GetComponent<playerBehever>();
            if (playerBehavior != null)
            {
                playerBehavior.setSelected(false);
            }
            
        }
    }
    
    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            playerBehever playerBehavior = unitToAdd.GetComponent<playerBehever>();
            if (playerBehavior != null)
            {
                playerBehavior.setSelected(true);
            }
        }
    }

    public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            unit.transform.GetChild(0).gameObject.SetActive(false);
            playerBehever playerBehavior = unit.GetComponent<playerBehever>();
            if (playerBehavior != null)
            {
                playerBehavior.setSelected(false);
            }
        }
        unitsSelected.Clear();
    }

    public void Deselect(GameObject unitToDeselect)
    {
        
    }
    
}
