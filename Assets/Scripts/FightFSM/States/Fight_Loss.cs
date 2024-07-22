using QFramework;
using Config;

namespace FightFSM.States
{
    //ս��ʧ��
    public class FightLoss : AbstractState<FightState, FightFsm>
    {
        public FightLoss(FSM<FightState> fsm, FightFsm target) : base(fsm, target)
        {
        }

        protected override bool OnCondition()
        {
            return mFSM.CurrentStateId == FightState.Player;
        }

        protected override void OnEnter()
        {
            //// ���ս��û��ʤ����winΪfalse�����򼤻���Ϸ������UI���  
            //if (!win)
            //    gameover.SetActive(true);

        }
    
    }
}