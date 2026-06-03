using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void OnClicked(string value){
        SceneManager.LoadScene(value);
    }
}
