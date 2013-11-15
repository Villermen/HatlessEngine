﻿using System;
using System.Collections.Generic;

namespace HatlessEngine
{
    /// <summary>
    /// Stores a list of objects, that can be mass-created and removed.
    /// Convenient way of creating levels or maps in general.
    /// </summary>
    public class ObjectMap
    {
        public string Id { get; private set; }

        private List<ObjectMapBlueprint> Blueprints;
        public List<LogicalObject> ActiveObjects = new List<LogicalObject>();

        public ObjectMap(string id, params ObjectMapBlueprint[] objects)
        {
            Id = id;
            Blueprints = new List<ObjectMapBlueprint>(objects);
        }

        public List<LogicalObject> CreateObjects()
        {
            List<LogicalObject> returnList = new List<LogicalObject>();
            foreach (ObjectMapBlueprint blueprint in Blueprints)
            {
                LogicalObject logicalObject = (LogicalObject)Activator.CreateInstance(blueprint.Type, blueprint.Arguments.ToArray());
                ActiveObjects.Add(logicalObject);
                returnList.Add(logicalObject);
            }
            return returnList;
        }

        public void DestroyObjects()
        {
            foreach (LogicalObject logicalObject in ActiveObjects)
            {
                logicalObject.Destroy();
            }
            ActiveObjects.Clear();
        }
    }
}
