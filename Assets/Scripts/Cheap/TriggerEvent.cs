using UnityEngine;


public class TriggerEvent : MonoBehaviour
{
    [SerializeField] Animator targetAnimator;
    
        public void TriggerAnimation(string triggerName)
        {
            if (targetAnimator != null)
            {
                targetAnimator.SetTrigger(triggerName);
            }
        }
}