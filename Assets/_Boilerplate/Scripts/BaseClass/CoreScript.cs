using System.Collections;
using UnityEngine;

namespace BoilerplateRomi
{
    public abstract class CoreScript : MonoBehaviour
    {
        protected Enums.EInitCondition init = Enums.EInitCondition.NO;
        protected ApplicationController Main;

        public virtual IEnumerator Setup(ApplicationController main)
        {
            init = Enums.EInitCondition.YES;
            this.Main = main;
            yield return null;
        }

        private void Update()
        {
            if (init == Enums.EInitCondition.NO)
                return;

            CoreUpdate();
        }

        public virtual void CoreUpdate()
        {

        }
    }
}