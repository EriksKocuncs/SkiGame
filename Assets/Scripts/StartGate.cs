using UnityEngine;

public class StartGate : MonoBehaviour
{
   public static event GameManager.TimerEvent TimerStart;
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         TimerStart.Invoke();
      }
   }
}
