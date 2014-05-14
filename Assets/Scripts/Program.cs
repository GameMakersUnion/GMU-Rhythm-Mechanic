/*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static List<Notes> notes;
        static Stopwatch watch = new Stopwatch();
        static float slowdown = 0f;
        static void Main(string[] args)
        {
            ReadFile();

            watch.Start();
            while (true)
            {
                if (currentIndex < notes.Count)
                Loop((float)watch.Elapsed.TotalSeconds);
                Thread.Sleep(50);
            }
        }



        static int currentIndex = 0;
        static void Loop(float time)
        {
            Notes current = notes[currentIndex];
            if (current.started)
            {
                if (current.isEnded(time * (1 - slowdown)))
                {
                    currentIndex++;
                    Console.WriteLine("-");
                }
                else
                {
                    Console.WriteLine(current.clr.ToString());
                }
                return;
            }
            else
            {
                if (current.isStarted(time))
                {
                    current.started = true;
                    Console.WriteLine(current.clr.ToString());
                }
                else
                {
                    Console.WriteLine("-");
                }
                return;
            }
        }
        static btn currentColor = btn.yellow_Middle;

        static void findNewColor()
        {
            Notes current = notes[currentIndex], previous = notes[currentIndex - 1];
            if (current.pitch < previous.pitch)
            {
                currentColor = (btn)Math.Max((int)currentColor - 1, 0);
            }
            else if (current.pitch > previous.pitch)
            {
                currentColor = (btn)Math.Min((int)currentColor + 1, 2);
            }
        }

        static void InputMarioIntro()
        {
            notes.Add(new Notes(0.2f, 0.32f, btn.yellow_Middle));
            notes.Add(new Notes(0.35f, 0.48f, btn.yellow_Middle));
            notes.Add(new Notes(0.65f, 0.77f, btn.yellow_Middle));
            notes.Add(new Notes(0.95f, 1.06f, btn.blue_Low));
            notes.Add(new Notes(1.08f, 1.22f, btn.yellow_Middle));
            notes.Add(new Notes(1.39f, 1.54f, btn.red_High));
            notes.Add(new Notes(2.0f, 2.1f, btn.blue_Low));
        }
    }


}

*/