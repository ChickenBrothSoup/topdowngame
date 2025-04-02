using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : Movement
{
    protected override void HandleInput()
    {
        _InputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    protected override void HandleRotation()
    {
        if(_weaponHandler == null || _weaponHandler.CurrentWeapon == null)
        {
            base.HandleRotation();
            return;
        }
        Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        mousPos = new Vector3(mousPos.x, mousPos.y, transform.position.z);

        Vector2 direction = mousPos - transform.position;


        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

}
