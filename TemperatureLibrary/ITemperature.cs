using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureLibrary
{
    public interface ITemperature
    {
        void ConvertToOtherMeasurementUnits(MeasurementUnits newMeasurementUnits);
    }
}
