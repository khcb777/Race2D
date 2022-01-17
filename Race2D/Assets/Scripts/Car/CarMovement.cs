using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Car))]
public class CarMovement : MonoBehaviour
{
	[SerializeField] private WheelJoint2D _backWheel;
	[SerializeField] private WheelJoint2D _frontWheel;
	[SerializeField] private PhysicsMaterial2D _wheelMaterial;


	private Rigidbody2D _rb;
	private Car _car;

	private float _movement = 0f;

	private void Start()
	{
		_car = GetComponent<Car>();
		WheelFriction(_car.Wheel);
		
	}

	private void Update()
	{
		_movement = Input.GetAxisRaw("Horizontal") * _car.Speed;

	}

	public void MoveDir(int dir)
	{
		_movement = dir * _car.Speed;
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		if (_backWheel == null || _frontWheel == null)
		{
			_car.OnCarCrash();
			return;
		}

		if (_car.Fuel <= 0 || _car.IsCrash) return;

		if (_movement == 0f)
		{
			_backWheel.useMotor = false;
			_frontWheel.useMotor = false;
		}
		else
		{
			var motor = new JointMotor2D {motorSpeed = _movement, maxMotorTorque = _frontWheel.motor.maxMotorTorque};

			
			switch ((CarDriveType)_car.DriveType)
			{

				case CarDriveType.FrontWheelDrive:
					_frontWheel.useMotor = true;
					_frontWheel.motor = motor;
					break;
				case CarDriveType.RearDrive:
					_backWheel.useMotor = true;
					_backWheel.motor = motor;
					break;
				case CarDriveType.FourWheelDrive:
					_frontWheel.useMotor = true;
					_frontWheel.motor = motor;
					_backWheel.useMotor = true;
					_backWheel.motor = motor;
					break;
			}
		}

	}
	
	private void WheelFriction( float friction)
	{
		_wheelMaterial.friction = friction;
		_frontWheel.GetComponent<Rigidbody2D>().sharedMaterial = _wheelMaterial;
		_backWheel.GetComponent<Rigidbody2D>().sharedMaterial = _wheelMaterial;
	}
}


enum CarDriveType
{
	FrontWheelDrive,
	RearDrive,
	FourWheelDrive,
}
