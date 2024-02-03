using Cinemachine;

using UnityEngine;

public class CharacterAiming : MonoBehaviour
{
    public Transform cameraLookAt;
    [Header("Axis")]
    public Cinemachine.AxisState xAxis;
    public Cinemachine.AxisState yAxis;
    [Header("Pricel")]
    public Transform pricelPoint;

    public bool isAiming;
    Animator animator;
    ActivateWeapon activateWeapon;
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    int isAimingParam = Animator.StringToHash("isAiming");

    private void Start()
    {
        animator = GetComponent<Animator>();
        isAiming = false;
        activateWeapon = GetComponent<ActivateWeapon>();
        
    }
    private void Update()
    {
        var weapon = activateWeapon.GetWeapon(activateWeapon.activeWeaponIndex);

        xAxis.Update(Time.fixedDeltaTime);
        yAxis.Update(Time.fixedDeltaTime);

        cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);

        isAiming = Input.GetMouseButton(1);
       
        animator.enabled = true;
        animator.SetBool(isAimingParam, isAiming);
        PricelPointEnebled();
        
        
        if(weapon)
        {
            if (isAiming)
            {
                var _3dPerson = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
                _3dPerson.VerticalArmLength = weapon.verticalArmScoup;
            }
            else
            {
                var _3dPerson = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
                _3dPerson.VerticalArmLength = weapon.verticalArm;
            }
            weapon.recoil.recoilModifier = isAiming ? 0.3f : 1.0f;

        }
    }
  

    void PricelPointEnebled()
    {
        if(isAiming)
        {
            pricelPoint.gameObject.SetActive(true);
        }
        else
        {
            pricelPoint.gameObject.SetActive(false);
        }
    }
}
