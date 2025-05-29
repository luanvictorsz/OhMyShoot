using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager instance;

    [SerializeField] private bool playerIsAlive;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        transform.LookAt(Player.instance.transform.position, -Vector3.forward);
    }
}
