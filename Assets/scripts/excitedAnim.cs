using UnityEngine;

public class excitedAnim : MonoBehaviour
{
    public GameObject Player;
    public string TriggerName = "Idle";
    public Animator Animation2;
    float Distance = 2f;
    bool IsAnimation;
    bool WasInRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animation2 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        bool InRange = distance < Distance;
        if (InRange && !WasInRange && !IsAnimation)
        {
            Animation2.SetTrigger("excited");
            IsAnimation = true;
            Debug.Log("anim");

        }
        if (IsAnimation)
        {
            AnimatorStateInfo StatInfo = Animation2.GetCurrentAnimatorStateInfo(0);
            if (StatInfo.normalizedTime >= 1f)
            {
                IsAnimation = false;
                Debug.Log("pasanim");
                Animation2.SetTrigger("Idle");
            }
        }
        WasInRange = InRange;
    }
}
