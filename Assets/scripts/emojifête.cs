using UnityEngine;

public class emojifête : MonoBehaviour
{
    public Camera cam;
    public GameObject Perso;
    public Vector3 offset = new Vector3(0f, 0f, 0f);

    // Update is called once per frame
    void Update()
    {
    transform.rotation = cam.transform.rotation;
        Vector3 newPos = Perso.transform.position;
        transform.position = new Vector3(newPos.x + offset.x,newPos.y + offset.y + 2f, newPos.z + offset.z);
    }
}
