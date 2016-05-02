using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    Animator anim;
    Rigidbody2D rigi;
    public float speed = 0.2f;
    public float intr_length = 0.05f;
    public LayerMask To_interact_with;
    public bool canMove;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {

        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");

        bool input_fire1 = Input.GetButtonDown("Fire1");

        bool is_walking = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;

        if (!canMove)
        {
            is_walking = false;
        }

        anim.SetBool("is_walking", is_walking);

        if (is_walking)
        {
            anim.SetFloat("directionX", input_x);
            anim.SetFloat("directionY", input_y);

            InteractionMover(input_x, input_y);

            Vector2 movement_vector = new Vector2(input_x, input_y).normalized;

            movement_vector[0] = movement_vector[0] * speed;
            movement_vector[1] = movement_vector[1] * speed;

            rigi.velocity = movement_vector;
        }
        else
        {
            rigi.velocity = new Vector2(0, 0);
        }

        if (input_fire1)
        {
            if (!canMove) { return; }

            Interact();
        }
		// Update Order in layer

    }

    void Interact () {
        Debug.Log("Interact");
        Transform SamCentrePoint = transform.FindChild("SamCentrePoint");
        Transform SamTowardPoint = transform.FindChild("SamTowardPoint");

        Vector2 SamCentre = new Vector2(SamCentrePoint.position.x, SamCentrePoint.position.y);
        Vector2 SamToward = new Vector2(SamTowardPoint.position.x, SamTowardPoint.position.y);
        RaycastHit2D interaction = Physics2D.Raycast(SamCentre, SamToward - SamCentre, intr_length, To_interact_with);
        Debug.DrawLine(SamCentre, SamToward, Color.red);
        if (interaction.collider != null)
        {
            Debug.Log(interaction.collider);
            Interactable interacted = interaction.collider.GetComponent<Interactable>();
            interacted.intr_response();
            
        }
        if (interaction.collider == null)
        {
            Debug.Log("Daww");
        }
    }

    void InteractionMover (float input_x, float input_y) {
        Transform SamCentrePoint = transform.FindChild("SamCentrePoint");
        Transform SamTowardPoint = transform.FindChild("SamTowardPoint");
        Vector2 SamNewToward = new Vector2(SamCentrePoint.position.x + (input_x * intr_length), SamCentrePoint.position.y + (input_y * intr_length));
        SamTowardPoint.transform.position = SamNewToward;
    }


}