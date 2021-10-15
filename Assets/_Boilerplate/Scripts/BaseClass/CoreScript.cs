using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Locglo.Boilerplate.Enums;

namespace Locglo.Boilerplate
{
    public abstract class CoreScript : MonoBehaviour
    {
        protected EInitCondition init = EInitCondition.NO;
        protected ApplicationController applicationController;

        public virtual IEnumerator Setup(ApplicationController applicationController)
        {
            init = EInitCondition.YES;
            this.applicationController = applicationController;
            yield return null;
        }

        private void Update()
        {
            if (init == EInitCondition.NO)
                return;

            CoreUpdate();
        }

        public virtual void CoreUpdate()
        {

        }
    }
}