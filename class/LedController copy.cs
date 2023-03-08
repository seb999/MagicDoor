using System;
using System.Device.Gpio;

public class LedController
{
    private readonly GpioController _controller;
    private readonly int _pinNumber;

    public LedController(int pin)
    {
        _pinNumber = pin;
        _controller = new GpioController();
        _controller.OpenPin(pin, PinMode.Output);
        _controller.Write(_pinNumber, PinValue.Low);
    }

    public void Blink(int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            _controller.Write(_pinNumber, PinValue.High);
            Thread.Sleep(300);
            _controller.Write(_pinNumber, PinValue.Low);
            Thread.Sleep(300);
        }

        Dispose();
    }

    private void Dispose()
    {
        _controller.ClosePin(_pinNumber);
        _controller.Dispose();
    }
}