// MathFuncsDll.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "MathFuncsDll.h"
#include <stdexcept>

using namespace std;

#pragma warning(push)
#pragma warning(disable: 4273)

namespace MathFuncs
{
    double MyMathFuncs::Add( double a, double b )
    {
        return a + b;
    }

    double MyMathFuncs::Subtract( double a, double b )
    {
        return a - b;
    }

    double MyMathFuncs::Multiply( double a, double b )
    {
        return a * b;
    }

    double MyMathFuncs::Divide( double a, double b )
    {
        if( b == 0 )
        {
            throw invalid_argument( "b cannot be zero!" );
        }

        return a / b;
    }
}
#pragma warning(pop)