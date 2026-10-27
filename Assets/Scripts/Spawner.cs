using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Obstacles;
    [Min(0)] public float SpawnCooldown;
    [Min(0)] public float ScrollSpeed;
    private float Cooldown;
    public void SpawnObstacle(int index)
    {
        Cooldown = SpawnCooldown;
        GameObject obstacle = Instantiate(Obstacles[index], transform.position, Quaternion.identity);
        obstacle.GetComponent<Scroll>().ScrollSpeed = ScrollSpeed;
    }
    void Update()
    {
        if (Cooldown > 0)
            Cooldown -= Time.deltaTime;
        else
            SpawnObstacle(Random.Range(0, Obstacles.Length));
    }
}
