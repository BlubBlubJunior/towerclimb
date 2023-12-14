using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class unitmanager : MonoBehaviour
{
    public List<GameObject> unitlist = new List<GameObject>();

    public void Addunit(GameObject unit)
    {
        if (!unitlist.Contains(unit))
        {
            unitlist.Add(unit);

            unit.GetComponent<playerBehever>().enabled = true;
        }
    }
    public void Removeunut(GameObject unit)
    {
        if (unitlist.Contains(unit))
        {
            unitlist.Remove(unit);

            unit.GetComponent<playerBehever>().enabled = false;
        }
    }
}


