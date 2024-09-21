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
    bool isHurt = false;
    public void EnterState(MonsterController controller)
    {
        if (!isHurt)
        {
            controller.animator.SetTrigger("isHurt");
            controller.StartCoroutine(HurtDelay(controller));
        }
    }
    public void UpdateState(MonsterController controller)
    {
        if(controller.isTracing)
        {
            controller.isTracing = false;
        }
    }

    public void ExitState(MonsterController controller)
    {

    }
    public IEnumerator HurtDelay(MonsterController controller)
    {
        isHurt = true;
        yield return CoroutineCache.waitForSeconds(0.15f);
        isHurt = false;
        if (controller.isTracing)
        {
            controller.TransitionState(controller.chaseState);
        }
        else
        {
            controller.TransitionState(controller.moveState);
        }


    }
}
public class ChaseState:IMonsterState
{
    public void EnterState(MonsterController controller)
    {
        controller.animator.SetBool("isMove", true);
        
    }
    public void UpdateState(MonsterController controller)
    {
        if(controller.isTracing)
        {
            controller.TracePlayer();
        }
    }

    public void ExitState(MonsterController controller)
    {

    }
}

    public class AttackState : IMonsterState
    {
        private bool canAttack = true;  // 공격이 가능한지 여부를 나타내는 변수

        public void EnterState(MonsterController controller)
        {
            if (canAttack) // 공격이 가능할 때만 공격 시작
            {
                controller.animator.SetTrigger("isAttack");
                controller.StartCoroutine(AttackDelay(controller));  // 딜레이 처리
            }
        }

        public void UpdateState(MonsterController controller)
        {
            if (controller.isTracing)
            {
                controller.isTracing = false; // 공격 중엔 추적 중지
            }
        }

        public void ExitState(MonsterController controller)
        {
            // 상태 종료 시, 필요한 로직 (없으면 비워둠)
        }

        // 공격 딜레이를 처리하는 코루틴
        private IEnumerator AttackDelay(MonsterController controller)
        {
            canAttack = false;  // 공격 딜레이가 끝날 때까지 추가 공격 불가
            yield return new WaitForSeconds(controller.attackDelay);  // 2초 공격 딜레이
            canAttack = true;   // 공격 딜레이가 끝나면 다시 공격 가능
            controller.TransitionState(controller.chaseState);  // 공격 후 추적 상태로 돌아감
        }
    }



