﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addresbook_web_tests2
{
    class Square: Figure
    {
        private int size;
        public Square(int size)
        {
            this.size = size;
        }
        public int Size

        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

       

    }

}
