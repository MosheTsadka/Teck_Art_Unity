using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator _animator;
    private int _isWalkingHash;
    private int _isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _isWalkingHash = Animator.StringToHash("isWalking");
        _isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = _animator.GetBool("isRunning");
        bool isWalking = _animator.GetBool(_isWalkingHash);
        bool fowardPressed = Input.GetKey(KeyCode.W);
        bool runPress = Input.GetKey(KeyCode.LeftShift);

        // if player presses w key
        if (!isWalking && fowardPressed)
        {
            // then set the isWalking boolean to be true
            _animator.SetBool(_isWalkingHash, true);
        }

        // if the player not pressing w key 
        if (isWalking && !fowardPressed)
        {
            // then set the boolean to false
            _animator.SetBool(_isWalkingHash, false);
        }

        // if player is walking and not running and presses left shift
        if (!isRunning && (fowardPressed && runPress))
        {
            // then set the isRunning boolean to be true
            _animator.SetBool(_isRunningHash, true);
        }

        // if the player is running and stops running or walking
        if (isRunning && (!fowardPressed || !runPress))
        {
            // then set the isRunning boolean to be false
            _animator.SetBool(_isRunningHash, false);
        }
    }
}
