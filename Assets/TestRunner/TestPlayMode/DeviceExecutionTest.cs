using System.Collections;
using System.Collections.Generic;
using DeviceControl;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DeviceExecutionTest
{
    public static float RandomFloat()
    {
        return (Random.value - 0.5f) * float.MaxValue;
    }
    
    [UnityTest]
    public IEnumerator DiscreteDevice()
    {
        var factory = new DiscreteDeviceFactory();
        var device = factory.CreateDevice();

        var instantCommand = device.GetAvailableCommands()[0];

        yield return CheckInstant(device, instantCommand);
    }
    
    [UnityTest]
    public IEnumerator AnalogDevice()
    {
        var factory = new AnalogDeviceFactory();
        var device = factory.CreateDevice();

        var smoothCommand = device.GetAvailableCommands()[0];

        yield return CheckSmooth(device, smoothCommand);
    }
    
    [UnityTest]
    public IEnumerator CombinedDevice()
    {
        var factory = new CombinedDeviceFactory();
        var device = factory.CreateDevice();

        Command instant = null;
        Command smooth = null;

        foreach (var command in device.GetAvailableCommands())
        {
            if (command.GetType() == typeof(InstantCommand))
                instant = command;
            
            if (command.GetType() == typeof(SmoothCommand))
                smooth = command;
        }

        yield return CheckInstant(device, instant);
        
        instant.Execute(Vector3.zero);
        Assert.AreEqual(Vector3.zero, device.Position);
        
        yield return CheckSmooth(device, smooth);
    }

    private IEnumerator CheckInstant(Device device, Command instantCommand)
    {
        Assert.AreEqual(Vector3.zero, device.Position);
        
        var target = new Vector3(RandomFloat(), RandomFloat(), RandomFloat());
        
        instantCommand.Execute(target);

        Assert.AreEqual(target, device.Position);

        yield return null;
    }

    private IEnumerator CheckSmooth(Device device, Command smoothCommand)
    {
        Assert.AreEqual(Vector3.zero, device.Position);
        
        var target = new Vector3(RandomFloat(), RandomFloat(), RandomFloat());
        
        smoothCommand.Execute(target);

        var transitionDuration = ((SmoothCommand)smoothCommand).Duration;
        
        yield return new WaitForSeconds(transitionDuration);
        
        Assert.AreEqual(target, device.Position);
    }
}