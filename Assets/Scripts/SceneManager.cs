using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private string nextScene;
    [SerializeField] Animator trans;
    
    public void InstantLoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }
    
    public void InstantLoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    
    public void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        trans.SetTrigger("Out");
    }
}
