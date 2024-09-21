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
        private bool canAttack = true;  // ������ �������� ���θ� ��Ÿ���� ����

        public void EnterState(MonsterController controller)
        {
            if (canAttack) // ������ ������ ���� ���� ����
            {
                controller.animator.SetTrigger("isAttack");
                controller.StartCoroutine(AttackDelay(controller));  // ������ ó��
            }
        }

        public void UpdateState(MonsterController controller)
        {
            if (controller.isTracing)
            {
                controller.isTracing = false; // ���� �߿� ���� ����
            }
        }

        public void ExitState(MonsterController controller)
        {
            // ���� ���� ��, �ʿ��� ���� (������ �����)
        }

        // ���� �����̸� ó���ϴ� �ڷ�ƾ
        private IEnumerator AttackDelay(MonsterController controller)
        {
            canAttack = false;  // ���� �����̰� ���� ������ �߰� ���� �Ұ�
            yield return new WaitForSeconds(controller.attackDelay);  // 2�� ���� ������
            canAttack = true;   // ���� �����̰� ������ �ٽ� ���� ����
            controller.TransitionState(controller.chaseState);  // ���� �� ���� ���·� ���ư�
        }
    }



