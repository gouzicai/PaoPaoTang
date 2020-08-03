using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour,IExplosive
{
    public GameObject FractureGO;

    public void Explode()
    {
        GameObject.Instantiate(FractureGO, transform.position, Quaternion.identity);
        int i = UnityEngine.Random.Range(0, 6);
        if (i < PropMgr.PropList.Count)
        {
            GameObject.Instantiate(PropMgr.PropList[i], transform.position, Quaternion.identity);
        }
    }
    private void OnDestroy()
    {
       
    }
}
