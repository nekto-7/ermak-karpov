using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Door : MonoBehaviour
{
    public Animator doorAnimator;
    public ItemPickup itemPickup;
    public int index;
    private bool isDoorOpen = false;       // Флаг состояния двери
    // при входе в тригер автоматом проверка на открытие
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDoorOpen)
        {
            TryOpenDoor();
        }
    }
    // попытка открыть дверь
    private void TryOpenDoor()
    {
        if (itemPickup.hasKey)
        {
            StartCoroutine(OpenDoor());
        }
        else
        {
            Debug.LogWarning("У игрока нет ключа!");
        }
    }
    // открываем дверь
    private IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);        
        // логика выйграша
    }
}
