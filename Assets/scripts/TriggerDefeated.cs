using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TriggerDefeated : MonoBehaviour
{
    public GameObject Player;
    float Distance = 2f;
    bool Range;
    public string triggerName = "Idle";
    public Animator Defeat;
    int defeatedHash;
    bool WasInRange;
    bool isAnimation;
    bool defeatedisplaying;

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
        Defeat = GetComponent<Animator>();
        //defeatedHash = Animator.StringToHash("Base Layer.Defeated");
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

        volume = 0.5f;
        pitch = 1f;

        audioSource.clip = triggerSound;
        audioSource.volume = volume;
        audioSource.pitch = pitch;

        BillBoard.SetActive(false);
        fxGameObject.SetActive(false);

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
        //int  hash = Animator.StringToHash("Defeated");       
        //float durée = StatInfo.length;
        //float duréetotal = StatIn.fullPathHash;
        //Debug.Log(distance);
        if (InRange)
        {
            if (!WasInRange && !isAnimation)
            {
                Defeat.SetTrigger("Defeated");
                isAnimation = true;
                PlayandPause();
                Debug.Log("anim");
                BillBoard.SetActive(true);
                fxGameObject.SetActive(true);
            }
            //Defeat.ResetTrigger("Silly");
            if (isAnimation)
            {
                AnimatorStateInfo StatInfo = Defeat.GetCurrentAnimatorStateInfo(0);
                if (StatInfo.normalizedTime >= 1f)
                {
                    isAnimation = false;
                    Debug.Log("pasanim");
                }
            }
        }
        if (!InRange && WasInRange)
        {
            Defeat.Rebind();
            audioSource.Stop();
            isAnimation = false;
            Debug.Log("pasanim");
            BillBoard.SetActive(false);
            fxGameObject.SetActive(false);
        }
        WasInRange = InRange;
    }
}