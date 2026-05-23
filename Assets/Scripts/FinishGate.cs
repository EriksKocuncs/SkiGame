using UnityEngine;

public class FinishGate : MonoBehaviour
{
    public static event GameManager.TimerEvent TimerEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimerEnd.Invoke();
        }
    }
}
