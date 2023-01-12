using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
