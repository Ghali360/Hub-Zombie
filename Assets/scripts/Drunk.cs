using UnityEngine;
using UnityEngine.UIElements;

public class Drunk : MonoBehaviour
{
    public GameObject Player;
    public string TriggerName = "Idle";
    public Animator Animation1;
    [SerializeField] float Distance;
    bool IsAnimation;
    bool WasInRange;

    public AudioClip triggerSound;

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 2.5f)]
    public float pitch;

    public AudioSource audioSource;

    [Header("Billboard Settings")]
    public GameObject BillBoard;

    public GameObject fxGameObject;
    private void Awake()
    {
        audioSource.playOnAwake = false;
    }
    void Start()
    {
        Animation1 = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

        volume = 0.5f;
        pitch = 1f;

        audioSource.clip = triggerSound;
        audioSource.volume = volume;
        audioSource.pitch = pitch;

        BillBoard.SetActive(false);
        fxGameObject.SetActive(false);

        //Animation1.SetTrigger("Idle");
    }
    void PlayandPause()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        bool InRange = distance < Distance;
        if (InRange)
        {
            if (!WasInRange && !IsAnimation)
            {
                Animation1.SetTrigger("drunk");
                IsAnimation = true;
                PlayandPause();
                Debug.Log("anim");
                BillBoard.SetActive(true);
                fxGameObject.SetActive(true);
            }
            //Animation1.ResetTrigger("Silly");
            if (IsAnimation)
            {
                AnimatorStateInfo StatInfo = Animation1.GetCurrentAnimatorStateInfo(0);
                if (StatInfo.normalizedTime >= 1f)
                {
                    IsAnimation = false;
                    Debug.Log("pasanim");
                }
            }
        }
        if (!InRange && WasInRange)
        {
            Animation1.Rebind();
            //Animation1.SetTrigger("Idle");
            audioSource.Stop();
            IsAnimation = false;
            Debug.Log("pasanim");
            BillBoard.SetActive(false);
            fxGameObject.SetActive(false);
        }
        WasInRange = InRange;
    }
}
