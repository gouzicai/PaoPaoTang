using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        //DoRay();
        DoDivision();
    }
    public void DoDivision()
    {
        float x = 12.1f / 1;
        Debug.Log((int)x);
        Debug.Log(x%1);
    }
    public void DoRay()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1.0f);
        Debug.Log(hit.collider);
    }
}
