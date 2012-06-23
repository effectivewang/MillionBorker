using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace MillionBroker
{
    class QueueProvider
    {
        private static IOrderQueue _orderQueue;
        
        public static IOrderQueue Instance {
            [MethodImpl( MethodImplOptions.Synchronized )]
            get {
                if (_orderQueue == null) {
                    SetQueueType(OrderQueueType.ConcurrentQueue);
                }

                return _orderQueue;
            }
        }

        [MethodImpl( MethodImplOptions.Synchronized)]
        public static void SetQueueType(OrderQueueType type) {
            _orderQueue = OrderQueueFactory.Create(type);
        }
    }
}
