﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Functions
{
    public interface IFunction
    {
        /// <summary>
        /// As a result this void should set the output value of n.
        /// </summary>
        /// <param name="n"></param>
        double ApplyFunction(double x);


    }
}