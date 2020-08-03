using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMgr
{
    public List<GameObject> BundleList;
    public Dictionary<int, GameObject> BundleDic;

    BubbleMgr(){
        BundleDic.Add(0, BundleList[0]);
    }
}
