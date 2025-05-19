using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] walkPoints;
    [SerializeField] private int currentWalkPointIndex = 0;

    [Header("Booleans")]
    [SerializeField] private bool enemyIsAlive;
    [SerializeField] private bool enemyIsMoving;

    void Start()
    {
        enemyIsAlive = true;
        enemyIsMoving = true;

        transform.position = walkPoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyMove()
    {
        if (enemyIsAlive)
        {
            if(enemyIsMoving)
            {
                transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentWalkPointIndex].position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, walkPoints[currentWalkPointIndex].position) < 0.1f)
                {
                    currentWalkPointIndex++;

                    if (currentWalkPointIndex >= walkPoints.Length)
                    {
                        currentWalkPointIndex = 0;
                    }
                }
            }
        }
    }
}
