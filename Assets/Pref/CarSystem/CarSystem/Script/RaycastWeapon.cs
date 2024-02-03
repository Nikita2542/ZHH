using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    class Bullet
    {
        public float time;
        public Vector3 initialPosition;
        public Vector3 initialVelocity;
        public TrailRenderer tracer;
    }
    public ActivateWeapon.WeaponSlot weaponSlot;
    public ActivateWeapon activateWeapon;
    [Header("Weapon")]
    [Tooltip("Назови это оружие")]
    public string weaponName;
    [Space(10)]
    [Tooltip("Скорострельность")]
    public int fireRate = 25;
    [Tooltip("Урон")]
    public int damage = 25;
    [Tooltip("Максимальная боезапас")]
    public int clipSize;
    [Tooltip("Пули")]
    public int ammoCount;
    [Space(5)]
    [Tooltip("Скорость пули")]
    public float bulledSpeed = 1000.0f;
    [Tooltip("Вес пули")]
    public float bulletDrop = 0.0f;
    [Space(5)]
    public float verticalArm = 0.0f;
    public float distance = 0.0f;
    [Space(2)]
    public float verticalArmScoup = 0.0f;
    public float distanceScoup = 0.0f;
    [Space(10)]
    [Tooltip("Дульное пламя")]
    public ParticleSystem muzzleFlash;
    [Tooltip("Эфект от попадания")]
    public ParticleSystem hitEffect;
    [Tooltip("Эфект трейсера от пули")]
    public TrailRenderer tracerEffect;
    [Tooltip("Начальное положение пули")]
    public Transform raycastOrigin;

    Ray ray;
    RaycastHit hitInfo;
    float accumulatedTime;
    List<Bullet> bullets = new List<Bullet>();
    float maxLifetime = 3.0f;

    public Transform raycastDestination;
    [HideInInspector] public bool isFiring = false;
    [HideInInspector] public WeaponRecoil recoil;
    [HideInInspector] public WeaponItem weaponItem;


    private void Awake()
    {
        recoil = GetComponent<WeaponRecoil>();
        weaponItem =  GetComponent<WeaponItem>();
    }

    Vector3 GetPosition(Bullet bullet)
    {
        Vector3 gravity = Vector3.down * bulletDrop;
        return (bullet.initialPosition) + (bullet.initialVelocity * bullet.time) + (0.5f * gravity * bullet.time * bullet.time);
    }

    Bullet CreateBullet(Vector3 position, Vector3 velocity)
    {
        Bullet bullet = new Bullet();
        bullet.initialPosition = position;
        bullet.initialVelocity = velocity;
        bullet.time = 0.0f;
        bullet.tracer = Instantiate(tracerEffect, position, Quaternion.identity);
        bullet.tracer.AddPosition(position);
        return bullet;
    }
    public void StartFiring()
    {
        isFiring = true;
        accumulatedTime = 0.0f;
        recoil.Reset();
        FireBullet();

    }

    public void UpdateFiring(float deltaTime)
    {
        accumulatedTime += deltaTime;
        float fireInterval = 1.0f / fireRate;
        while (accumulatedTime >= 0.0f)
        {
            FireBullet();
            accumulatedTime -= fireInterval;
        }
    }

    public void UpdateBullet(float deltaTime)
    {
        SimulateBullets(deltaTime);
        DestroyBullets();
    }

    void SimulateBullets(float deltaTime)
    {
        bullets.ForEach(bullet =>
        {
            Vector3 p0 = GetPosition(bullet);
            bullet.time += deltaTime;
            Vector3 p1 = GetPosition(bullet);
            RaycastSegment(p0, p1, bullet);
        });
    }

    void DestroyBullets()
    {
        bullets.RemoveAll(bullet => bullet.time >= maxLifetime);
    }

    void RaycastSegment(Vector3 start, Vector3 end, Bullet bullet)
    {
        Vector3 direction = end - start;
        Vector3 directionSky = activateWeapon.aimLookAt.position;
        float distance = direction.magnitude;
        ray.origin = start;
        ray.direction = direction;
        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);

            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            bullet.tracer.gameObject.SetActive(true);
            bullet.tracer.transform.position = hitInfo.point;
            bullet.time = maxLifetime;

            var hitBox = hitInfo.collider.GetComponent<Hitbox_mutantBlue>();
            if (hitBox)
            {
                hitBox.OnRaycastHit(this, ray.direction);
                
                    activateWeapon.enemyHitUI = Instantiate(activateWeapon.enemyHitUIPrefab, activateWeapon.canvas);
                    Destroy(activateWeapon.enemyHitUI, 0.3f);
               
                
            }
        }
        else 
        {
            bullet.tracer.gameObject.SetActive(false);
        }
        
    }
    private void FireBullet()
    {
        if(ammoCount <= 0)
        {
            return;
        }
        ammoCount--;

        muzzleFlash.Emit(1);

        Vector3 velosity = (raycastDestination.position - raycastOrigin.position).normalized * bulledSpeed;
        var bullet = CreateBullet(raycastOrigin.position, velosity);
        bullets.Add(bullet);

        recoil.GenerateRecoil(weaponName);
    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
