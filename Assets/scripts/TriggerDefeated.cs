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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Defeat = GetComponent<Animator>();
        defeatedHash = Animator.StringToHash("Base Layer.Defeated");
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        bool InRange = distance < Distance;
        int  hash = Animator.StringToHash("Defeated");       
        //float durée = StatInfo.length;
        //float duréetotal = StatIn.fullPathHash;
        //Debug.Log(distance);
        if (InRange && !WasInRange && !isAnimation)
        {
            Defeat.SetTrigger("Defeated");
            isAnimation = true;
            Debug.Log("anim");
            defeatedisplaying = true;
        }
        //if (!InRange && !isAnimation && !defeatedisplaying)
        //{
        //    Defeat.SetTrigger("Idle");
        //    isAnimation = true;
        //    Debug.Log("idle");
        //}
        if (isAnimation)
        {
            AnimatorStateInfo StatInfo = Defeat.GetCurrentAnimatorStateInfo(0);
            if (StatInfo.normalizedTime >= 1f)
            {
                isAnimation = false;
                Debug.Log("pasanim");
                defeatedisplaying = false;
                Defeat.SetTrigger("Idle");
            }
        }
       WasInRange = InRange;
    }
}