using UnityEngine;

public class SeekerController : MonoBehaviour
{
    public float speed = 5;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(x, y) * speed * Time.deltaTime);
    }
}
