using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void TimerEvent();

    public static event TimerEvent TimerStart;

    public static event TimerEvent TimerEnd;

    public bool isRacing = false;
    private float racingTime = 0;

    public void OnEnable()
    {
        TimerStart += StartTimer;
        TimerEnd += EndTimer;
    }

    public void OnDisable()
    {
        TimerStart -= StartTimer;
        TimerEnd -= EndTimer;
    }

    private void StartTimer()
    {
        Debug.Log("Starting Timer.");
        isRacing = true;
    }

    private void EndTimer()
    {
        Debug.Log("Ending Timer. Race time: " + racingTime);
        isRacing = false;
    }

    private void Update()
    {
        if (isRacing)
        {
            racingTime += Time.deltaTime;
        }
    }
    
}
