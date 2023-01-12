using UnityEngine;

public class AppleController : MonoBehaviour, IUsableObject
{
    public void Use(GameObject gameObject)
    {
        Destroy(this.gameObject);

        gameObject.GetComponent<InterfaceController>().TakeHeal(20);
    }
}
