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
        EnemyMove();
    }

    void EnemyMove()
    {
        if (enemyIsAlive)
        {
            if(enemyIsMoving)
            {
                transform.position = Vector2.MoveTowards(transform.position, walkPoints[currentWalkPointIndex].position, speed * Time.deltaTime);

                if(transform.position.y == walkPoints[~currentWalkPointIndex].position.y)
                {
                    currentWalkPointIndex++;
                }
                if (currentWalkPointIndex >= walkPoints.Length)
                {
                    currentWalkPointIndex = 0;
                }
            }
        }
    }
}
