using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int HP = 100;
    [SerializeField]
    private Sprite defeatSprite;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;

        if (HP <= 0)
        {
            StartCoroutine(defeat());
        }
    }

    public IEnumerator defeat()
    {
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = defeatSprite;
        speed = 0;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public int getHP()
    {
        return HP;
    }

}