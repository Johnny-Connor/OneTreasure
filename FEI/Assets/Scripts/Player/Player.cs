using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Sprite defeatSprite;
    [SerializeField]
    private int HP = 100;
    [SerializeField]
    private int DMG = 10;
    [SerializeField]
    private float SPD = 3;
    [SerializeField]
    private float fireRate = 0.35f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject furBallW;
    [SerializeField]
    private GameObject furBallA;
    [SerializeField]
    private GameObject furBallS;
    [SerializeField]
    private GameObject furBallD;
    private float canFire = -0.001f;
    private Vector2 lastDir;
    private bool boss;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement();
        shoot();
        death();
    }

    public IEnumerator defeat()
    {
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = defeatSprite;
        SPD = 0;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public int getHP()
    {
        return HP;
    }

    public void setHP(int value)
    {
        HP = value;
    }
    public int getDMG()
    {
        return DMG;
    }

    public void movement()
    {
        if (transform.position.x < -49)
        {
            boss = true;
        }
        Vector2 dir = Vector2.zero;
        if (Time.timeScale == 1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
                lastDir = new Vector2(-1, 0);
}
            else if (Input.GetKey(KeyCode.D))
            {
                if (transform.position.x >= -49.3f && boss == true)
                {
                    dir.x = 0;
                }
                else
                {
                    dir.x = 1;
                    animator.SetInteger("Direction", 2);
                }
                lastDir = new Vector2(1, 0);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
                lastDir = new Vector2(0, 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
                lastDir = new Vector2(0, -1);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = SPD * dir;
        }
    }

    public void shoot()
    {
        if (Time.timeScale == 1 && HP > 0)
        {
            if (Input.GetButton("Fire1") && (Time.time > canFire))
            {
                canFire = Time.time + fireRate;
                if (lastDir == new Vector2(-1, 0))
                {
                    Instantiate(furBallA, transform.position + new Vector3(-0.7f, 0.5f, 0), Quaternion.identity);
                }
                else if (lastDir == new Vector2(1, 0))
                {
                    Instantiate(furBallD, transform.position + new Vector3(0.7f, 0.5f, 0), Quaternion.identity);
                }
                else if (lastDir == new Vector2(0, 1))
                {
                    Instantiate(furBallW, transform.position + new Vector3(-0.007f, 1.7f, 0), Quaternion.identity);
                }
                else if (lastDir == new Vector2(0, -1))
                {
                    Instantiate(furBallS, transform.position + new Vector3(-0.007f, -0.3f, 0), Quaternion.identity);
                }
            }
        }
    }

    public void death()
    {
        if (HP <= 0)
        {
            StartCoroutine(defeat());
        }
    }

}