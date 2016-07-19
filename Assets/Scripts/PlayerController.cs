using UnityEngine;
using System.Collections;
using UnityEngine.UI; // for text

public class PlayerController : MonoBehaviour {
    public float speed = 5f; // movement speed
    public Vector2 jump; // jump height

    public Text livesText;

    private bool right = true; // character starts facing right
    private Rigidbody2D rigid2d;
    private int lives;

	void Start () {
        rigid2d = GetComponent<Rigidbody2D>(); // get character's rigidbody2d
        lives = 3; // set lives
        SetLivesText(); // set text for lives
	}
	
    // non-physics update code
    void Update() {

    } 

    // physics update code
	void FixedUpdate () {
        // Borrowed from a lynda advanced unity 2d tutorial
        var val = Input.GetAxis("Horizontal");
        rigid2d.velocity = new Vector2(speed * val, rigid2d.velocity.y);

        // This block turns character. Borrowed from an official unity tutorial entitled "creating basic platformer game"
        if (val > 0 && !right) {
            Flip();
        } else if (val < 0 && right) {
            Flip();
        }

        if (Input.GetButtonDown("Jump")) {
            Debug.Log("jump");  // testing
            rigid2d.AddForce(jump, ForceMode2D.Impulse); // gives vertical movement based on pub variable
        }
	}

    // This ftn was borrowed from the same official tutorial named above
    void Flip() {
        right = !right; // sets right to the opposite of what it's been set at
        Vector3 theScale = transform.localScale; // gets current direction 
        theScale.x *= -1; // flips character
        transform.localScale = theScale; // sets current direction
    }

    // setting text in top left corner
    void SetLivesText() {
        livesText.text = "Lives: " + lives.ToString();
        // if death then lives--
        // if lives == 0 then game over
    }
}
