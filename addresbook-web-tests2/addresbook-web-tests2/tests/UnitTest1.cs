﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace addresbook_web_tests2.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double total = 900;
            bool vipClient = true;
            if (total > 1000 || vipClient)
            {
                total = total * 0.9;
                System.Console.Out.Write("Скидка 10%, общая сумма " + total);
            }
           
        }
    }
}
