using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGameState
{
    public void Enter();
    public void StateUpdate(); 
    public void Exit(); 
}
