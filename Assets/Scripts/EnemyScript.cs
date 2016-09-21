using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour {
    private WeaponScript weapon;

    void Awake()
    {
        //Retrieve the weapon only once
        weapon = GetComponent<WeaponScript>();
    }

	// Update is called once per frame
	void Update () {
	    // Auto-fire
        if(weapon!=null && weapon.CanAttack)
        {
            weapon.Attack(true);
        }
	}
}
