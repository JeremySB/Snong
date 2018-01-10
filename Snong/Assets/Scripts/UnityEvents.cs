using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UnityEvents {
    [Serializable]
    public class GameObjectEvent : UnityEvent<GameObject> { }
}
