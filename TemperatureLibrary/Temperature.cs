using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureLibrary
{
    internal enum MeasurementUnits
    {
        Celsius,
        Farenheit,
        Kelvin
    }
    internal class Temperature
    {
        public Temperature(MeasurementUnits measurementUnits, double degrees)
        {
            MeasurementUnits = measurementUnits;
            Degrees = degrees;
        }
        public Temperature(string measurementUnits, double degrees)
        {
            switch (measurementUnits)
            {
                case "C":
                    MeasurementUnits = MeasurementUnits.Celsius;
                    break;
                case "F":
                    MeasurementUnits = MeasurementUnits.Farenheit;
                    break;
                case "K":
                    MeasurementUnits = MeasurementUnits.Kelvin;
                    break;
                default:
                    throw new ArgumentException("no such measurement units for measurement temperature");
            }
            Degrees = degrees;
        }
        public MeasurementUnits MeasurementUnits { get; }
        public double Degrees { get; set; }
        public void ChangeMeasurementUnits(string newMeasurementUnits)
        {
            if (MeasurementUnits == MeasurementUnits.Celsius)
            {
                switch (newMeasurementUnits)
                {
                    case "F":
                        Degrees *= 9 / 5 + 32;
                        break;
                    case "K":
                        Degrees += 273.15;
                        break;
                    case "C":
                        break;
                    default:
                        throw new ArgumentException("no such measurement units for measurement temperature");
                }
            }
            else if (MeasurementUnits == MeasurementUnits.Farenheit)
            {
                switch (newMeasurementUnits)
                {
                    case "C":
                        Degrees = ((Degrees - 32) * 5) / 9;
                        break;
                    case "K":
                        Degrees = ((Degrees - 32) * 5) / 9 + 273.15;
                        break;
                    case "F":
                        break;
                    default:
                        throw new ArgumentException("no such measurement units for measurement temperature");
                }
            }
            else
            {
                switch (newMeasurementUnits)
                {
                    case "C":
                        Degrees -= 273.15;
                        break;
                    case "F":
                        Degrees = 9 / 5 * (Degrees - 273.15) + 32;
                        break;
                    case "D":
                        break;
                    default:
                        throw new ArgumentException("no such measurement units for measurement temperature");
                }
            }
        }
        public void ChangeMeasurementUnits(MeasurementUnits newMeasurementUnits)
        {
            if (MeasurementUnits == MeasurementUnits.Celsius)
            {
                switch (newMeasurementUnits)
                {
                    case MeasurementUnits.Farenheit:
                        Degrees *= 9 / 5 + 32;
                        break;
                    case MeasurementUnits.Kelvin:
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
                        Degrees = ((Degrees - 32) * 5) / 9;
                        break;
                    case MeasurementUnits.Kelvin:
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
                        Degrees -= 273.15;
                        break;
                    case MeasurementUnits.Farenheit:
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
