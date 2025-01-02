using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _position;
    [SerializeField] private float _speed;
    private bool isWalking;

    public bool IsWalking { get { return isWalking; }     
    }

    private void Start()
    {               
        Application.targetFrameRate = 60;
    }



    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;
        _position = new Vector3(inputVector.x, 0, inputVector.y);

        transform.position += _position * _speed * Time.deltaTime;

        isWalking = _position != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, _position, Time.deltaTime * _speed);
        print(transform.position);

    }

}
