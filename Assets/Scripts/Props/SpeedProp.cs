using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedProp : Prop
{
    [HideInInspector]
    public Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player") Gain(collider.GetComponent<Player>());
    }
    public override void Gain(Player player)
    {
        player.speed += 3;
        Destroy(gameObject);
    }
}
