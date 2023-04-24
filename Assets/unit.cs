using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        unitselections.Instance.unitlist.Add(this.gameObject);
    }

    
    void OnDestroy()
    {
        unitselections.Instance.unitlist.Remove(this.gameObject);
    }
}
