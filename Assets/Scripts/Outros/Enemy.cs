using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] walkPoints;
    [SerializeField] private int currentWalkPointIndex = 0;

    [Header("Booleans")]
    [SerializeField] private bool enemyIsAlive;
    [SerializeField] private bool enemyCanWalk;

    private float waitTime = 3f;
    private float waitCounter = 0f;
    private bool isWaiting = false;

    void Start()
    {
        enemyIsAlive = true;
        enemyCanWalk = true;

        if (walkPoints.Length > 0)
        {
            transform.position = walkPoints[0].position;
        }
    }

    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        if (!enemyIsAlive) return;

        if (isWaiting)
        {
            waitCounter -= Time.deltaTime;
            if (waitCounter <= 0f)
            {
                isWaiting = false;
                enemyCanWalk = true;
                currentWalkPointIndex = (currentWalkPointIndex + 1) % walkPoints.Length;
            }
            return;
        }

        if (enemyCanWalk && walkPoints.Length > 0)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                walkPoints[currentWalkPointIndex].position,
                speed * Time.deltaTime);

            // Verifica se chegou no ponto atual
            if (Vector2.Distance(transform.position, walkPoints[currentWalkPointIndex].position) < 0.1f)
            {
                enemyCanWalk = false;
                isWaiting = true;
                waitCounter = waitTime;
            }
        }
    }
}