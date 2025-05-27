using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] walkPoints;
    [SerializeField] private int currentWalkPointIndex = 0;

    [Header("Booleans")]
    [SerializeField] private bool enemyIsAlive;
    [SerializeField] private bool enemyCanWalk;

    private float timeInThePoints;
    private float timeActualy;

    void Start()
    {
        enemyIsAlive = true;
        enemyCanWalk = true;

        transform.position = walkPoints[0].position;
    }

    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        if (enemyIsAlive)
        {
            if(enemyCanWalk)
            {
                transform.position = Vector2.MoveTowards(transform.position, walkPoints[currentWalkPointIndex].position, speed * Time.deltaTime);

                if(transform.position.y == walkPoints[~currentWalkPointIndex].position.y)
                {
                    WaitForWalking();
                }
                if (currentWalkPointIndex >= walkPoints.Length)
                {
                    currentWalkPointIndex = 0;
                }
            }
        }
    }

    private void WaitForWalking()
    {
        //enemyCanWalk = false;
        timeActualy = Time.deltaTime;

        if(timeActualy <= 0)
        {
            enemyCanWalk= true;
            currentWalkPointIndex++;
            timeActualy = timeInThePoints;
        }
    }
}
