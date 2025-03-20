using UnityEngine;

public class Silly : MonoBehaviour
{
    public GameObject Player;
    public string TriggerName = "Idle";
    public Animator Animation3;
    float Distance = 2f;
    bool IsAnimation;
    bool WasInRange;

    public AudioClip triggerSound;
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animation3 = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        bool InRange = distance < Distance;
        if (InRange && !WasInRange && !IsAnimation)
        {
            Animation3.SetTrigger("Silly");
            IsAnimation = true;
            audioSource.PlayOneShot(triggerSound);
            Debug.Log("anim");

        }
        if (IsAnimation)
        {
            AnimatorStateInfo StatInfo = Animation3.GetCurrentAnimatorStateInfo(0);
            if (StatInfo.normalizedTime >= 1f)
            {
                IsAnimation = false;
                Debug.Log("pasanim");
                Animation3.SetTrigger("Idle");
            }
        }
        WasInRange = InRange;
    }
}
