using UnityEngine;

public class DebugSquareProjectile : MonoBehaviour
{
    private Timer _deathTimer = new Timer();



    // Start is called before the first frame update
    void Start()
    {
        _deathTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        _deathTimer.Update();
        if (_deathTimer.CurrentTime > 0.15f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IEnemy enemyHit = collision.gameObject.GetComponent<IEnemy>();

        if (enemyHit != null)
        {
            enemyHit.TakeDamage(1);
        }
    }
}
