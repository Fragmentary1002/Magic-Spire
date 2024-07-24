using UnityEngine;
using UnityEditor;
using QFramework;
using FightFSM.States;
using Config;

namespace FightFSM
{
    /// <summary>
    /// ս�������� ״̬ģʽ ����ս��״̬���л� ������FightType�л�
    /// </summary>
    public class FightFsm : MonoSingleton<FightFsm>
    {
        private FSM<FightState> _fsm = new FSM<FightState>();

        private void Start()
        {
            _fsm.AddState(FightState.RoleInit, new FightRoleInit(_fsm, this));
            _fsm.AddState(FightState.BattleInit, new FightBattleInit(_fsm, this));
            _fsm.AddState(FightState.Player, new FightPlayerTurn(_fsm, this));
            _fsm.AddState(FightState.Enemy, new FightEnemyTurn(_fsm, this));
            _fsm.AddState(FightState.Win, new FightWin(_fsm, this));
            _fsm.AddState(FightState.Loss, new FightLoss(_fsm, this));
            
            _fsm.StartState(FightState.Player);
        }

        private void OnGUI()
        {
            _fsm.OnGUI();
        }

        protected override void OnDestroy()
        {
            _fsm.Clear();
        }

        public void ChangeType(FightState fightState)
        {
            _fsm.ChangeState(fightState);
        }

        
    }

}