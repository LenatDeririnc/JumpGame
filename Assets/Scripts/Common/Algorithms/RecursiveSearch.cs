using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Common.Algorithms
{
    public static class RecursiveSearch
    {
        public static List<T> GetListWithChildren<T>(T parentTransform, Func<T, int> getCountOfElement, Func<T, int, T> getChildOfElement) where T : Object 
        {
            List<T> collectedChildren = new List<T>();

            if (getCountOfElement(parentTransform) <= 0) 
                return collectedChildren;
            
            for (int i = 0; i < getCountOfElement(parentTransform); i++)
            {
                T child = getChildOfElement(parentTransform, i);

                if (child == parentTransform)
                    continue;
                
                collectedChildren.Add(child);

                List<T> childrenOfChild = GetListWithChildren(child, getCountOfElement, getChildOfElement);
                collectedChildren.AddRange(childrenOfChild);
            }

            return collectedChildren;
        }
    }
}