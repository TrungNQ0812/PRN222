using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Ambient_Context_Demo.Model
{
    public abstract class Provider
    {
        private static Provider current;
        public static Provider Current
        {
            get
            {
                if(current == null)
                {
                    current = new DefaultDepartmentProvider();
                }
                return current;
            }
            set
            {
                current = value ?? new DefaultDepartmentProvider();
            }
        }//end current
        public virtual Department Department { get; }
    }

    //-------------------------------------
    public class DefaultDepartmentProvider : Provider
    {
        public override Department Department => new Engineering();
    }
    //----------------------------------------------------
    public class MarketingProvider : Provider
    {
        public override Department Department => new Marketing();
    }
}
