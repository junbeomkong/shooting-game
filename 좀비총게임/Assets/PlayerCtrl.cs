using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    private float player_speed = 5.0f;
    private float rot_speed = 120.0f;
    private float bullet_power = 600.0f;
    private bool shoot = false;
    private int life = 3;
    public GameObject bullett;
    public GameObject spawn_point;
    public GameObject spawn_point1;
    public GameObject spawn_point2;
    public GameObject PboxEffect;
    public GameObject YboxEffect;
    public GameObject hitEffect3;
    public GameObject hitEffect4;
    private AudioSource audio;
    private AudioSource audio1;
    private AudioSource audio2;
    public AudioClip jumpSound;
    public AudioClip ZomAttack;
    public AudioClip BombAttack;
    static public int num = 0;
    static public int num1 = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.ZomAttack;
        this.audio1.loop = false;
        this.audio2 = this.gameObject.AddComponent<AudioSource>();
        this.audio2.clip = this.BombAttack;
        this.audio2.loop = false;


    }

    // Update is called once per frame
    void Update()
    {
        move();
        fire();
        life1();

    }
    void life1()
    {
        if (life == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("start");
            bullet.score = 0;
        }
    }
    void move()
    {
        float distance_per_frame = player_speed * Time.deltaTime;
        float degrees_per_frame = rot_speed * Time.deltaTime;

        float moving_velocity = Input.GetAxis("Vertical");
        float player_angle = Input.GetAxis("Horizontal");

        this.transform.Translate(Vector3.forward * moving_velocity * distance_per_frame);
        this.transform.Rotate(0.0f, player_angle * degrees_per_frame, 0.0f);

    }
    void fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!shoot)
            {
                GameObject prefab_bullet = Instantiate(bullett, spawn_point.transform.position, spawn_point.transform.rotation);
                prefab_bullet.GetComponent<Rigidbody>().AddForce(spawn_point.transform.forward * bullet_power);
                Destroy(prefab_bullet, 2.0f);
                this.audio.Play();
            }

            if (shoot)
            {
                GameObject prefab_bullet1 = Instantiate(bullett, spawn_point1.transform.position, spawn_point1.transform.rotation);
                prefab_bullet1.GetComponent<Rigidbody>().AddForce(spawn_point1.transform.forward * bullet_power);
                Destroy(prefab_bullet1, 2.0f);
                GameObject prefab_bullet2 = Instantiate(bullett, spawn_point2.transform.position, spawn_point2.transform.rotation);
                prefab_bullet2.GetComponent<Rigidbody>().AddForce(spawn_point2.transform.forward * bullet_power);
                Destroy(prefab_bullet2, 2.0f);
                this.audio.Play();
            }
        }
    }
    public void Hurt(float dmg)
    {
        PlayerStats.Instance.TakeDamage(dmg);
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        if (collision.transform.CompareTag("box1"))
        {
            Destroy(collision.gameObject);
            GameObject hitObject1 = Instantiate(PboxEffect, collision.transform.position, collision.transform.rotation);
            Destroy(hitObject1, 1.0f);
            player_speed += 5.0f;
            rot_speed += 80.0f;
            bullet_power += 300.0f;

        }
        if (collision.transform.CompareTag("barrel1"))
        {
            Destroy(collision.gameObject);
            GameObject hitObject2 = Instantiate(YboxEffect, collision.transform.position, collision.transform.rotation);
            Destroy(hitObject2, 1.0f);
            shoot = true;
        }
        if (collision.gameObject.CompareTag("zombie"))
        {
            Hurt(1.0f);
            Destroy(collision.gameObject);
            GameObject hitObject = Instantiate(hitEffect3, collision.transform.position, collision.transform.rotation);
            Destroy(hitObject, 1.0f);
            this.audio1.Play();
            life--;
            
        }
        if (collision.gameObject.CompareTag("monster"))
        {
            Hurt(1.0f);
            Destroy(collision.gameObject);
            GameObject hitObject1 = Instantiate(hitEffect4,
                collision.transform.position, collision.transform.rotation);
            Destroy(hitObject1, 1.0f);
            this.audio2.Play();
            life--;
            
        }
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}

    
