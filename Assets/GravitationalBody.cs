using UnityEngine;
using System.Collections.Generic;
using System.Collections;
 
[RequireComponent(typeof(Rigidbody2D))]
public class GravitationalBody : MonoBehaviour {
 
    public float maxDistance;
    public float startingMass;
    public Vector2 initialVelocity;

    public bool invert;

    Rigidbody2D rigidbody2D;
 
    //I use a static list of bodies so that we don't need to Find them every frame
    static List<Rigidbody2D> attractableBodies = new List<Rigidbody2D>();
 
    void Start() {
 
        SetupRigidbody2D();
        //Add this gravitational body to the list, so that all other gravitational bodies can be effected by it
        attractableBodies.Add (rigidbody2D);
        maxDistance = 50*(gameObject.transform.localScale.x);
 
    }
 
    void SetupRigidbody2D() {
        rigidbody2D = GetComponent<Rigidbody2D>();
 
        rigidbody2D.gravityScale = 0f;
        rigidbody2D.drag = 0f;
        rigidbody2D.angularDrag = 0f;
        rigidbody2D.mass = startingMass;
        rigidbody2D.velocity = initialVelocity;
 
    }
 
    void FixedUpdate() {
 
        foreach (Rigidbody2D otherBody in attractableBodies) {
 
            if (otherBody == null)
                continue;
 
            //We arn't going to add a gravitational pull to our own body
            if (otherBody == rigidbody2D)
                continue;
 
            otherBody.AddForce( (invert? -1 : 1) * DetermineGravitationalForce(otherBody));
 
        }
 
    }
 
    Vector2 DetermineGravitationalForce(Rigidbody2D otherBody) {
 
        Vector2 relativePosition = rigidbody2D.position - otherBody.position;
   
        float distance = Mathf.Clamp (relativePosition.magnitude, 0, maxDistance);
 
        //the force of gravity will reduce by the distance squared
        float gravityFactor = 1f - (Mathf.Sqrt(distance) / Mathf.Sqrt(maxDistance));
 
        //creates a vector that will force the otherbody toward this body, using the gravity factor times the mass of this body as the magnitude
        Vector2 gravitationalForce = relativePosition.normalized * (gravityFactor * rigidbody2D.mass);
 
        return gravitationalForce;
       
    }

    public void AddToGravityList(Rigidbody2D other)
    {
        Debug.Log(other + " added");
        attractableBodies.Add(other);
    }
   
}
