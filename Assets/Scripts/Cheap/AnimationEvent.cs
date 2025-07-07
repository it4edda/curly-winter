using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] SceneManager sceneMan;
    public void TurnInactive()
    {
        gameObject.SetActive(false);
    }
    public void LoadScene() // don't touch like ever, im looking at you nils !!!
    {
        sceneMan.InstantLoadScene();
    }
}
