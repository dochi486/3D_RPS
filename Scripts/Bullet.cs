using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100;
    public Rigidbody rigid;
    public int power = 10;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Instantiate(Resources.Load("SMG"), collision.transform.position, transform.rotation);
            if (collision.collider.CompareTag("Monster"))
            {
                float attackPower = Player.instance.weapon1.ItemData.Damage;
                var monster = collision.transform.GetComponent<Monster>();
                monster.TakeHit(attackPower);
                StartCoroutine(monster.HitCo(attackPower));
            }
        }
    }
}
