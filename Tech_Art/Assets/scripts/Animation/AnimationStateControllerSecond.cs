using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateControllerSecond : MonoBehaviour
{
    private Animator _animator;
    private float _velocity = 0.0f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float deceleration = 0.5f;
    private int _velocityHash;

    // Start is called before the first frame update
    void Start()
    {
        // set reference fpr animator
        _animator = GetComponent<Animator>();

        // increases performance
        _velocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        // get input from the player
        bool fowardPressed = Input.GetKey(KeyCode.W);
        //bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if (fowardPressed && _velocity < 1.0f )
        {
            _velocity += Time.deltaTime * acceleration;
        }

        if (!fowardPressed && _velocity > 0.0f )
        {
            _velocity -= Time.deltaTime * deceleration;
        }

        if (!fowardPressed && _velocity < 0.0f )
        {
            _velocity = 0.0f;
        }

        _animator.SetFloat(_velocityHash, _velocity);
    }
}
