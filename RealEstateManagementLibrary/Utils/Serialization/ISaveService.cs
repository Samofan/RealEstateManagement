using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManagementLibrary.Utils.Serialization
{
    public interface ISaveService
    {
        void SaveAsJson();

        void SaveInDatabase();

        void SaveAsXml();
    }
}
