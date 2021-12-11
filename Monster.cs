using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    public static List<Monster> Items = new List<Monster>();

    private void Awake()
    {
        Items.Add(this);

    }

    Animator animator;
    Coroutine fsmHandle;
    IEnumerator Start()
    {
        //while (StageManager.Instance.gameState != GameStateType.Playing)
        //    yield return null;

        animator = GetComponentInChildren<Animator>();

        player = Player.instance;

        CurrentFSM = IdleFSM;

        while (true) //FSM�� ������ �ݺ��ؼ� �����ϴ� �κ�
        {
            {
                var previousFSM = CurrentFSM;

                fsmHandle = StartCoroutine(CurrentFSM());

                if (fsmHandle == null && previousFSM == CurrentFSM) //�ٷ� ���� FSM�� ������ FSM�� ������ �� ������ ���� ���� �α׸� �ﵵ��
                    yield return null;

                while (fsmHandle != null)
                    yield return null;
            }
        }
    }

    Func<IEnumerator> m_currentFSM;
    protected Func<IEnumerator> CurrentFSM
    {
        get { return m_currentFSM; }
        set
        {
            m_currentFSM = value;
            fsmHandle = null;
        }
    }
    //��ȯ���� IEnumerator�� �ֱ� ������ action�� ����� �� ����.. Function�� ����Ѵ�.
    protected Player player;
    public float detectRange = 20;
    public float attackRange = 10;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    IEnumerator IdleFSM()
    {
        PlayAnimation("Idle");

        while (Vector3.Distance(transform.position, player.transform.position) > detectRange)//���ѷ��� ���� ����! 
        {
            yield return null;
        }
        CurrentFSM = ChaseFSM;
    }

    public float speed = 34;
    protected IEnumerator ChaseFSM()
    {
        PlayAnimation("Walk");
        while (true)
        {
            Vector3 toPlayerDriection = player.transform.position - transform.position;
            toPlayerDriection.Normalize();
            transform.forward = toPlayerDriection;
            transform.Translate(toPlayerDriection * speed * Time.deltaTime, Space.World);

            if ((Vector3.Distance(transform.position, player.transform.position) < attackRange))
            {
                SelectAttackType();

                yield break;
            }
            yield return null;
        }
    }

    virtual protected void SelectAttackType()
    {
        CurrentFSM = AttackFSM;
    }

    public float attackTime = 1;//�����ϰ� �ִ� �ð�
    public float attackApplyTime = 0.3f; //������ ������ ����Ǵ�? �����Ǵ� �ð�!
    public int power = 10;
    protected IEnumerator AttackFSM()
    {
        PlayAnimation("Attack");
        yield return new WaitForSeconds(attackApplyTime);
        if (Vector3.Distance(player.transform.position, transform.position) < attackRange)
        {
            //player.TakeHit(power);
        }
        yield return new WaitForSeconds(attackTime - attackApplyTime);
        CurrentFSM = ChaseFSM;
    }

    public float hp = 100;

    public void TakeHit(float damage)
    {
        if (hp <= 0)
            return;

        hp -= damage;
        print($"{hp}");
        if (fsmHandle != null)
            StopCoroutine(fsmHandle);

        CurrentFSM = TakeHitFSM;
    }

    public float takeHitTime = 0.3f;

    private IEnumerator TakeHitFSM()
    {
        PlayAnimation("GetHit");
        yield return new WaitForSeconds(takeHitTime);

        if (hp > 0)
            CurrentFSM = IdleFSM;
        else
            CurrentFSM = DeathFSM; //���� �� �ǰݸ�� 1ȸ �÷��� �� �׵���
    }
    public float deathTime = 0.5f;
    private IEnumerator DeathFSM()
    {
        PlayAnimation("Death");

        Items.Remove(this);

        yield return new WaitForSeconds(deathTime);

        Destroy(gameObject, 1.5f);
    }

    protected void PlayAnimation(string clipName)
    {
        animator.Play(clipName, 0, 0);
        //�ִϸ������� ����� �̸�(Ŭ���� �̸����� �ٸ�), �ִϸ����� ���̾��� �ε���(�ε����� 0���� ����),  ������ġ? ��ֶ������Ÿ��
    }
}
