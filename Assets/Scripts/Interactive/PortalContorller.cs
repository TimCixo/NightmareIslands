using UnityEngine.SceneManagement;

using UnityEngine;

public class PortalContorller : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(++index);
    }
}
