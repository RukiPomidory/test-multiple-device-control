using System.Collections;
using System.Collections.Generic;
using DeviceControl;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DeviceTest
{
    [Test]
    public void DiscreteDeviceCreation()
    {
        var factory = new DiscreteDeviceFactory();
        var device = factory.CreateDevice();

        Assert.NotNull(device);
        
        var availableCommands = device.GetAvailableCommands();
        
        Assert.NotNull(availableCommands);
        Assert.AreEqual(1, availableCommands.Count);

        var command = availableCommands[0];
        
        Assert.AreEqual(typeof(InstantCommand), command.GetType());
    }

    [Test]
    public void AnalogDeviceCreation()
    {
        var factory = new AnalogDeviceFactory();
        var device = factory.CreateDevice();

        Assert.NotNull(device);
        
        var availableCommands = device.GetAvailableCommands();
        
        Assert.NotNull(availableCommands);
        Assert.AreEqual(1, availableCommands.Count);

        var command = availableCommands[0];
        
        Assert.AreEqual(typeof(SmoothCommand), command.GetType());
    }
    
    [Test]
    public void CombinedDeviceCreation()
    {
        var factory = new CombinedDeviceFactory();
        var device = factory.CreateDevice();

        Assert.NotNull(device);
        
        var availableCommands = device.GetAvailableCommands();
        
        Assert.NotNull(availableCommands);
        Assert.AreEqual(2, availableCommands.Count);

        bool hasSmooth = false;
        bool hasInstant = false;

        foreach (var command in availableCommands)
        {
            if (command.GetType() == typeof(InstantCommand))
                hasInstant = true;

            if (command.GetType() == typeof(SmoothCommand))
                hasSmooth = true;
        }
        
        Assert.That(hasInstant);
        Assert.That(hasSmooth);
    }
}
