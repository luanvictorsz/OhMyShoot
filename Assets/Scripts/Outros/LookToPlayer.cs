using UnityEngine;

public class LookToPlayer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.instance.transform.position, -Vector3.forward);
    }
}
