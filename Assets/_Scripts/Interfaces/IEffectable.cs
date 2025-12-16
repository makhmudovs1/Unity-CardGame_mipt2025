using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IEffectable
{
    void AddStatusEffect(StatusEffect sf);

    void ExecuteEffect(StatusEffect effect);
    void ExecuteEffects();
}

