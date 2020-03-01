using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float paddleWidthinUnits = 2f;

    // Update is called once per frame
    void Update()
    {
        float mouseXPosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mouseXPosInUnits, paddleWidthinUnits / 2, screenWidthInUnits - (paddleWidthinUnits / 2));
        transform.position = paddlePos;
    }
}
