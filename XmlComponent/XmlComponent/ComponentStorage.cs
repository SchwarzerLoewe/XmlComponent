﻿using System.Collections.ObjectModel;

namespace XmlComponent
{
    public class ComponentStorage : Collection<Component>
    {
        static ComponentStorage _instance;
        public static ComponentStorage Instance
        {
            get
            {
                if (_instance == null) _instance = new ComponentStorage();
                return _instance;
            }
        }
    }
}