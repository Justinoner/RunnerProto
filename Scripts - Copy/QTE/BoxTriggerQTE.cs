using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillCheckTrigger
    //When player enters box trigger it activates the QTE/Skillcheck.
{
    public class BoxTriggerQTE : MonoBehaviour
    {

        [SerializeField]
        private Timer_Event Timerevent;
        private void OnTriggerEnter(Collider Player)
        {
            Timerevent.StartTimer();
        }

    }
}

