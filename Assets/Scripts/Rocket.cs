using UnityEngine;

public class Rocket : MonoBehaviour
{

    [Header("Игровые объекты")]
    public GameObject explosion; // Объект, который спаунится после взрыва

    [Header("Аттрибуты")]
    public int Damage;  // Урон, который мы нанесем
    public float Speed, LifeTime; // Скорость и время жизни снаряда

    Vector3 Dir = new Vector3(0, 0, 0); // Направление полета

    void Start()
    {
        Dir.x = Speed;
        // Говорим, что всегда летим по оси х
        Destroy(gameObject, LifeTime);
        // Говорим, что этот объект уничтожится через установленное время
    }
    void FixedUpdate()
    {
        transform.position += Dir;
        // Движение снаряда
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Если объект с которым мы столкнулись имеет тег Enemy
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("касание");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            // Делаем ссылку на объект противника
            if (enemy != null) // Если ссылка не пуста
            {
                enemy.Hurt(Damage); // Вызываем метод урона и указываем его размер
                                        // Спауним объект, который симулирует взрыв
                //Instantiate(explosion, transform.position, transform.rotation);
                // Уничтожаем пулю
                Destroy(gameObject);
            }
        }
    }
}
