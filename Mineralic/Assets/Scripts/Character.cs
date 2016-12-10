using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour {

    public float speed;
    public KeyCode jumpKey = KeyCode.Space;
    public Sprite[] walkSprites;
    public Sprite idleSprite;
    public float jumpSpeed;
    public Transform other;

    bool isWalking;
    bool isGrounded; 

    RaycastHit2D hit;

    bool facingRight;

    void Update()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        r.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, r.velocity.y);

        if (Input.GetAxis("Horizontal") > 0)
        {
            facingRight = true;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            facingRight = false;
        }

        if (!facingRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (r.velocity.magnitude > 0.1f)
        {
            if (!isWalking)
            {
                StartCoroutine(Walk());
            }
        }

        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down);
        Debug.Log(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hit.collider.transform.position));
        if (hit.distance < 1.9f)
        {
            isGrounded = true;

        } else
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                r.velocity = new Vector2(r.velocity.x, jumpSpeed);
            }
        }

        if (!isWalking)
        {
            GetComponent<SpriteRenderer>().sprite = idleSprite;
        }

        if(Input.GetMouseButtonDown(0))
        {
            Vector3 c = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit2d = Physics2D.Raycast(transform.position, c - transform.position);

            if (hit2d.collider.gameObject.GetComponent<TileData>() != null)
            {
                if (hit2d.collider.gameObject.GetComponent<TileData>().TileType == 2)
                {
                    GetComponent<Inventory>().Add(1, 1);
                } else if (hit2d.collider.gameObject.GetComponent<TileData>().TileType == 7) {
                    // Glass broke
                } else { 
                }
                hit2d.collider.gameObject.GetComponent<TileData>().hardness -= 1;
                if (hit2d.collider.gameObject.GetComponent<TileData> ().hardness <= 0)
                {
                    Destroy(hit2d.collider.gameObject);
                    GetComponent<Inventory>().Add(hit2d.collider.gameObject.GetComponent<TileData>().TileType, 1);
                }
            }
        }
    }

        IEnumerator Walk() {
            isWalking = true;
            GetComponent<SpriteRenderer>().sprite = walkSprites[0];
            yield return new WaitForSeconds(0.25f);
            GetComponent<SpriteRenderer>().sprite = walkSprites[1];
            yield return new WaitForSeconds(0.25f);
            isWalking = false;
        }
    }