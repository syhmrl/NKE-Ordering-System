using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKE_Ordering_System
{
    abstract class TakeAway
    {
        public abstract int generateTA_ID();
        public abstract void storeTA();
        public abstract void deleteTA();
        public abstract void updateTA();
        public abstract void showTA();
    }
}
