using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawn : MonoBehaviour
{
    public KeyCode firtGun;
    public KeyCode twoGun;
    public GameObject[] gunPrefabs;
    [HideInInspector] public GameObject gunActive;
    [HideInInspector] public Transform parent;

    public Transform target_turret;
    public Transform raycastDestination_weapon;
    public Rigidbody rigitBody_weapon;

    public void Start()
    {
        parent = transform;
    }
    public void Update()
    {
        bool isFirst = Input.GetKeyDown(firtGun);
        if(isFirst)
        {
            if (gunActive) { Destroy(gunActive); }
            gunActive = Instantiate(gunPrefabs[0], parent);
            gunActive.GetComponent<Turret>().target = target_turret;
            gunActive.GetComponent<Recoil_Weapon>().raycastDestination = raycastDestination_weapon;
            gunActive.GetComponent<Recoil_Weapon>().rigidBody = rigitBody_weapon;
        }

        bool isTwo = Input.GetKeyDown(twoGun);
        if (isTwo)
        {
            if (gunActive) { Destroy(gunActive); }
            gunActive = Instantiate(gunPrefabs[1], parent);
            gunActive.GetComponent<Turret>().target = target_turret;
            gunActive.GetComponent<Recoil_Weapon>().raycastDestination = raycastDestination_weapon;
            gunActive.GetComponent<Recoil_Weapon>().rigidBody = rigitBody_weapon;
        }
    }
}
