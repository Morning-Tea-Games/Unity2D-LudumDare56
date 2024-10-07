using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenu;

    private void Awake()
    {
        Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseMenu.activeSelf)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }

    public void Show()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Hide()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
