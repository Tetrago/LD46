﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera camera_;
    public GameObject cursor_;
    public GameObject highligher_;
    public GameObject shield_;
    public GameObject drip_;
    public GameObject dropProjectile_;

    public float moveSpeed_;
    public float shootTime_;
    public float highlighterFadeDistance_;

    private SpriteRenderer cursorRenderer_;
    private SpriteRenderer highlighterRenderer_;
    private float lastShot_;
    private SpriteRenderer enemyHighlighter_;

    private void Awake()
    {
        Cursor.visible = false;

        cursor_ = Instantiate(cursor_);
        cursorRenderer_ = cursor_.GetComponentInChildren<SpriteRenderer>();

        enemyHighlighter_ = Instantiate(highligher_, transform).GetComponent<SpriteRenderer>();
        enemyHighlighter_.color = Color.red;

        highligher_ = Instantiate(highligher_, transform);
        highlighterRenderer_ = highligher_.GetComponent<SpriteRenderer>();

        shield_ = Instantiate(shield_, transform);
    }

    private void Update()
    {
        Fire();
        Move();

        UpdateCursor();
        UpdateHighlighter();
        UpdateShield();
    }

    private void Fire()
    {
        if(Input.GetMouseButton(0) && lastShot_ <= Time.time - shootTime_)
        {
            Sound.Instance.Play(transform.position, Resources.Load<AudioClip>("Shoot"));

            Vector2 dir = camera_.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Instantiate(dropProjectile_, transform.position, Quaternion.identity)
                .GetComponent<Projectile>()
                .Shoot(dir.normalized);

            lastShot_ = Time.time;
        }
    }

    private void Move()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        transform.Translate(input * moveSpeed_ * Time.deltaTime);
    }

    private void UpdateCursor()
    {
        Vector3 pos = camera_.ScreenToWorldPoint(Input.mousePosition);
        pos.z = cursor_.transform.position.z;
        cursor_.transform.position = pos;

        Vector3 diff = cursor_.transform.position - transform.position;
        cursor_.transform.rotation = Util.LookAt(diff);

        Color col = cursorRenderer_.color;
        col.a = Mathf.Min(1, diff.magnitude);
        cursorRenderer_.color = col;
    }

    private void UpdateHighlighter()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(enemy != null)
        {
            enemyHighlighter_.transform.rotation = Util.LookAt(enemy.transform.position - transform.position);

            Color color = enemyHighlighter_.color;
            color.a = Mathf.Min(Vector3.Distance(enemy.transform.position, transform.position) / highlighterFadeDistance_, 1);
            enemyHighlighter_.color = color;
        }
        else
        {
            Color color = enemyHighlighter_.color;
            color.a = 0;
            enemyHighlighter_.color = color;
        }

        Vector3 diff = drip_.transform.position - transform.position;

        highligher_.transform.rotation = Util.LookAt(diff);

        Color col = highlighterRenderer_.color;
        col.a = Mathf.Min(Vector3.Distance(drip_.transform.position, transform.position) / highlighterFadeDistance_, 1);
        highlighterRenderer_.color = col;
    }

    private void UpdateShield()
    {
        shield_.transform.rotation = Util.LookAt(camera_.ScreenToWorldPoint(Input.mousePosition) - transform.position);
    }
}
