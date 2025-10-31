using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponChangeBeginner : MonoBehaviour
{
    public TwoBoneIKConstraint leftHand;
    public TwoBoneIKConstraint rightHand;
    public RigBuilder rig;
    public Transform leftTargetWeapon1;
    public Transform rightTargetWeapon1;
    public Transform leftTargetWeapon2;
    public Transform rightTargetWeapon2;
    public Transform leftTargetWeapon3;
    public Transform rightTargetWeapon3;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
            weapon3.SetActive(false);
            leftHand.data.target = leftTargetWeapon1;
            rightHand.data.target = rightTargetWeapon1;
            rig.Build();
        }
		if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
		{
			weapon1.SetActive(false);
			weapon2.SetActive(true);
			weapon3.SetActive(false);
			leftHand.data.target = leftTargetWeapon2;
			rightHand.data.target = rightTargetWeapon2;
			rig.Build();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
		{
			weapon1.SetActive(false);
			weapon2.SetActive(false);
			weapon3.SetActive(true);
			leftHand.data.target = leftTargetWeapon3;
			rightHand.data.target = rightTargetWeapon3;
			rig.Build();
		}
	}
}
