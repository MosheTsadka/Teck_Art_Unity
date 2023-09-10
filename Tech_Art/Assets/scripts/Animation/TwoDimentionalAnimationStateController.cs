using UnityEngine;

public class TwoDimentionalAnimationStateController : MonoBehaviour
{
    private Animator _animator;
    private float _velocityZ = 0.0f;
    private float _velocityX = 0.0f;
    [SerializeField] private float acceleration = 2.0f;
    [SerializeField] private float deceleration = 2.0f;
    [SerializeField] private float maximumWalkVelocity = 0.5f;
    [SerializeField] private float maximumRunVelocity = 2.0f;

    //increase performance
    private int _velocityZHash;
    private int _velocityXHash;

    // Start is called before the first frame update
    void Start()
    {
        // search the gameobject this script is attachrd to and get the animator component
        _animator = GetComponent<Animator>();

        // incraese performance
        _velocityZHash = Animator.StringToHash("Velocity Z");
        _velocityXHash = Animator.StringToHash("Velocity X");
    }

    private void ChangeVelocity(bool fowardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {
        if (fowardPressed && _velocityZ < currentMaxVelocity)
        {
            _velocityZ += Time.deltaTime * acceleration;
        }

        // increase velocity in left direction
        if (leftPressed && _velocityX > -currentMaxVelocity)
        {
            _velocityX -= Time.deltaTime * acceleration;
        }

        //increase velocity in right direction
        if (rightPressed && _velocityX < currentMaxVelocity)
        {
            _velocityX += Time.deltaTime * acceleration;
        }

        // decrease velocityZ
        if (!fowardPressed && _velocityZ > 0.0f)
        {
            _velocityZ -= Time.deltaTime * deceleration;
        }

        //increase velocityX if left is not pressed and velocityX < 0
        if (!leftPressed && _velocityX < 0.0f)
        {
            _velocityX += Time.deltaTime * deceleration;
        }

        // decrease velocityX if right is not presse and velocityX > 0
        if (!rightPressed && _velocityX > 0.0f)
        {
            _velocityX -= Time.deltaTime * deceleration;
        }
    }

    // handles reset and locking of velocity
    private void LockOrResetVelocity(bool fowardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {
        // reset velocityZ
        if (!fowardPressed && _velocityZ < 0.0f)
        {
            _velocityZ = 0.0f;
        }

        // reset velocityX
        if (!leftPressed && !rightPressed && _velocityX != 0.0f && (_velocityX > -0.05f && _velocityX < 0.05f))
        {
            _velocityX = 0.0f;
        }

        // lock foward
        if (fowardPressed && runPressed && _velocityZ > currentMaxVelocity)
        {
            _velocityZ = currentMaxVelocity;
        }
        // decelerate to the maximum walk velocity
        else if (fowardPressed && _velocityZ > currentMaxVelocity)
        {
            _velocityZ -= Time.deltaTime * deceleration;
            // round to the currentMaxVelocity if within offset
            if (_velocityZ > currentMaxVelocity && _velocityZ < (currentMaxVelocity + 0.05))
            {
                _velocityZ = currentMaxVelocity;
            }
        }
        // round to the currentMaxVelocity if within offset
        else if (fowardPressed && _velocityZ < currentMaxVelocity && _velocityZ > (currentMaxVelocity - 0.05))
        {
            _velocityZ = currentMaxVelocity;
        }

        // locking left
        if (leftPressed && runPressed && _velocityX < -currentMaxVelocity)
        {
            _velocityX = -currentMaxVelocity;
        }
        //decelerate ro the maximum walk velocity
        else if (leftPressed && _velocityX < -currentMaxVelocity)
        {
            _velocityX += Time.deltaTime * deceleration;
            // round to the currentMaxVelocity if within offset
            if (_velocityX < -currentMaxVelocity && _velocityX > (-currentMaxVelocity - 0.05))
            {
                _velocityX = -currentMaxVelocity;
            }
        }
        // round to the currentMaxVelocity if within offset
        else if (leftPressed && _velocityX > -currentMaxVelocity && _velocityX < (-currentMaxVelocity + 0.05))
        {
            _velocityX = -currentMaxVelocity;
        }

        // locking right
        if (rightPressed && runPressed && _velocityX > currentMaxVelocity)
        {
            _velocityX = currentMaxVelocity;
        }
        // decelerate to the maximum walk velocity
        else if (rightPressed && _velocityX > currentMaxVelocity)
        {
            _velocityX -= Time.deltaTime * deceleration;
            // round to the currentMaxVelocity if within offset
            if (_velocityX > currentMaxVelocity && _velocityX < (currentMaxVelocity + 0.05))
            {
                _velocityX = currentMaxVelocity;
            }
        }
        // round to the currentMaxVelocity if within offset
        else if (rightPressed && _velocityX < currentMaxVelocity && _velocityX > (currentMaxVelocity - 0.05))
        {
            _velocityX = currentMaxVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //input will be true if the player is pressing on passed in key parameter
        // get key input from the player
        bool fowardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        // set current maxVelocity
        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

        // set current changes in velocity
        ChangeVelocity(fowardPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);
        LockOrResetVelocity(fowardPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);

        // set the parameters to our local variable values
        _animator.SetFloat(_velocityZHash, _velocityZ);
        _animator.SetFloat(_velocityXHash, _velocityX);
    }
}
