using System.Collections.Generic;
using TechData.Models;

namespace TechData.Interfaces
{
    public interface IHoldService
    {
        IEnumerable<AssetType> GetAll();
        AssetType Get(int id);
        void Add(AssetType newType);
    }
}
