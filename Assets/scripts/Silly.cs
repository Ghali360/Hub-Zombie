using UnityEngine;

public class Silly : MonoBehaviour
{
    public GameObject Player;
    public string TriggerName = "Idle";
    public Animator Animation3;
    float Distance = 2f;
    bool IsAnimation = false ;
    bool WasInRange;

    public AudioClip triggerSound;

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 2.5f)]
    public float pitch;

    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animation3 = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

        volume = 0.5f;
        pitch = 1f;

        audioSource.clip = triggerSound;
        audioSource.volume = volume;
        audioSource.pitch = pitch;

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
                Animation3.SetTrigger("Silly");
                IsAnimation = true;
                PlayandPause();
                Debug.Log("anim");

            }
            //Animation3.ResetTrigger("Silly");
            if (IsAnimation)
            {
                AnimatorStateInfo StatInfo = Animation3.GetCurrentAnimatorStateInfo(0);
                if (StatInfo.normalizedTime >= 1f)
                {
                    IsAnimation = false;
                    Debug.Log("pasanim");
                }
            }
        }
        else
        {
            Animation3.ResetTrigger("Silly");
            audioSource.Stop();
            IsAnimation = false;
            Debug.Log("pasanim");
        }
        WasInRange = InRange;
    }
}