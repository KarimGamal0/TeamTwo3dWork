using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour
{

    [SerializeField]  Image joystick;
    [SerializeField] float range = 200f;
    [SerializeField] Vector3SO movement;
    Touch _touch;
    Vector3 origninalPosition;
    Vector3 touchPosition;
    Vector3 Touchdisplacment;
    bool is_dragged = false;
    void Start()
    {
        origninalPosition = joystick.transform.position;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            movement.value = Vector3.zero;
            _touch = Input.GetTouch(0);
            touchPosition = _touch.position;
            touchPosition.z = 0.0f;
            Touchdisplacment = origninalPosition - touchPosition;
            if (Touchdisplacment.magnitude < range && _touch.phase == TouchPhase.Began)
            {
                is_dragged = true;
            }
            if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary)
            {
                if (is_dragged == true && Touchdisplacment.magnitude < range)
                {
                    joystick.rectTransform.position = touchPosition;
                    movement.value = new Vector3(-Mathf.Clamp((Touchdisplacment).x, -5, 5), 0, -Mathf.Clamp((Touchdisplacment).y, -5, 5));
                }
                else if (is_dragged == true && Touchdisplacment.magnitude >= range)
                {
                    joystick.rectTransform.position = Vector3.ClampMagnitude(Vector3.LerpUnclamped(origninalPosition, touchPosition, range), range) + origninalPosition;
                    movement.value = new Vector3(-Mathf.Clamp((Touchdisplacment).x, -5, 5), 0, -Mathf.Clamp((Touchdisplacment).y, -5, 5));
                }
            }
            if (_touch.phase == TouchPhase.Ended)
            {
                is_dragged = false;
                joystick.rectTransform.position = origninalPosition;
                movement.value = Vector3.zero;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(origninalPosition, touchPosition);
    }
}