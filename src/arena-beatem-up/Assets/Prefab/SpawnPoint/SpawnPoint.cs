using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject Enemy;
    public Vector2 SpawnTimeRange = new Vector2(1.0f, 5.0f);

    private CooldownTimer _spawnTimer = new CooldownTimer();

    // Start is called before the first frame update
    void Start()
    {
        ResetSpawnTimer();
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer.Update();

        if (_spawnTimer.IsFinished)
            Spawn();
    }

    private void Spawn()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
        ResetSpawnTimer();
    }

    private void ResetSpawnTimer()
    {
        _spawnTimer.SetTimeLimit(Random.Range(SpawnTimeRange.x, SpawnTimeRange.y));
    }
}
