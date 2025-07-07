using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private string nextScene;
    [SerializeField] Animator trans;
    [SerializeField] Animator heaven;
    [SerializeField] GameObject successObj;
    [SerializeField] GameObject failedObj;
    
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

    public void HeavenlyPath(bool loading)
    {
        heaven.gameObject.SetActive(true);
        heaven.SetTrigger(!loading ? "Hide" : "Show");
    }

    private bool success;
    public void SetConnectionStatus(bool success)
    {
        this.success = success;
    }
    public void LoadingToggle()
    {
        successObj.SetActive(success);
        failedObj.SetActive(!success);
    } 
    
}
