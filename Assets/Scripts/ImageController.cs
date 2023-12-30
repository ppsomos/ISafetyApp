using UnityEngine;

public class ImageController : MonoBehaviour
{
    // Set the speed at which the image moves
    public float moveSpeed = 10f;
    // Set the speed at which the image zooms
    public float zoomSpeed = 1f;

    private RectTransform rectTransform;
    private Vector2 previousTouchPosition;
    private float previousTouchDeltaMagnitude;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the image up and down with touch inputs
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = touch.deltaPosition;
                float vertical = -touchDeltaPosition.y * moveSpeed * Time.deltaTime; // Negate the vertical value to move the image up when dragging up
                Vector3 pos = rectTransform.position;
                pos.y += vertical; // Use += instead of -= to move the image up when dragging up
                rectTransform.position = pos;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                previousTouchDeltaMagnitude = 0;
            }
        }

        // Zoom the image in and out with touch inputs
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPreviousPosition = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePreviousPosition = touchOne.position - touchOne.deltaPosition;

            float previousTouchDeltaMagnitude = (touchZeroPreviousPosition - touchOnePreviousPosition).magnitude;
            float touchDeltaMagnitude = (touchZero.position - touchOne.position).magnitude;
            float deltaMagnitudeDifference = previousTouchDeltaMagnitude - touchDeltaMagnitude;

            Vector3 scale = rectTransform.localScale;
            scale += new Vector3(deltaMagnitudeDifference, deltaMagnitudeDifference, deltaMagnitudeDifference) * zoomSpeed;
            scale = new Vector3(
                Mathf.Clamp(scale.x, 0.1f, 10f),
                Mathf.Clamp(scale.y, 0.1f, 10f),
                Mathf.Clamp(scale.z, 0.1f, 10f)
            );
            rectTransform.localScale = scale;
        }
    }
}
