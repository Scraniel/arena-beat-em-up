using UnityEngine;

public class DebugSquare : MonoBehaviour, IWeapon
{
    public GameObject Projectile;
    private GameObject _weaponAnchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Attack(Vector2 direction)
    {
        Vector3 projPosition = _weaponAnchor.transform.position + direction.ToVector3() * 0.5f;
        GameObject.Instantiate(Projectile, projPosition, Quaternion.identity);
    }

    public void Bind(GameObject anchor)
    {
        _weaponAnchor = anchor;
    }
}
