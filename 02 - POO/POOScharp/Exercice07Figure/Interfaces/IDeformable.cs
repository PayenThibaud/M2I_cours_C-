﻿using Exercice07Figure.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07Figure.Interfaces
{
    internal interface IDeformable
    {
        public Figure Deformer(double x, double y);
    }
}