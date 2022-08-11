using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public abstract class Device
{
    protected Vector3 state;

    public DeviceMemento SaveState()
    {
        return new DeviceMemento(state);
    }

    public void RestoreState(DeviceMemento memento)
    {
        state = memento.State;
    }
}
