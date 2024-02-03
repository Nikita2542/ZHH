using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;


public class Recoil_Weapon : MonoBehaviour
{
    class Bullet
    {
        public float time;
        public Vector3 initialPosition;
        public Vector3 initialVelocity;
        public TrailRenderer tracer;
    }

    public bool isFiring = false;
    public int fireRate = 25;
    public float bulletSpeed = 1000.0f;
    public float bulletDrop = 0.0f;
    
    public VisualEffect muzzleFlash;

    public float PreheatTime;
    public Slider sliderPreheat;
    public float Time;
    public bool boolPreheat;
    public float vmestoTime;
    public Image[] imagePreheat; 

    public ParticleSystem hitEffect;
    public TrailRenderer tracerEffect;

    public Transform raycastOrigin;
    public Transform raycastDestination;

    public Rigidbody rigidBody;
    public float recoilForce;

    
    public Animator anim;

    public Turret turret;


    Ray ray;
    RaycastHit hitInfo;
    float accumulatedTime;
    List<Bullet> bullets = new List<Bullet>();
    float maxLifeTime = 3.0f;

    private void Start()
    {
        vmestoTime = PreheatTime;
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

    public void UpdateBullets(float deltaTime)
    {
        SimulateBullets(deltaTime);
        DestroyBullets();
        anim.SetBool("Recoil", isFiring);
        anim.SetBool("InteractableActive", isFiring);
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
        bullets.RemoveAll(bullet => bullet.time > maxLifeTime);
    }

    void RaycastSegment(Vector3 start, Vector3 end, Bullet bullet)
    {
        Vector3 direction = end - start;
        float distance = direction.magnitude;   
        ray.origin = start;
        ray.direction = direction;
        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            if(bullet.tracer != null)
            {
                bullet.tracer.transform.position = hitInfo.point;
                bullet.time = maxLifeTime;
            }
            
        }
        else
        {
            if (bullet.tracer != null)
            {
                bullet.tracer.transform.position = end;
            }
                
        }
    }

    private void FireBullet()
    {    
        ApplyForce(ray.direction * recoilForce);
        muzzleFlash.Play();
        
        Vector3 velocity =  raycastOrigin.forward.normalized * bulletSpeed;
        
        var bullet = CreateBullet(raycastOrigin.position, velocity);  
        bullets.Add(bullet);       
    }

    public void StopFiring()
    {
        isFiring = false;
    }

    public void ApplyForce(Vector3 force)
    {
        rigidBody.AddForce(force, ForceMode.VelocityChange);
    }
    public void UpdatePreheat(float deltatime)
    {
        
        if (boolPreheat == false)
        {
            if (isFiring)
            {
                if (Time < PreheatTime)
                {
                    Time += deltatime;
                    sliderPreheat.maxValue = PreheatTime;
                    sliderPreheat.value = Time;
                }
            }
            if (isFiring == false)
            {
                if (Time > 0)
                {
                    Time -= deltatime;
                    sliderPreheat.maxValue = PreheatTime;
                    sliderPreheat.value = Time;
                }
            }
        }
        
        if(Time >= PreheatTime)
        {
            boolPreheat = true;
            isFiring = false;
        }
        if (boolPreheat)
        {
           
            if (vmestoTime > 0)
            {
                imagePreheat[0].color = Color.red;
                imagePreheat[1].color = Color.red;
                vmestoTime -= deltatime;
                sliderPreheat.maxValue = PreheatTime;
                sliderPreheat.value = vmestoTime;
            }
            if (vmestoTime <= 0)
            {
                imagePreheat[0].color = Color.black;
                imagePreheat[1].color = Color.black;
                
                Time = 0.0f;
                vmestoTime = PreheatTime;

                boolPreheat = false;
            }
        }
       
    }
}
