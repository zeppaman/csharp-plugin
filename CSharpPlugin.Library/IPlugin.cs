using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlugin.Library
{
    public abstract class IPlugin
    {
        public Dependency dep = null;
        public virtual void Register(Dependency dep)
        {
            this.dep = dep;
        }

        public abstract void DoThings();

    }
}
