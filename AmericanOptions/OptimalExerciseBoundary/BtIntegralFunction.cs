﻿using System;
using System.Threading.Tasks;
using AmericanOptions.Model;

namespace AmericanOptions.OptimalExerciseBoundary
{
    public class BtIntegralFunction : IBtIntegralFunction
    {
        public async Task<IntegralFunction> CalculateAsync(int n, double T, double r, double sigma, double t, IntegralPoint D2)
        {
            IntegralFunction integralFunction = new IntegralFunction();
            UnderIntegral[] underIntegral = new UnderIntegral[n];

            for (int i = 0; i < n; i++)
            {
                UnderIntegral ui = new UnderIntegral();

                ui.h = (T / n);
                ui.ksi = i * ui.h;
                ui.Result.Value = CalculateUnderIntegral(r, sigma, t, ui.ksi, D2) * ui.h;

                underIntegral[i] = ui;
                integralFunction.Result.Value += ui.Result.Value;
            }

            integralFunction.UnderIntegral = underIntegral;

            return integralFunction;
        }

        private static double CalculateUnderIntegral(double r, double sigma, double t, double ksi, IntegralPoint D2)
        {
            return (r / sigma * Math.Sqrt(2 * Math.PI * (t - ksi))) *
                    Math.Exp(-(r * (t - ksi) + (0.5 * Math.Pow(D2.Result.Value, 2))));
        }
    }
}
