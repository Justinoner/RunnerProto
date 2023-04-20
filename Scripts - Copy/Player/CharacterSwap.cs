using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSwap : MonoBehaviour
{
    
    public Transform character;
    public List<Transform> possibleCharacters;
    public int whichCharacter;

    public Transform Cam;
    public Transform Camtarget;
    public Vector3 offset;

    private QTESys qte;

    private Timer_Event TimerEvent;



    void Start()
    {
        //qte = FindObjectOfType<QTESys>();
        TimerEvent = FindObjectOfType<Timer_Event>();

        if (character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }
        Swap();
    }

    
    void Update()
    {
        Camtarget = character;
        Cam.position = Camtarget.position + offset;

        if (Input.GetKeyDown(KeyCode.Mouse1) && TimerEvent.Goodzone == 1)
            //goodzone works but it gets the game stuck every time it is succesful, this will have to be examined. If all else fails just set it back to qte for swap or something.
            
            // if(qte.CorrectKey ==1)
        {
            if(whichCharacter == 0)
            {
                whichCharacter = possibleCharacters.Count - 1;
            }
            else
            {
                whichCharacter -= 1;
            }
            Swap();


        }
        
        
    }
    public void Swap()
    {
        character = possibleCharacters[whichCharacter];
        
        character.GetComponent<PlayerMove>().enabled = true;
        


        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if(possibleCharacters[i] != character)
            {
                
                possibleCharacters[i].GetComponent<PlayerMove>().enabled = false;
                TimerEvent.Goodzone = 0;
                
            }
        }
    }
}
