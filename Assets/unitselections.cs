using System.Collections.Generic;
using UnityEngine;

public class unitselections : MonoBehaviour
{
    public List<GameObject> unitlist = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    private static unitselections _instance;
    public static unitselections Instance
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
        AddUnitToSelection(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            AddUnitToSelection(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            RemoveUnitFromSelection(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            AddUnitToSelection(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            SetUnitSelectedState(unit, false);
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        unitsSelected.Clear();
    }

    private void AddUnitToSelection(GameObject unit)
    {
        unitsSelected.Add(unit);
        SetUnitSelectedState(unit, true);
    }

    private void RemoveUnitFromSelection(GameObject unit)
    {
        unitsSelected.Remove(unit);
        SetUnitSelectedState(unit, false);
        
    }

    private void SetUnitSelectedState(GameObject unit, bool isSelected)
    {
        playerBehever playerBehavior = unit.GetComponent<playerBehever>();
        if (playerBehavior != null)
        {
            playerBehavior.setSelected(isSelected);
        }
    }

    public void Deselect(GameObject unitToDeselect)
    {
        RemoveUnitFromSelection(unitToDeselect);
    }
}
