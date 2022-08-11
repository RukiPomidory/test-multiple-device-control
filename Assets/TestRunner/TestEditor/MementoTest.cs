using System.Collections;
using System.Collections.Generic;
using DeviceControl;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MementoTest
{
    [Test]
    public void Save()
    {
        var device = new DefaultDevice();
        var state1 = device.SaveState();
        
        Assert.AreEqual(Vector3.zero, state1.Position);

        var position = new Vector3(0, 1, 0);
        device.SetPosition(position);
        var state2 = device.SaveState();
        
        Assert.AreEqual(position, state2.Position);
    }

    [Test]
    public void Load()
    {
        var device = new DefaultDevice();
        var position = new Vector3(5, 6, 7);
        var state = new DeviceMemento(position);
        
        device.RestoreState(state);
        var savedState = device.SaveState();
        
        Assert.AreEqual(state.Position, savedState.Position);
    }
}
