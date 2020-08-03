using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.CreatePlayer(User.playerId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
