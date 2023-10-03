using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegatesSolution
{
    public delegate void ShippingFeesDelegate(decimal thePrice, ref decimal fee);

    abstract class ShippingDestination
    {
        public bool m_isHighRisk;
        public virtual void calcFees(decimal price, ref decimal fee){ }

        public static ShippingDestination getDestinationInfo(string dest)
        {
            if (dest.Equals("zone1"))
            {
                return new Dest_Zone1();
            }
            if (dest.Equals("zone2"))
            {
                return new Dest_Zone2();
            }
            if (dest.Equals("zone3"))
            {
                return new Dest_Zone3();
            }
            if (dest.Equals("zone4"))
            {
                return new Dest_Zone4();
            }

            return null;
        }
    }

    class Dest_Zone1: ShippingDestination
    {
        public Dest_Zone1()
        {
            this.m_isHighRisk = false;
        }

        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.25m;
        }
    }

    class Dest_Zone2: ShippingDestination
    {
        public Dest_Zone2()
        {
            this.m_isHighRisk = false;
        }

        public override void calcFees(decimal price, ref decimal fee)

    }

    class Dest_Zone3: ShippingDestination
    {
        public Dest_Zone3()
        {
            this.m_isHighRisk = false;
        }
        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.08m;
        }
    }

    class Dest_Zone4: ShippingDestination
    {
        public Dest_Zone4()
        {
            this.m_isHighRisk = true;
        }
        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.04m;
        }
    
    }
}