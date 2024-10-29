using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace SpaceArcade
{
    public class TestObject
    {
        const float colorR = 0.0f;
        const float colorG = 1.0f;
        const float colorB = 0.0f;

        const float v1 = 0.60f;     //0.50f
        const float v2 = 0.35f;     //0.25f
        const float v3 = 0.75f;

        const float r1 = 0.50f*0.25f;
        const float r2 = 0.15f;
        const float r3 = 0.20f;
        const float r4 = 0.20f;
        const float r5 = 0.25f;

        const float t1 = 0.50f;
        const float t2 = 0.22f;

        const float s1 = 0.25f;
        const float s2 = 1.2f;

        const float cos60 = 0.500f;
        const float sin60 = 0.866f;
        const float sin45 = 0.707f;

        public static float[] testTriangle = new float[]
            {
                 // Positions        // Colors
               -0.50f,  0.0f,  0.0f,  colorR, colorG, colorB,         //0
                0.50f,  0.0f,  0.0f,  colorR, colorG, colorB,         //1

                //Left Wing
               -t1,         0.0f,       v1,         colorR, colorG, colorB,             //2
               -t1,         0.0f,       -v1,        colorR, colorG, colorB,             //3
               -t1,         v3,         v2,         colorR, colorG, colorB,             //4
               -t1,         v3,         -v2,        colorR, colorG, colorB,             //5
               -t1,         -v3,        v2,         colorR, colorG, colorB,             //6
               -t1,         -v3,        -v2,        colorR, colorG, colorB,             //7

               -t1,         0.0f,       r1,         colorR, colorG, colorB,             //8
               -t1,         0.0f,       -r1,        colorR, colorG, colorB,             //9
               -t1,         r1,         r1*cos60,   colorR, colorG, colorB,             //10
               -t1,         r1,         -r1*cos60,  colorR, colorG, colorB,             //11
               -t1,         -r1,        r1*cos60,   colorR, colorG, colorB,             //12
               -t1,         -r1,        -r1*cos60,  colorR, colorG, colorB,             //13

               // Right Wing
               t1,          0.0f,       v1,         colorR, colorG, colorB,             //14
               t1,          0.0f,       -v1,        colorR, colorG, colorB,             //15
               t1,          v3,         v2,         colorR, colorG, colorB,             //16
               t1,          v3,         -v2,        colorR, colorG, colorB,             //17
               t1,          -v3,        v2,         colorR, colorG, colorB,             //18
               t1,          -v3,        -v2,        colorR, colorG, colorB,             //19

               t1,          0.0f,       r1,         colorR, colorG, colorB,             //20
               t1,          0.0f,       -r1,        colorR, colorG, colorB,             //21
               t1,          r1,         r1*cos60,   colorR, colorG, colorB,             //22
               t1,          r1,         -r1*cos60,  colorR, colorG, colorB,             //23
               t1,          -r1,        r1*cos60,   colorR, colorG, colorB,             //24
               t1,          -r1,        -r1*cos60,  colorR, colorG, colorB,             //25

               // Left Tube

               -t2,         0.0f,       r1,         colorR, colorG, colorB,             //26
               -t2,         0.0f,       -r1,        colorR, colorG, colorB,             //27
               -t2,         r1,         r1*cos60,   colorR, colorG, colorB,             //28
               -t2,         r1,         -r1*cos60,  colorR, colorG, colorB,             //29
               -t2,         -r1,        r1*cos60,   colorR, colorG, colorB,             //30
               -t2,         -r1,        -r1*cos60,  colorR, colorG, colorB,             //31

               // Right Tube

               t2,          0.0f,       r1,         colorR, colorG, colorB,             //32
               t2,          0.0f,       -r1,        colorR, colorG, colorB,             //33
               t2,          r1,         r1*cos60,   colorR, colorG, colorB,             //34
               t2,          r1,         -r1*cos60,  colorR, colorG, colorB,             //35
               t2,          -r1,        r1*cos60,   colorR, colorG, colorB,             //36
               t2,          -r1,        -r1*cos60,  colorR, colorG, colorB,             //37

               // Window

               0.0f,        r2,         0.20f,      colorR, colorG, colorB,             //38
               r2*sin45,    r2*sin45,   0.20f,      colorR, colorG, colorB,             //39
               r2,          0.0f,       0.20f,      colorR, colorG, colorB,             //40
               r2*sin45,    -r2*sin45,  0.20f,      colorR, colorG, colorB,             //41
               0.0f,        -r2,        0.20f,      colorR, colorG, colorB,             //42
               -r2*sin45,   -r2*sin45,  0.20f,      colorR, colorG, colorB,             //43
               -r2,         0.0f,       0.20f,      colorR, colorG, colorB,             //44
               -r2*sin45,   r2*sin45,   0.20f,      colorR, colorG, colorB,             //45

               0.0f,        r3,         0.15f,      colorR, colorG, colorB,             //46
               r3*sin45,    r3*sin45,   0.15f,      colorR, colorG, colorB,             //47
               r3,          0.0f,       0.15f,      colorR, colorG, colorB,             //48
               r3*sin45,    -r3*sin45,  0.15f,      colorR, colorG, colorB,             //49
               0.0f,        -r3,        0.15f,      colorR, colorG, colorB,             //50
               -r3*sin45,   -r3*sin45,  0.15f,      colorR, colorG, colorB,             //51
               -r3,         0.0f,       0.15f,      colorR, colorG, colorB,             //52
               -r3*sin45,   r3*sin45,   0.15f,      colorR, colorG, colorB,             //53

               // Hull

               // Back 1
               0.0f,        r2,         -0.20f,     colorR, colorG, colorB,             //54
               r2*sin45,    r2*sin45,   -0.20f,     colorR, colorG, colorB,             //55
               r2,          0.0f,       -0.20f,     colorR, colorG, colorB,             //56
               r2*sin45,    -r2*sin45,  -0.20f,     colorR, colorG, colorB,             //57
               0.0f,        -r2,        -0.20f,     colorR, colorG, colorB,             //58
               -r2*sin45,   -r2*sin45,  -0.20f,     colorR, colorG, colorB,             //59
               -r2,         0.0f,       -0.20f,     colorR, colorG, colorB,             //60
               -r2*sin45,   r2*sin45,   -0.20f,     colorR, colorG, colorB,             //61


               // Back vert
               0.0f,        0.0f,       -0.22f,     colorR, colorG, colorB,             //62

               0.0f,        r4,         -0.15f,     colorR, colorG, colorB,             //63
               r4*sin45,    r4*sin45,   -0.15f,     colorR, colorG, colorB,             //64
               r4,          0.0f,       -0.15f,     colorR, colorG, colorB,             //65
               r4*sin45,    -r4*sin45,  -0.15f,     colorR, colorG, colorB,             //66
               0.0f,        -r4,        -0.15f,     colorR, colorG, colorB,             //67
               -r4*sin45,   -r4*sin45,  -0.15f,     colorR, colorG, colorB,             //68
               -r4,         0.0f,       -0.15f,     colorR, colorG, colorB,             //69
               -r4*sin45,   r4*sin45,   -0.15f,     colorR, colorG, colorB,             //70

               // Back Top
               -r5*sin45,   r5*sin45,   -0.05f,     colorR, colorG, colorB,             //71
               0.0f,        r5,         -0.05f,     colorR, colorG, colorB,             //72
               r5*sin45,    r5*sin45,   -0.05f,     colorR, colorG, colorB,             //73

               // Back Bottom
               -r5*sin45,   -r5*sin45,  -0.05f,     colorR, colorG, colorB,             //74
               0.0f,        -r5,        -0.05f,     colorR, colorG, colorB,             //75
               r5*sin45,    -r5*sin45,  -0.05f,     colorR, colorG, colorB,             //76

               // Front Top
               -r5*sin45,   r5*sin45,   0.05f,      colorR, colorG, colorB,             //77
               0.0f,        r5,         0.05f,      colorR, colorG, colorB,             //78
               r5*sin45,    r5*sin45,   0.05f,      colorR, colorG, colorB,             //79

               // Front Bottom
               -r5*sin45,   -r5*sin45,  0.05f,      colorR, colorG, colorB,             //80
               0.0f,        -r5,        0.05f,      colorR, colorG, colorB,             //81
               r5*sin45,    -r5*sin45,  0.05f,      colorR, colorG, colorB,             //82








            };
        public static uint[] indicies = new uint[]
        {
            //0, 1,

            // Outer (Left)
            2, 4,
            4, 5,
            3, 5,
            2, 6,
            3, 7,
            6, 7,

            // Inner (Left)
            2+6, 4+6,
            4+6, 5+6,
            3+6, 5+6,
            2+6, 6+6,
            3+6, 7+6,
            6+6, 7+6,

            // Outer to Inner (Left)

            2, 8,
            3, 9,
            4, 10,
            5, 11, 
            6, 12,
            7, 13,

            // Outer (Right)
            2+12, 4+12,
            4+12, 5+12,
            3+12, 5+12,
            2+12, 6+12,
            3+12, 7+12,
            6+12, 7+12,

            // Inner (Right)
            2+6+12, 4+6+12,
            4+6+12, 5+6+12,
            3+6+12, 5+6+12,
            2+6+12, 6+6+12,
            3+6+12, 7+6+12,
            6+6+12, 7+6+12,

            // Outer to Inner (Right)

            2+12, 8+12,
            3+12, 9+12,
            4+12, 10+12,
            5+12, 11+12,
            6+12, 12+12,
            7+12, 13+12,


            // Left Tube
            2+24, 4+24,
            4+24, 5+24,
            3+24, 5+24,
            2+24, 6+24,
            3+24, 7+24,
            6+24, 7+24,

            2+6, 2+24,
            3+6, 3+24,
            4+6, 4+24,
            5+6, 5+24,
            6+6, 6+24,
            7+6, 7+24,

            // Right Tube
            2+24+6, 4+24+6,
            4+24+6, 5+24+6,
            3+24+6, 5+24+6,
            2+24+6, 6+24+6,
            3+24+6, 7+24+6,
            6+24+6, 7+24+6,

            20, 2+24+6,
            21, 3+24+6,
            22, 4+24+6,
            23, 5+24+6,
            24, 6+24+6,
            25, 7+24+6,

            // Window
            38, 39,
            39, 40,
            40, 41,
            41, 42,
            42, 43,
            43, 44,
            44, 45,
            45, 38,

            38+8, 39+8,
            39+8, 40+8,
            40+8, 41+8,
            41+8, 42+8,
            42+8, 43+8,
            43+8, 44+8,
            44+8, 45+8,
            45+8, 38+8,

            38, 38+8,
            39, 39+8,
            40, 40+8,
            41, 41+8,
            42, 42+8,
            43, 43+8,
            44, 44+8,
            45, 45+8,

            // Hull

            38+16, 39+16,
            39+16, 40+16,
            40+16, 41+16,
            41+16, 42+16,
            42+16, 43+16,
            43+16, 44+16,
            44+16, 45+16,
            45+16, 38+16,

            54, 62,
            55, 62,
            56, 62,
            57, 62,
            58, 62,
            59, 62,
            60, 62,
            61, 62,

            63, 64,
            64, 65,
            65, 66, 
            66, 67,
            67, 68, 
            68, 69,
            69, 70,
            70, 63,

            26, 52,
            27, 69,
            32, 48,
            33, 65,


            71, 72,
            72, 73,

            74, 75,
            75, 76,

            77, 78,
            78, 79,

            80, 81,
            81, 82,

            71, 77,
            72, 78,
            73, 79,
            74, 80,
            75, 81,
            76, 82,

            
            47, 79,
            46, 78,
            53, 77,

            71, 70,
            70, 61,
            72, 63,
            63, 54,
            73, 64,
            64, 55,

            74, 68,
            68, 59,
            75, 67,
            67, 58,
            76, 66,
            66, 57,

            56, 65,
            60, 69,

            80, 51,
            81, 50,
            82, 49,

            77, 28,
            71, 29,

            73, 35,
            79, 34,

            74, 31,
            80, 30,

            76, 37,
            82, 36,






        };
    }
}