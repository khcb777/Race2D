using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CarMovement : MonoBehaviour
{
	public event UnityAction CrashAction;
	public event UnityAction FuelEmptyAction;

	[SerializeField] private int _fuel;
	[SerializeField] private CarDriveType _carDriveType;
	[SerializeField] private float _speed = 1300;
	[SerializeField] private WheelJoint2D _backWheel;
	[SerializeField] private WheelJoint2D _frontWheel;


	private float _movement = 0f;
	private bool isCrash;

	private void Start()
	{
		isCrash = false;
	}

	private void Update()
	{
		_movement = Input.GetAxisRaw("Horizontal") * _speed;
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Ground") isCrash = true;
	}

	private void Move()
	{
		if (_backWheel == null || _frontWheel == null || isCrash)
		{
			CrashAction?.Invoke();
			return;
		}

		if (_fuel <= 0)
		{
			FuelEmptyAction?.Invoke();
			return;
		}

		if (_movement == 0f)
		{
			_backWheel.useMotor = false;
			_frontWheel.useMotor = false;
		}
		else
		{
			var motor = new JointMotor2D {motorSpeed = _movement, maxMotorTorque = _frontWheel.motor.maxMotorTorque};
			switch (_carDriveType)
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
	
}


enum CarDriveType
{
	FrontWheelDrive,
	RearDrive,
	FourWheelDrive,
}
