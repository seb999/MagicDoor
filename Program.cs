using System.Device.Gpio;

namespace magicDoor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           
            //Blink a led on GPIO 26
            var controllerForLed = new LedController(26);
            controllerForLed.Blink(50);
           
           
            // var controller = new StepperMotorController(new int[] { 17, 18, 27, 22 });
            // controller.TurnClockwise(512, 2);
            // controller.TurnCounterClockwise(512, 2);
            // controller.Dispose();
        }
    } 
}