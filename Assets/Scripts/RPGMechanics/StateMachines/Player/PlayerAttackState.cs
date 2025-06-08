using Unity.VisualScripting;

using UnityEngine;

namespace RPGMechanics.StateMachines.Player
{
    public class PlayerAttackState : PlayerBaseState
    {
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        public PlayerStateMachine PlayerStateMachine { get; set; }

        private float attackRange = 2.0f;
        private float attackRadius = 0.5f;
        private int attackDamage = 10;
        private LayerMask hitLayerMask = LayerMask.GetMask("Enemy");
        private RaycastHit hit;


        public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            PlayerStateMachine = stateMachine;
        }

        public override void Enter()
        {
            // Debug.Log("Attack State Entered");
            PlayerStateMachine.Animator.SetBool(IsAttacking, true);
        }

        public override void Tick(float deltaTime)
        {
            // Add logic for attacking
            //Debug.Log("Attack State Tick");
            Attack();

            // TODO: A next function would be so much better than this
            PlayerStateMachine.SwitchState(new PlayerFreeLookState(PlayerStateMachine));
        }

        public override void Exit()
        {
            // Debug.Log("Attack State Exit");
            PlayerStateMachine.InputReader.IsAttacking = false;
            PlayerStateMachine.Animator.SetBool(IsAttacking, false);
        }

        public void Attack()
        {
            Transform attackOrigin = PlayerStateMachine.transform;
            Vector3 direction = attackOrigin.forward;

            var success = Physics.SphereCast(attackOrigin.position, attackRadius, direction, out hit,
                attackRange,
                hitLayerMask);

            Debug.DrawRay(attackOrigin.position, direction * attackRange, Color.red, 1.0f);

            if (success)
            {
                Debug.Log($"Hit: {hit.collider.name}");
                var enemy = hit.collider.GetComponent<Characters.Enemies.Enemy>();
                if (enemy)
                {
                    enemy.TakeDamage(attackDamage);
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (!PlayerStateMachine) { return; }
            Transform attackOrigin = PlayerStateMachine.transform;
            Gizmos.DrawWireSphere(attackOrigin.position, attackRange);
        }
    }
}