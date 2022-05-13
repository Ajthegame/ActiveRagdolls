using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Rigidbody TransformToMove;
    public float ConstantForce;
    public Rigidbody[] LowerLeft;
    public Rigidbody[] LowerRight;
    static PartToMove CurrentActivePart=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow");
            LowerLeft[1].AddForce(transform.forward * ConstantForce * Time.deltaTime,ForceMode.Acceleration);
            //LowerLeft[1].AddForce(transform.up * ConstantForce * Time.deltaTime,ForceMode.Acceleration);
            //LowerRight[1].AddForce(transform.forward * ConstantForce * Time.deltaTime);
            //MovePlayer((PartToMove)((int)CurrentActivePart)+1%2);
        }
    }

    void MovePlayer(PartToMove moveThisPart)
    {
        float tempForce;
        TransformToMove.AddForce(transform.forward * ConstantForce * Time.deltaTime,ForceMode.Acceleration);
        switch (moveThisPart)
        {
            case PartToMove.Left:
                tempForce = ConstantForce;
                foreach (Rigidbody rb in LowerLeft)
                {
                    rb.AddForce(transform.forward * tempForce * Time.deltaTime, ForceMode.Acceleration);
                    tempForce = tempForce / 2f;
                    Debug.Log(rb.name);
                }
                break;

            case PartToMove.Right:
                tempForce = ConstantForce;
                foreach (Rigidbody rb in LowerRight)
                {
                    rb.AddForce(transform.forward * tempForce * Time.deltaTime, ForceMode.Acceleration);
                    tempForce = tempForce / 2f;
                    Debug.Log(rb.name);
                }
                break;

        }

    }
}

enum PartToMove
{
    Left=0,
    Right
}
