using QFramework;
using Config;
namespace FightFSM.States
{   
    
    //���˻غ�
    public class FightEnemyTurn : AbstractState<FightState, FightFsm>
    {

        public FightEnemyTurn(FSM<FightState> fsm, FightFsm target) : base(fsm, target)
        {
        }

        protected override bool OnCondition()
        {
            return mFSM.CurrentStateId == FightState.Player || mFSM.CurrentStateId==FightState.Win ||  mFSM.CurrentStateId==FightState.Loss ;
        }
        protected override void OnEnter()
        {

            //// ��ʼһ���µ�Э����������˵Ļغϡ�
            //StartCoroutine(HandleEnemyTurn());

        }

        protected override void OnExit() {
            //������ҷ���
            //PlayerActionManager.Instance.ResetCurrentBlock();

            //FightFSM.Instance.ChangeType(FightType.Player);

        }
    }
   
}