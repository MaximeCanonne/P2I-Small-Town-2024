using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Interactive
{
    private Vector3 directionVector;
    private Transform myTransform; // Position du PNJ
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds; // Zone de collision présentée au PNJ
// Permettre au PNJ de repartir dans une autre direction au bout d'un certain temps
    private bool isMoving;
    public float minMoveTime;
    public float maxMoveTime;
    private float moveTimeSeconds;
    public float minWaitTime;
    public float maxWaitTime;
    private float waitTimeSeconds;

    // Start is called before the first frame update
    void Start()
    {
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (isMoving)
        {
            moveTimeSeconds -= Time.deltaTime;
            if (moveTimeSeconds <= 0)
            {
                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
                isMoving = false;
            }
        }
        if (!playerInRange)
        {
            Move();
        }
        else
        {
            waitTimeSeconds -= Time.deltaTime;
            if (waitTimeSeconds <= 0)
            {
                ChooseDifferentDirection();
                isMoving = true;
                waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
            }
        }
    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0; // Éviter le risque de parcourir la boucle while indéfiniment
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp)) // Vérifier si le déplacement du PNJ est à l'intérieur de la zone de collision
        {
            myRigidbody.MovePosition(temp);
        }
        else // Quand le PNJ touche la bordure de la zone de collision, il change de direction
        {
            ChangeDirection();
        }
    }
    
    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                // Marcher vers la droite
                directionVector = Vector3.right;
                break;
            case 1:
                // Marcher vers le haut
                directionVector = Vector3.up;
                break;
            case 2:
                // Marcher vers la gauche
                directionVector = Vector3.left;
                break;
            case 3:
                // Marcher vers le bas
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation() // Attribuer aux float MoveX et MoveY du PNJ (Dans l'animateur sur Unity) les valeurs du vecteur "directionVector"
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ChooseDifferentDirection();
    }
}
