using UnityEngine;

namespace Interfaces
{
    public interface IMergeItem
    {
        
        public void Take();
        public void Break();

        public void SetParent(IContainer container);
    }
}