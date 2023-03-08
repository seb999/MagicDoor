using System;
using System.Device.Gpio;

public class StepperMotorController
{
    private readonly GpioController _controller;
    private readonly int[] _pins;
    private int _stepIndex = 0;

    private readonly int[,] _steps = new int[,]
    {
        { 1, 0, 0, 1 },
        { 1, 0, 0, 0 },
        { 1, 1, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 1, 1, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 1, 1 },
        { 0, 0, 0, 1 }
    };

    public StepperMotorController(int[] pins)
    {
        if (pins == null || pins.Length != 4)
        {
            throw new ArgumentException("Pins must be an array of 4 integers");
        }

        _controller = new GpioController();
        _pins = pins;

        foreach (var pin in _pins)
        {
            _controller.OpenPin(pin, PinMode.Output);
            _controller.Write(pin, PinValue.Low);
        }
    }

    public void TurnClockwise(int steps, int delayMilliseconds)
    {
        for (int i = 0; i < steps; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                _controller.Write(_pins[j], _steps[_stepIndex, j]);
            }

            _stepIndex = (_stepIndex + 1) % 8;

            System.Threading.Thread.Sleep(delayMilliseconds);
        }
    }

    public void TurnCounterClockwise(int steps, int delayMilliseconds)
    {
        for (int i = 0; i < steps; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                _controller.Write(_pins[j], _steps[_stepIndex, 3 - j]);
            }

            _stepIndex = (_stepIndex + 7) % 8;

            System.Threading.Thread.Sleep(delayMilliseconds);
        }
    }

    public void Dispose()
    {
        foreach (var pin in _pins)
        {
            _controller.ClosePin(pin);
        }

        _controller.Dispose();
    }
}
