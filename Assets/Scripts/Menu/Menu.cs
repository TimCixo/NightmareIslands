using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private MenuInput _menuInput;

    private void Awake()
    {
        _menuInput = new MenuInput();

        _menuInput.Menu.ToMainMenu.performed += ctx => OnMainMenu();
    }

    public void OnMainMenu()
    {
        Cursor.visible = true;

        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

        Inventory.SetDefault();
        InterfaceController.SetDefault();
    }

    public void ExitGame()
    { 
        Application.Quit();
    }

    private void OnEnable()
    {
        _menuInput.Enable();
    }

    private void OnDisable()
    {
        _menuInput.Disable();
    }
}
