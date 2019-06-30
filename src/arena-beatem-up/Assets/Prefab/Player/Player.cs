using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float Speed = 0.01f;

    public GameObject EquippedWeapon;
    private Animator _animator;
    private Rigidbody2D _body;

    private IWeapon _weapon;

    

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 0.1f;
        _body = GetComponent<Rigidbody2D>();
        SwitchWeapon(EquippedWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementDirection = GetMovementDirection();
        _body.MovePosition(transform.position + movementDirection.ToVector3() * Speed);
        var characterOrientation = GetCharacterOrientation();
        UpdateAnimation(characterOrientation);

        //Stop animation if player is not moving
        _animator.speed = movementDirection == Vector2.zero ? 0 : 0.1f;

        int leftClickMouseButton = 0;
        if (Input.GetMouseButtonDown(leftClickMouseButton))
        {
            _weapon.Attack(characterOrientation);
        }
    }

    public void SwitchWeapon(GameObject weapon)
    {
        _weapon = weapon.GetComponent<IWeapon>();
        _weapon.Bind(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IEnemy collidedEnemy = collision.gameObject.GetComponent<IEnemy>();

        if (collidedEnemy == null)
            return;

        Debug.Log("Bat Attacked Player!");
    }

    private Vector2 GetMovementDirection() {

        Vector2 direction = Vector2.zero;
        foreach (KeyCode key in _keyCodeDirectionMap.Keys)
        {
            if (Input.GetKey(key))
                direction += _keyCodeDirectionMap[key];
        }
        return direction;
    }

    private Vector2 GetCharacterOrientation()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var charPosition = this.transform.position;
        var dirVec = mousePosition - charPosition;
        return (mousePosition - charPosition).ToVector2().normalized;
    }

    private void UpdateAnimation(Vector2 characterOrientation)
    {
        if (characterOrientation.x <= -0.7f)
            _animator.Play("player-walking-left");
        else if (characterOrientation.x >= 0.7f)
            _animator.Play("player-walking-right");
        else if (characterOrientation.y >= 0.7f)
            _animator.Play("player-walking-up");
        else if (characterOrientation.y <= 0.7f)
            _animator.Play("player-walking-down");
    }

    private Dictionary<KeyCode, Vector2> _keyCodeDirectionMap = new Dictionary<KeyCode, Vector2>
    {
        {KeyCode.W, new Vector2(0, 1) },
        {KeyCode.A, new Vector2(-1, 0) },
        {KeyCode.S, new Vector2(0, -1) },
        {KeyCode.D, new Vector2(1, 0) }
    };
}


//whatever direction char is looking, make it look that way

//Get mouse/char direction vector
//From vector, get deg
//