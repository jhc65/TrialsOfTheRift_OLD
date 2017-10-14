using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum Side { LEFT, RIGHT };
    public enum Color { RED, BLUE};

    public Side side;
    public Color color;
    public float maxPlayerSpeed = 10f;
    public float maxFireSpeed = 10f;
    public float maxWindSpeed = 10f;
    public int maxFireRate = 1;
    public float horAxis;
    public float vertAxis;
    public Rigidbody2D firePrefab;
    public Rigidbody2D windPrefab;

    private Vector2 movement;
    private Vector3 target;
    private float rotAngle;
    private bool allowFire = true;
    private Rigidbody2D rigidBody;

    public Side GetSide() {
        if (transform.position.x < 0)
        {
            return Side.LEFT;
        }
        else {
            return Side.RIGHT;
        }
    }

    public Color GetColor() {
        return color;
    }

    public void SetColor(Color col) {
        color = col;
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        movement = new Vector2(0f, 0f);
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0f;
        movement = (target - transform.position).normalized;

        //rotate the sprite
        rotAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(rotAngle, Vector3.forward);

        horAxis = Input.GetAxis("Horizontal");
        vertAxis = Input.GetAxis("Vertical");

        rigidBody.velocity = new Vector2(horAxis * maxPlayerSpeed, vertAxis * maxPlayerSpeed);

        if (Input.GetButtonDown("Fire1") && allowFire) {
            attack(firePrefab, maxFireSpeed);
        } else if(Input.GetButtonDown("Fire2") && allowFire) {
            attack(windPrefab, maxWindSpeed);
        }

	}

    protected void attack(Rigidbody2D spellPrefab, float speed) {
        allowFire = false;
        Rigidbody2D fire = Instantiate(spellPrefab, transform.position, transform.rotation);
        fire.velocity = movement * speed;

        Physics2D.IgnoreCollision(fire.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        allowFire = true;
    }
}
