using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Bubble : MonoBehaviour
{
    public int Strength = 1;
    public float AliveTime = 3.0f;
    public bool IsNaturallyExplode = false;
    private Collider m_collider;
    public delegate void CallBack();
    public CallBack callBack;
    private void Start()
    {
        m_collider = GetComponent<SphereCollider>();
        StartCoroutine("ExplodeNaturally");
    }
    private void Update()
    {
        Debug.DrawLine(transform.position, transform.position+new Vector3(Strength, 0,0), Color.red);
        Debug.DrawLine(transform.position, transform.position+new Vector3(-Strength, 0,0), Color.red);
        Debug.DrawLine(transform.position, transform.position+new Vector3(0,0, Strength), Color.red);
        Debug.DrawLine(transform.position, transform.position+new Vector3(0,0,-Strength), Color.red);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            m_collider.isTrigger = false;
        }
    }

    internal void Explode()
    {
        RaycastHit[] hits = new RaycastHit[4];
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Strength); hits[0] = hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Strength); hits[1] = hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Strength); hits[2] = hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, Strength); hits[3] = hit;
        foreach (RaycastHit hitItem in hits)
        {
            if (hitItem.collider != null)
            {
                switch (hitItem.collider.tag) {
                    case "Destructible":
                        hitItem.collider.gameObject.GetComponent<Destructible>().Explode();
                        break;
                    case "Bubble":
                        Bubble otherBubble = hitItem.collider.GetComponent<Bubble>();
                        if (otherBubble.IsNaturallyExplode) break;
                        otherBubble.Explode();
                        break;
                    default:break;
                 }
                    
            }
        }
        callBack();
        Destroy(this.gameObject);
    }
    IEnumerator ExplodeNaturally()
    {
        yield return new WaitForSeconds(AliveTime);
        IsNaturallyExplode = true;
        Explode();
    }
}
