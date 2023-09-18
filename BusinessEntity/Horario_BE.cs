﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    [Serializable]
    public class Horario_BE
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public Dictado_BE Dictado { get; set; }
    }
}