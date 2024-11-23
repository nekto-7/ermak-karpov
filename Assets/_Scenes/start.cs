using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public int index; // Индекс сцены для загрузки

    void Start()
    {
        // При старте курсор будет видимым и разблокированным
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void battonSSS()
    {
        SceneManager.LoadScene(index); // Загрузка сцены

    }
}