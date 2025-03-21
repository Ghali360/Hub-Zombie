using UnityEngine;

public class FX : MonoBehaviour
{
    public Camera cam;
    public GameObject Emoji;
    public Vector3 offset = new Vector3(0f, 0f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Emoji.transform.rotation;
        Vector3 newPos = Emoji.transform.position;
        transform.position = new Vector3(newPos.x + offset.x, newPos.y + offset.y, newPos.z + offset.z);
    }
}
