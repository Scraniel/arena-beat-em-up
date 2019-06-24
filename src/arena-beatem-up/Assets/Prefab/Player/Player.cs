using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float Speed = 0.01f;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = GetMovementDirection();
        transform.position += direction.ToVector3() * Speed;

        UpdateAnimation();
        
        //Stop animation if player is not moving
        _animator.speed = direction == Vector2.zero ? 0 : 0.1f;
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

    private void UpdateAnimation()
    {
        foreach (KeyCode key in _keyCodeAnimationMap.Keys)
        {
            if (Input.GetKeyDown(key))
                _animator.Play(_keyCodeAnimationMap[key]);
        }
    }

    private Dictionary<KeyCode, Vector2> _keyCodeDirectionMap = new Dictionary<KeyCode, Vector2>
    {
        {KeyCode.W, new Vector2(0, 1) },
        {KeyCode.A, new Vector2(-1, 0) },
        {KeyCode.S, new Vector2(0, -1) },
        {KeyCode.D, new Vector2(1, 0) }
    };

    private Dictionary<KeyCode, string> _keyCodeAnimationMap = new Dictionary<KeyCode, string>
    {
        {KeyCode.W, "player-walking-up" },
        {KeyCode.A, "player-walking-left"},
        {KeyCode.S, "player-walking-down"},
        {KeyCode.D, "player-walking-right"}
    };
}
