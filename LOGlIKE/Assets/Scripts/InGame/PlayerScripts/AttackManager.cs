using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
     float delayTime = 0.44f;
    [SerializeField] WeaponManager weaponManager;
    [SerializeField] AudioClip weaponSound;
    private PlayerAnimationController animeController;
    private bool isAttacking;
   public float PlayerPower
    { get; set; }

    void Start()
    {
       animeController = GetComponent<PlayerAnimationController>();
        PlayerPower = PlayerManager.Instance.PlayerPower;
       isAttacking = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X) && !isAttacking)
        {
            isAttacking = true;
            
            StartCoroutine(NormalAttack());
        }
        
    }

    private IEnumerator NormalAttack()
    {
     
        animeController.TriggerAttackAnimation();
        weaponManager.AttackState = true;
        yield return CoroutineCache.waitForSeconds(delayTime);
        SoundManager.Instance.Sound(weaponSound);
        
        isAttacking = false;

    }
       
    
    
}