using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnPlayButtonDown()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
