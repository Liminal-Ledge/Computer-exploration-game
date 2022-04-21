using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_test
{
    internal class SystemSounds
    {
        internal static void SwitchOnSound()
        {
            Thread switchOn = new Thread(() =>
              {
                  Thread.Sleep(1800);
                  Console.Beep(800, 200);
                  Thread.Sleep(500);
                  Console.Beep(1200, 200);
                  return;
              });
            switchOn.Start();
        }

        internal static void Failure()
        { Thread fail = new Thread(()=>
            {
                Console.Beep(400, 200);
                Thread.Sleep(100);
                Console.Beep(400, 200);
                Thread.Sleep(100);
                Console.Beep(400, 200);
                return;
            }
            ); 
        fail.Start();
        }
            
    
    }
}
