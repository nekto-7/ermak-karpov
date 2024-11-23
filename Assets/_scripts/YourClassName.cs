using UnityEngine;
using UnityEngine.SceneManagement;

public class YourClassName : MonoBehaviour
{

    void Start()
    {
        // При старте курсор будет невидимым и заблокированным
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
