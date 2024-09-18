using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public interface IMonsterState
{
    void EnterState(MonsterController controller);
    void UpdateState(MonsterController controller);
    void ExitState(MonsterController controller);
}

public class MoveState:IMonsterState
{
    private Coroutine moveDirectionCoroutine;
    public void EnterState(MonsterController controller)
    {
        controller.animator.SetBool("isMove", true);
        moveDirectionCoroutine = controller.StartCoroutine(ChangeState(controller));
    }
    public void UpdateState(MonsterController controller)
    {
        controller.Moving();
    }
   
    public void ExitState(MonsterController controller)
    {
        controller.StopCoroutine(moveDirectionCoroutine);
    }
    private IEnumerator ChangeState(MonsterController controller)
    {
        while (true)
        {
            controller.detectionMove = Random.Range(-1, 2);

            if (controller.detectionMove == 0)
            {
                controller.animator.SetBool("isMove", false);
            }
            else
            {
                controller.animator.SetBool("isMove", true);
            }

            yield return CoroutineCache.waitForSeconds(2.0f);
        }
    }
}
public class HurtState:IMonsterState
{
    public void EnterState(MonsterController controller)
    {
        controller.animator.SetTrigger("isHurt");
    }
    public void UpdateState(MonsterController controller)
    {
    }

    public void ExitState(MonsterController controller)
    {

    }
}
public class ChaseState:IMonsterState
{
    public void EnterState(MonsterController controller)
    {
        controller.animator.SetBool("isMove", true);
        controller.TracePlayer();
    }
    public void UpdateState(MonsterController controller)
    {
        
    }

    public void ExitState(MonsterController controller)
    {

    }
}
public class AttackState : IMonsterState
{
    public void EnterState(MonsterController controller)
    {
        controller.animator.SetTrigger("isAttack");
    }
    public void UpdateState(MonsterController controller)
    {
    }

    public void ExitState(MonsterController controller)
    {

    }
}
   
