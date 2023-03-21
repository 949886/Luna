//
//  CppTest.cs
//  Luna
//
//  Created by LunarEclipse on 2019-01-19 10:07:25.
//  Copyright © 2019 LunarEclipse. All rights reserved.
//

using System.Runtime.InteropServices;

namespace Luna.Cpp
{
    public class CppTest
    {
        [DllImport("Luna.Cpp.dll")]
        public static extern int Add(int n1, int n2);
    }
}