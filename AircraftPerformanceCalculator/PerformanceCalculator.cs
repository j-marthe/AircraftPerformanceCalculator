using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PerformanceCalculator
{
    // Formulas simplificadas Dan valores más optimistas pero para simplificar

    public static double CalculateTakeoffDistance(Aircraft plane, FlightConditions conditions)
    {
        // Base: 1000 m a MTOW y 15 °C
        // Ajuste lineal por peso y temperatura
        return (plane.CurrentWeight / plane.MTOW) * 1000 + conditions.Temperature * 3;
    }

    public static double CalculateLandDistance(Aircraft plane, FlightConditions conditions)
    {
        // Base: 800 m a MTOW y 15 °C
        // Ajuste lineal por peso y temperatura
        return (plane.CurrentWeight / plane.MTOW) * 800 + conditions.Temperature * 2;
    }

    public static VSpeeds CalculateVSpeeds(Aircraft plane)
    {
        // Base: 130 km/h y ajuste lineal por peso
        double baseSpeed = 130 + (plane.CurrentWeight / 1000);

        return new VSpeeds
        {
            V1 = baseSpeed - 5,   // un poco menor
            VR = baseSpeed,       // velocidad de rotación
            V2 = baseSpeed + 10   // velocidad de seguridad
        };
    }


    // Formulas para otra versión

    //public static double CalculateTakeoffDistance(Aircraft plane, double acceleration = 2.5)
    //{
    //    double vs = Math.Sqrt(plane.CurrentWeight / plane.WingArea); // m/s simplificado
    //    double vLof = 1.2 * vs; // velocidad de levantamiento
    //    return (vLof * vLof) / (2 * acceleration); // metros
    //}

    //public static double CalculateLandDistance(Aircraft plane, double deceleration = 2.5)
    //{
    //    double vs = Math.Sqrt(plane.CurrentWeight / plane.WingArea); // m/s simplificado
    //    double vApp = 1.3 * vs; // velocidad de aproximación
    //    return (vApp * vApp) / (2 * deceleration); // metros
    //}

    //public static VSpeeds CalculateVSpeeds(Aircraft plane)
    //{
    //    double rho = 1.225; // densidad aire nivel del mar
    //    double CLmax = 1.5; // simplificado
    //    double weightN = plane.CurrentWeight * 9.81;

    //    double vs = Math.Sqrt((2 * weightN) / (rho * plane.WingArea * CLmax)); // m/s
    //    double vsKmh = vs * 3.6; // convertir a km/h

    //    double vr = 1.05 * vsKmh;
    //    double v2 = 1.2 * vsKmh;
    //    double v1 = (vr + v2) / 2;

    //    return new VSpeeds { V1 = v1, VR = vr, V2 = v2 };
    //}

}