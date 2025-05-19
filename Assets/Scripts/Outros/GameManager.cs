using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameManager instance;
    [SerializeField] private bool playerIsAlive;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.instance.transform.position, -Vector3.forward);
    }


}
