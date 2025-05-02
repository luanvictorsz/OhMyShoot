using UnityEngine;

public class LookToPlayer : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.instance.transform.position, -Vector3.forward);
    }
}
