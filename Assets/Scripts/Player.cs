using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _position;
    [SerializeField] private float _speed;
    private bool isWalking;
    [SerializeField] GameInput gameInput;

    private Vector3 _lastPosition;

    public bool IsWalking { get { return isWalking; }     
    }

    private void Start()
    {               
        Application.targetFrameRate = 60;
        gameInput.OnPlayerInteract += GameInput_OnPlayerInteract;
    }

    private void GameInput_OnPlayerInteract(object sender, System.EventArgs e)
    {
        Vector2 inputVector = gameInput.GameMovmentVectorNormalized();

        _position = new Vector3(inputVector.x, 0, inputVector.y);

        if (_position != Vector3.zero)
        {
            _lastPosition = _position;
        }

        float interactionDistance = 2f;

        if (Physics.Raycast(transform.position, _lastPosition, out RaycastHit raycastHit, interactionDistance))
        {
            print("Event Interact");
        }
        else
        {
            print("-");
        }
    }

    private void Update()
    {
        HandleMovement();
         
        HandleInteraction();

    }

    private void HandleInteraction()
    {
        Vector2 inputVector = gameInput.GameMovmentVectorNormalized();

        _position = new Vector3(inputVector.x, 0, inputVector.y);

        if(_position != Vector3.zero)
        {
            _lastPosition = _position;
        }

        float interactionDistance = 2f;

        if(Physics.Raycast(transform.position, _lastPosition, out RaycastHit raycastHit, interactionDistance))
        {
            print(raycastHit.collider.name);            
        }
        else
        {
            print("-");
        }

    }

    private void HandleMovement() 
    {
        Vector2 inputVector = gameInput.GameMovmentVectorNormalized();

        _position = new Vector3(inputVector.x, 0, inputVector.y);

        float moveDistance = _speed * Time.deltaTime;
        float hitSize = 0.7f;
        float playerHeight = 2;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, hitSize, _position, moveDistance);

        if (!canMove)
        {
            Vector3 _positionX = new Vector3(_position.x, 0, 0);

            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, hitSize, _positionX, moveDistance);

            if (canMove)
            {
                _position = _positionX;
            }
            else
            {
                Vector3 _positionZ = new Vector3(0, 0, _position.z);

                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, hitSize, _positionZ, moveDistance);

                if (canMove)
                {
                    _position = _positionZ;
                }
            }
        }
        if (canMove)
        {
            transform.position += _position * _speed * Time.deltaTime;
        }

        isWalking = _position != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, _position, Time.deltaTime * _speed);
        //print(transform.position);


    }
}
