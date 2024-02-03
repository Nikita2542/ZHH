using Cinemachine;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [HideInInspector]public CharacterAiming characterAiming;
    [HideInInspector] public Cinemachine.CinemachineImpulseSource cameraShake;
     public Animator rigController;

    public Vector2[] recoilPatern;
    public float duraction;
    public float recoilModifier = 1.0f;

    float verticalRecoil;
    float horizontalRecoil;
    float time;
    int index;

    private void Awake()
    {
        cameraShake = GetComponent<CinemachineImpulseSource>();
        
    }

    public void Reset()
    {
        index = 0;
    }

    int NextIndex(int index)
    {
        return(index + 1) % recoilPatern.Length;
    }
    public void GenerateRecoil(string weaponName)
    {
        time = duraction;

        cameraShake.GenerateImpulse(Camera.main.transform.forward);

        horizontalRecoil = recoilPatern[index].x;
        verticalRecoil = recoilPatern[index].y;

        index = NextIndex(index);
        rigController.Play("weapon_recoil_" + weaponName, 0, 0.0f);
    }
    public void Update()
    {
        if(time > 0)
        {
            characterAiming.yAxis.Value -= (((verticalRecoil/100) * Time.deltaTime) / duraction) * recoilModifier;
            characterAiming.xAxis.Value -= (((horizontalRecoil / 100) * Time.deltaTime) / duraction) * recoilModifier;
            time -= Time.deltaTime;     
        }      
    }
}
