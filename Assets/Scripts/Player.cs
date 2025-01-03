using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _position;
    [SerializeField] private float _speed;
    private bool isWalking;
    [SerializeField] GameInput gameInput;

    public bool IsWalking { get { return isWalking; }     
    }

    private void Start()
    {               
        Application.targetFrameRate = 60;
    }



    private void Update()
    {
        Vector2 inputVector = gameInput.GameMovmentVectorNormalized();

        _position = new Vector3(inputVector.x, 0, inputVector.y);

        transform.position += _position * _speed * Time.deltaTime;

        isWalking = _position != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, _position, Time.deltaTime * _speed);
        print(transform.position);

    }

}
