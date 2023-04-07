using UnityEngine;

public class TouchRotation : MonoCache
{
    public float rotateSpeed = 5.0f;

    public override void OnTick()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.deltaPosition.x;
                transform.Rotate(0f, -deltaX * rotateSpeed * Time.deltaTime, 0f);
            }
        }
    }
}
