using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateCharacters : MonoBehaviour
{
    //public List<GameObject> prefablist = new List<GameObject>();
    public GameObject prefab;
    
    
    public void characterspawn()
    {
        
        Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
    }
}
