using UnityEngine;

public class Player_Muvoment : MonoBehaviour
{
    public Animator shake;
    public float graviry = -9.8f;
    public float speed = 15.0f;
    public float sprint = 20;
    public float jumpForce = 15;
    public bool CanMove = true;

    private CharacterController cc;
    private bool statusSprint;
    private float jspeed = 0.0f;

    // Добавляем переменную для звука шагов
    public AudioSource footstepAudioSource;
    public AudioClip footstepClip;

    private float footstepInterval = 0.5f; // Интервал между шагами (подстройте по желанию)
    private float nextFootstepTime = 0f;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();

        // Добавляем AudioSource компонент, если его нет
        if (footstepAudioSource == null)
        {
            footstepAudioSource = gameObject.AddComponent<AudioSource>();
            footstepAudioSource.clip = footstepClip;
            footstepAudioSource.loop = false; // Отключаем петлю, так как воспроизводим вручную
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (cc.isGrounded)
        {
            jspeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jspeed = jumpForce;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            statusSprint = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            statusSprint = false;
        }

        if (statusSprint)
        {
            horizontal *= sprint;
            vertical *= sprint;
        }
        else
        {
            horizontal *= speed;
            vertical *= speed;
        }

        if (!CanMove)
        {
            horizontal = 0;
            vertical = 0;
        }

        Func(horizontal, vertical);
        jspeed += graviry * Time.deltaTime * 3f;
        Vector3 dir = new Vector3(horizontal, jspeed, vertical);
        dir *= Time.deltaTime;
        dir = transform.TransformDirection(dir);
        cc.Move(dir);

        // Воспроизведение звука шагов
        HandleFootsteps(horizontal, vertical);
    }

    public void Func(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            shake.SetTrigger("Status");
            shake.enabled = true;
        }
        else
        {
            shake.enabled = false;
        }
    }

    public void setCanMove(bool CM)
    {
        CanMove = CM;
    }

    // Метод для обработки звука шагов
    private void HandleFootsteps(float horizontal, float vertical)
    {
        if ((horizontal != 0 || vertical != 0) && cc.isGrounded)
        {
            if (Time.time >= nextFootstepTime)
            {
                footstepAudioSource.Play(); // Воспроизводим звук
                nextFootstepTime = Time.time + footstepInterval; // Задаём следующий шаг
            }
        }
    }
}
