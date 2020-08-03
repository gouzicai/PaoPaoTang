using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefab, new Vector3(0, 1, 0), Quaternion.Euler(180, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
