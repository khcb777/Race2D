using UnityEngine;
using UnityEngine.SceneManagement;


public class Links : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
