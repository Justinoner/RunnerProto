using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public GameObject charModel;
   
    public float moveSpeed = 5;
    public float leftRightSpeed = 4;

    private void Start()
    {
        SetSpeed = moveSpeed;
        SetleftRight = leftRightSpeed;
    }
    public float SetSpeed
    {
        //locks movement speed so it cannot go past 10
        get { return moveSpeed; } //read

        set
        {                    //writable
            if (value > 10)
            {
                moveSpeed = 10;
            }
            else
                moveSpeed = value;



        }
    }
    public float SetleftRight
    {
        //locks left and right speed so it cannot go past 10
        get { return leftRightSpeed; } //read

        set
        {                    //writable
            if (value > 10)
            {
                leftRightSpeed= 10;
            }
            else
                leftRightSpeed = value;



        }
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
       // if (canMove == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(transform.position.y<=.77f)
                //charModel.GetComponent<Animator>().Play("Jump Forward");
                GetComponent<Rigidbody>().AddForce(Vector3.up * 350);
                

            } 
        }
       
    }
}
