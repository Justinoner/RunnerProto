using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour , IKillable
{
    
    public GameObject thePlayer;
    public GameObject charModel;

   

    

    public void Kill()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
       
    }
    public void OnTriggerEnter(Collider other)
    {

        Kill();
        
        Quit();
        
    }
    
    void Quit()
    {

        

    Application.Quit();

    }
}
