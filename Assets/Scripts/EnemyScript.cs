using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour {
    private bool hasSpawn;
    private MoveScript moveScript;
    private WeaponScript[] weapons;
    private Collider2D colliderComponent;
    private SpriteRenderer rendererComponent;

    void Awake()
    {
        //Retrieve the weapon only once
        weapons = GetComponentsInChildren<WeaponScript>();

        //Retrieve scripts to disable when not spawn
        moveScript = GetComponent<MoveScript>();

        colliderComponent = GetComponent<Collider2D>();

        rendererComponent = GetComponent<SpriteRenderer>();
    }

    // 1 - Disable everything
    void Start()
    {
        hasSpawn = false;

        // Disable everything
        // -- collider
        colliderComponent.enabled = false;
        // -- Moving
        moveScript.enabled = false;
        // -- Shooting
        foreach(WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }
    }

	// Update is called once per frame
	void Update () {
        // 2 - Check if the enemy has spawned
        if (hasSpawn == false)
        {
            if (rendererComponent.IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else {
            // Auto-fire
            foreach (WeaponScript weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                }
            }

            // 4 - Out of the camera ? Destroy the game object
            if(rendererComponent.IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
	}

    // 3 Activate itself.
    private void Spawn()
    {
        hasSpawn = true;

        //Enable everything
        // -- collider
        colliderComponent.enabled = true;
        // -- Moving
        moveScript.enabled = true;
        // -- Shooting
        foreach(WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}
