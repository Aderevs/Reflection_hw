using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureLibrary
{
    internal class Temperature : ITemperature
    {
        public Temperature()
        {
            MeasurementUnits = MeasurementUnits.Celsius;
            Degrees = 0;
        }
        public Temperature(double degrees, MeasurementUnits measurementUnits)
        {
            MeasurementUnits = measurementUnits;
            Degrees = degrees;
        }
        public Temperature(double degrees, string measurementUnits)
        {
            measurementUnits = measurementUnits.ToLower();
            switch (measurementUnits)
            {
                case "c":
                    MeasurementUnits = MeasurementUnits.Celsius;
                    break;
                case "f":
                    MeasurementUnits = MeasurementUnits.Farenheit;
                    break;
                case "k":
                    MeasurementUnits = MeasurementUnits.Kelvin;
                    break;
                default:
                    throw new ArgumentException("no such measurement units for measurement temperature");
            }
            Degrees = degrees;
        }
        public MeasurementUnits MeasurementUnits { get; private set; }
        public double Degrees { get; set; }
        public void ConvertToOtherMeasurementUnits(string newMeasurementUnits)
        {
            newMeasurementUnits = newMeasurementUnits.ToLower();
            if (MeasurementUnits == MeasurementUnits.Celsius)
            {
                switch (newMeasurementUnits)
                {
                    case "f":
                        Degrees *= 9 / 5 + 32;
                        break;
                    case "k":
                        Degrees += 273.15;
                        break;
                    case "c":
                        break;
                    default:
                        throw new ArgumentException("no such measurement units for measurement temperature");
                }
            }
            else if (MeasurementUnits == MeasurementUnits.Farenheit)
            {
                switch (newMeasurementUnits)
                {
                    case "c":
                        Degrees = ((Degrees - 32) * 5) / 9;
                        break;
                    case "k":
                        Degrees = ((Degrees - 32) * 5) / 9 + 273.15;
                        break;
                    case "f":
                        break;
                    default:
                        throw new ArgumentException("no such measurement units for measurement temperature");
                }
            }
            else
            {
                switch (newMeasurementUnits)
                {
                    case "c":
                        Degrees -= 273.15;
                        break;
                    case "f":
                        Degrees = 9 / 5 * (Degrees - 273.15) + 32;
                        break;
                    case "d":
                        break;
                    default:
                        throw new ArgumentException("no such measurement units for measurement temperature");
                }
            }
        }

        public void ConvertToOtherMeasurementUnits(MeasurementUnits newMeasurementUnits)
        {
            if (MeasurementUnits == MeasurementUnits.Celsius)
            {
                switch (newMeasurementUnits)
                {
                    case MeasurementUnits.Farenheit:
                        MeasurementUnits = MeasurementUnits.Farenheit;
                        Degrees = 9 / 5 * Degrees + 32;
                        break;
                    case MeasurementUnits.Kelvin:
                        MeasurementUnits = MeasurementUnits.Kelvin;
                        Degrees += 273.15;
                        break;
                    default:
                        break;
                }
            }
            else if (MeasurementUnits == MeasurementUnits.Farenheit)
            {
                switch (newMeasurementUnits)
                {
                    case MeasurementUnits.Celsius:
                        MeasurementUnits = MeasurementUnits.Celsius;
                        Degrees = ((Degrees - 32) * 5) / 9;
                        break;
                    case MeasurementUnits.Kelvin:
                        MeasurementUnits = MeasurementUnits.Kelvin;
                        Degrees = ((Degrees - 32) * 5) / 9 + 273.15;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (newMeasurementUnits)
                {
                    case MeasurementUnits.Celsius:
                        MeasurementUnits = MeasurementUnits.Celsius;
                        Degrees -= 273.15;
                        break;
                    case MeasurementUnits.Farenheit:
                        MeasurementUnits = MeasurementUnits.Farenheit;
                        Degrees = 9 / 5 * (Degrees - 273.15) + 32;
                        break;
                    default:
                        break;
                }
            }
        }

        public override string ToString()
        {
            string unit;
            if (MeasurementUnits == MeasurementUnits.Celsius)
                unit = "C";
            else if (MeasurementUnits == MeasurementUnits.Farenheit)
                unit = "F";
            else
                unit = "K";
            return $"{Degrees} °{unit}";
        }
    }
}
