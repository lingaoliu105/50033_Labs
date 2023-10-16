using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableSM/Actions/FireAttack")]
public class FireAttackAction : Action
{
    public int maxPrefabInScene = 3;
    public float impulseForce = 1;
    public float degree = 45;
    public GameObject attackPrefab;
    // a scriptable object updated by PlayerMovement / PlayerController to store current Mario's facing
    public BoolVariable marioFaceRight;

    public override void Act(StateController controller)
    {
        GameObject[] instantiatedPrefabsInScene = GameObject.FindGameObjectsWithTag(attackPrefab.tag);
        if (instantiatedPrefabsInScene.Length < maxPrefabInScene)
        {
            // instantiate it where controller (mario) is
            GameObject x = Instantiate(attackPrefab, controller.transform.position, Quaternion.identity);

            // Get the Rigidbody component of the instantiated object
            Rigidbody2D rb = x.GetComponent<Rigidbody2D>();
            // Check if the Rigidbody component exists
            if (rb != null)
            {
                // compute direction vector
                Vector2 direction = CalculateDirection(degree, marioFaceRight.Value);
                // Apply a rightward impulse force to the object
                rb.AddForce(direction * impulseForce, ForceMode2D.Impulse);
            }

        }

    }

    public Vector2 CalculateDirection(float degrees, bool isFacingRight)
    {
        // Convert degrees to radians
        float radians = degrees * Mathf.Deg2Rad;

        // Calculate the direction vector
        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);

        // If the object is facing left, invert the x-component of the direction
        if (!isFacingRight)
        {
            x = -x;
        }

        return new Vector2(x, y);
    }
}
