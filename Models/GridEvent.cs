﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GridEvent<T> where T : class
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string EventType { get; set; }
        public T Data { get; set; }
        public DateTime EventTime { get; set; }
    }
}
