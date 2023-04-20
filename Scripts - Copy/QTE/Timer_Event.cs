using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Event : MonoBehaviour
{
    public Slider SliderPrefab;
    public Image GoodzoneUI;
    public Image KeytoShow;

    public float Goodzone;

    private float StartGoodzone = 2.1f;
    private float EndGoodzone = 2.95f;

    [Range(0, 10)]
    public float TimerDefault;

    private float Timer;
    private bool TimerRunning;

   

    public void StartTimer()
    {
        SliderPrefab.value = 0;

        TimerRunning = true;
        Timer = TimerDefault;

        KeytoShow.gameObject.SetActive(true);
        SliderPrefab.gameObject.SetActive(true);
        GoodzoneUI.gameObject.SetActive(true);



    }

    void RunTimer()
    {
        if (SliderPrefab.value >= SliderPrefab.minValue)
        {
            SliderPrefab.value += Time.deltaTime;
        }

        else
        {
            Debug.Log("QTE is Done");
        }

    }

    void EndOfTimer()
    { //works well
        if (SliderPrefab.value >= SliderPrefab.maxValue)
        {
            TimerRunning = false;
            SliderPrefab.gameObject.SetActive(false);
            GoodzoneUI.gameObject.SetActive(false);
            KeytoShow.gameObject.SetActive(false);
        }

    }

   

    void SkillCheck()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (SliderPrefab.value >= StartGoodzone && SliderPrefab.value <= EndGoodzone)
            {

                Debug.Log("good job!!!");
                Goodzone = 1;

                //doesn't make slider dissapear for some
                //reason, fix this
                StopSlider();

            }
            else
            {
                Debug.Log("failed");
                Goodzone = 0;

                //doesn't make slider dissapear for soem reason, fix this
                StopSlider();
            }

        }
    }

    void StopSlider()
    {

        //if(SliderPrefab.value >=StartGoodzone && SliderPrefab.value <= EndGoodzone, += Time.deltaTime);
        TimerRunning = false;
        SliderPrefab.gameObject.SetActive(false);
        GoodzoneUI.gameObject.SetActive(false);
        KeytoShow.gameObject.SetActive(false);






    }


    void Update()
    {
        if (TimerRunning)
        {
            RunTimer();
            SkillCheck();
            EndOfTimer();
        }






    }
}
