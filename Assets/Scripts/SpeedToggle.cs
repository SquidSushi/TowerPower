using UnityEngine;

public class SpeedToggle : MonoBehaviour
{
    public void OnToggle(bool value){
        Time.timeScale = value ? 3 : 1;
    }
}
