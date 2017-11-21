//   2017.11.21   1을 솟수로 판단하는 문제 수정
//   2017.10.16   수분석가 , 수분석가(안드로이드)에 이용하기 위해 만듬  



using System;
using System.Collections.Generic;
using System.Text;


namespace 수분석가
{
    // 수분석가에서 이용하기 위해 만든 수학관련 메소드
    class MyMath
    {
        //  1.  짝수 판단 함수 
        //  인수 : long ulong 형식의 수(짝수인지 아니지 구별하려는 수)
        //  return :  짝수면 True , 홀수면 False
        static public bool Evennum(long num)
        {
            if (num % 2 == 0) return true;
            else return false;
        }

        static public bool Evennum(ulong num)
        {
            if (num % 2 == 0) return true;
            else return false;
        }

        // 2.  소인수 분해 함수
        //  인수 : long ulong 형식의 수
        //  return :  "1 x 2^3 ... " 소인수분해 형태의 문자열
        static public string make_factorForm(long M)
        {
            long n;
            long max_n;

            string f_str = "1";
            int count;

            if (M == Primenum(M)) return ("1 X" + M.ToString());


            max_n = M / 2;

            for (n = 2; n <= max_n; n++)
            {
                count = 0;
                if (n == Primenum(n))
                {
                    count = n_be_M(M, n);
                }

                if (count > 0)
                {
                    if (count == 1) f_str = f_str + " X " + n.ToString("D");
                    else f_str = f_str + " X " + n.ToString("D") + "^" + count;
                }

            }


            return f_str;


        }

        //  3. 솟수인지 판단하는 함수  
        //   리턴값 소수면 자기자신  
        //         소수가 아니면 처음발견한 인수  
        //         2보다 작으면 1    -->  2보다 작으면 자기자신-1 (2017.11.21)
        static public long Primenum(long M)
        {
            long n;
            long i;

            if (M < 2) return M - 1;
            if (M == 2) return M;   // 2는 소수

            n = (long)(Math.Sqrt((double)M) + 1.0);

            for (i = 2; i <= n; i++)
            {
                if (i == Primenum(i))
                {
                    if (M % i == 0) return i; /* 나누어 지면 함수 종료*/
                }

            }

            return M;  // 소수이면 M 반환
        }

        static public ulong Primenum(ulong M)
        {
            ulong n;
            ulong i;

            if (M < 2) return M - 1;
            if (M == 2) return M;   // 2는 소수

            n = (ulong)(Math.Sqrt((double)M) + 1.0);

            for (i = 2; i <= n; i++)
            {
                if (i == Primenum(i))
                {
                    if (M % i == 0) return i; /* 나누어 지면 함수 종료*/
                }

            }

            return M;  // 소수이면 M 반환
        }

        // 4. 완전수 확인 함수
        // 리턴 : 완전수이면 True
        //        완전수가 아니면 False
        // 인수 :  long M 판단이 필요한수
        //         out string str : 소인수 분해 결과를 저장하는 문자열
        //         out long sum  : 숫자 M의 인수의 합을 저장 
        static public bool Perfectnum(long M, out string str, out long sum)
        {
            string str1 = "1";
            string str2 = "";
            sum = 1;
            for (long i = 2; i <= (long)Math.Sqrt((double)M); i++)
            {
                if (M % i == 0)
                {
                    if (i != (M / i))
                    {
                        sum += (i + M / i);
                        str1 = str1 + "  " + i;
                        str2 = (M / i) + " " + str2;
                    }
                    else
                    {
                        sum += i;
                        str1 = str1 + "  " + i;
                    }

                }

            }
            str = str1 + " " + str2;

            if (sum == M) return true;
            else return false;
        }

        // 5. 친화수를 찾는 함수
        //리턴 : 친화수이면 쌍이 되는 숫자
        //       친화수가 아니면  0
        //
        static public long Amicalblenum(long M)
        {
            string str;
            long sum = 0, aminum = 0;
            if (Perfectnum(M, out str, out sum) == false)
            {
                str = ""; aminum = sum; sum = 0;
                if (Perfectnum(aminum, out str, out sum) == false)
                {
                    if (sum == M) return aminum;
                }
            }

            return 0;

        }


        // 6. 이진수 변환 함수
        //  인수 :  double num : 이진수로 변화하여는 십진수
        //          int dig    : 이진수로 표현할 때 소수점 몇자리까지 계산할지 지정
        //  리턴 :  문자열로 표현된 이진수
        static public string dectobin(double num, int dig)  // 십진수문자열 , 소수점 이하 2진수 자리수
        {
            long updot;
            double downdot;
            string ans = "";

            updot = (int)num;


            downdot = num - (double)updot;

            if (updot == 0) ans = "0";
            else
            {
                while (updot > 0)
                {
                    if (updot % 2 == 1) ans = "1" + ans;
                    else ans = "0" + ans;

                    updot /= 2;
                }
            }

            if ((num - (int)num) > 0)
            {
                ans = ans + ".";
                int i;

                for (i = 0; i < dig; i++)
                {
                    if (downdot * 2 >= 1)
                    {
                        ans += "1";
                        downdot = downdot * 2 - 1;
                        if (downdot == 0) break;
                    }
                    else
                    {
                        ans += "0";
                        downdot = downdot * 2;
                    }
                }

                if (i == dig && downdot != 0) ans += "...";
            }

            return ans;
        }

        // 7. 골드바하 추측 
        //  리턴 : 
        //      두소수로 분리  : ture  (out n1 + out n2)
        //      num 4보다 작다 : false (n1=1 ,n2=1)
        //      두소수로 분리 안됨 : false  (n1= num , n2= 0 )
        // 인수 : 
        //        ulong num : 분석하는 대상 수
        //        out ulong n1 : 분리된 솟수1 , num이 4보다 작으면 or 분리가 안되면  n1 = 1 
        //        out ulong n1 : 분리된 솟수2 , num이 4보다 작으면 or 분리가 안되면 n2 = 1  
        static public bool goldbachconj(ulong num, out ulong n1, out ulong n2)
        {
            ulong i = 0;
            ulong j = 0;
            bool gold = false;

            if (Evennum(num) == false || num < 4)
            {
                n1 = 1; n2 = 1;
                return false;
            }

            for (i = 2; i < num; i++)
            {
                if (i == Primenum(i))
                {
                    j = num - i;
                    if (j == Primenum(j))
                    {
                        gold = true;
                        break;
                    }
                }
            }
            n1 = i; n2 = j;
            return gold;
        }

        // 8. 우박수열  (Collatz 추측)
        // 리턴 :  우박수열의 1로 수렴할때 까지 수열의수  
        //         우박수열이 수렴하지 않으면 long.MaxValue
        // 인수 :  long num : 우박수열의 시작수
        //         out string str : 우박수열을 문자열로 저장
        static public long Collatzconj(long num, out string str)
        {

            long n = 0;
            str = "";

            if (num > 0)
            {
                str += num.ToString();
                do
                {
                    n++;
                    str += "-";

                    if (Evennum(num) == true) num /= 2;
                    else num = 3 * num + 1;

                    str += num;

                } while (num != 1 || n == long.MaxValue);  // 우박수는 1로 수렴해야 루프가 끝난다
            }

            return n;
        }


        // 기초 메소드


        static private int n_be_M(long M, long n)  // n 이 인수로 몇개 존재하는지 반환 
        {
            int i = 0;

            if (n <= 1) return -1;       // 부적절한 n 이면 -1 반환
            while (M % n == 0)
            {
                i = i + 1;
                M = M / n;
            }

            return i;

        }


    }
}
