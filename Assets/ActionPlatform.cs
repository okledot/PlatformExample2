using UnityEngine;

public class ActionPlatform : MonoBehaviour
{
    [Header("Аттрибуты")]
    public float speed = 10f;
    public bool up = true;

    [Header("Игровые объекты")]
    public GameObject zone;

    Vector3 move = new Vector3(0.0f, 0.1f, 0.0f);

    private void Update()
    {
        Movement(speed, up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == zone) up = !up;
    }

    private void Movement(float speed, bool up)
    {
        int a = 1;

        if (!up)
        {
            a *= -1;
        }

        transform.position += move * speed * a * Time.deltaTime;
    }

}
