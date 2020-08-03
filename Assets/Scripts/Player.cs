using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerId;
    public float speed;
    public int Strength = 1;
    public int BubbleCanUseAmount = 1;
    public int BubbleUsedAmount;
    public Bubble bubble;
    private Rigidbody m_rigidbody;
    public int PlayerId = 0;
    private Animator m_animator;
    private InputDirection inputDirection;
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
    }
    //private void Update()
    //{
    //    //ChangeDirection();
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (BubbleUsedAmount < BubbleCanUseAmount) CreateBubble();
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    switch (inputDirection) {
    //        case InputDirection.Left:
    //            m_rigidbody.rotation = Quaternion.Euler(Vector3.up * 270);
    //            break;         
    //        case InputDirection.Right:
    //            m_rigidbody.rotation = Quaternion.Euler(Vector3.up * 90);
    //            break;         
    //        case InputDirection.Up:
    //            m_rigidbody.rotation = Quaternion.Euler(Vector3.up * 0);
    //            break;         
    //        case InputDirection.Bottom:
    //            m_rigidbody.rotation = Quaternion.Euler(Vector3.up * 180);
    //            break;
    //    }
    //    Move();
    //}
    //public void Move()
    //{
    //    if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
    //        m_animator.SetBool("IsRun", true);
    //    else m_animator.SetBool("IsRun", false);
    //    m_rigidbody.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime));
    //}

    //public void ChangeDirection(int player_id,string keyName)
    //{
    //    if(player_id == PlayerId)
    //    {
    //        switch (keyName) {
    //            case "A":
    //                inputDirection = InputDirection.Left;
    //                break;                
    //            case "D":
    //                inputDirection = InputDirection.Right;
    //                break;                
    //            case "W":
    //                inputDirection = InputDirection.Up;
    //                break;                
    //            case "S":
    //                inputDirection = InputDirection.Bottom;
    //                break;
    //        }

    //    }
    //}

    //public void ChangeDirection()
    //{
    //    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    //        inputDirection = InputDirection.Left;
    //    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
    //        inputDirection = InputDirection.Right;
    //    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
    //        inputDirection = InputDirection.Up;
    //    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
    //        inputDirection = InputDirection.Bottom;
    //}

    public void CreateBubble()
    {
        Bubble myBubble = GameObject.Instantiate(bubble, new Vector3(Mathf.Round(transform.position.x),0.5f, Mathf.Round(transform.position.z)), Quaternion.identity);
        myBubble.Strength = Strength;
        myBubble.callBack += () => { BubbleUsedAmount--; };
        BubbleUsedAmount++;
    }

    private void OnDestroy()
    {
    }

    public enum InputDirection {
        Up,
        Right,
        Bottom,
        Left
    }
}
