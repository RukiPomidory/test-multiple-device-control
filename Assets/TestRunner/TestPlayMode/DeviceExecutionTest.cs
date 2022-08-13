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
        return (Random.value - 0.5f) * 1000000;
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

        var smoothCommand = device.GetCommand<SmoothCommand>();

        yield return CheckSmooth(device, smoothCommand);
    }
    
    [UnityTest]
    public IEnumerator CombinedDevice()
    {
        var factory = new CombinedDeviceFactory();
        var device = factory.CreateDevice();

        Command instant = device.GetCommand<InstantCommand>();
        Command smooth = device.GetCommand<SmoothCommand>();

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
        var startPosition = device.Position;
        var target = new Vector3(RandomFloat(), RandomFloat(), RandomFloat());
        
        Assert.AreEqual(Vector3.zero, startPosition);
        
        smoothCommand.Execute(target);

        var transitionDuration = ((SmoothCommand)smoothCommand).Duration;

        var firstDelay = transitionDuration / 2;
        
        yield return new WaitForSeconds(firstDelay);
        
        Assert.AreNotEqual(target, device.Position);
        Assert.AreNotEqual(startPosition, device.Position);
        
        yield return new WaitForSeconds(transitionDuration - firstDelay);
        
        Assert.AreEqual(target, device.Position);
    }
}
