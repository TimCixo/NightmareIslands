using UnityEngine;

public class GateContorller : MonoBehaviour, IUsableObject
{
    private GameObject _portal;

    private void Start()
    {
        _portal = transform.Find("Portal").gameObject;
    }

    public void Use(GameObject gameObject)
    {
        _portal.SetActive(true);
    }
}
