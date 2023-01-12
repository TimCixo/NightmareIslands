using UnityEngine;

public class Rotator : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(0, Random.Range(0, 4) * 90 ,0);
    }
}
