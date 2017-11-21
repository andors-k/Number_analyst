using System;
using System.Windows;

namespace 수분석가
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

                
        private void EvenButton_Click(object sender, RoutedEventArgs e)
        {
            hint.Content = "짝수는 짝수입니다.";
            long num;
            // num = Convert.ToInt64(tx_input.Text);

            if (long.TryParse(tx_input.Text, out num) == false)
            {
                MessageBox.Show(tx_input.Text+ "은(는) 잘못된 숫자 입력입니다.", "경고......");
                return; 
            }

            if (MyMath.Evennum(num) == true) Result.Text +=(tx_input.Text+  "은(는) 짝수 입니다.\n"); 
            else Result.Text += (tx_input.Text + "은(는) 홀수 입니다.\n");

            Result.ScrollToEnd();
        }

        private void PrimeButton_Click(object sender, RoutedEventArgs e)
        {
            hint.Content = "솟수란 인수가 1과 자기자신 이외에는 없는 수입니다.";
            long num, p;
            if (long.TryParse(tx_input.Text, out num) == false)
            {
                MessageBox.Show(tx_input.Text + "은(는) 잘못된 숫자 입력입니다.", "경고......");
                return;
            }

            p = MyMath.Primenum(num);

            if (p == num) Result.Text += (tx_input.Text + "은(는) 소수 입니다.\n");
            else if(p==1)  Result.Text = (tx_input.Text + "은(는)2보다 작은 수입니다.\n");
            else Result.Text += (tx_input.Text+"은(는) " + p + "로 나누어지는 합성수 입니다.\n");

            Result.ScrollToEnd();
        }

        private void FactoButton_Click(object sender, RoutedEventArgs e)
        {
            hint.Content = "소인수 분해를 합니다. 소인수분해는 솟수인 인수의 곱으로 나타내는 것입니다.";
            long num;
            if (long.TryParse(tx_input.Text, out num) == false)
            {
                MessageBox.Show(tx_input.Text + "은(는) 잘못된 숫자 입력입니다.", "경고......");

                return;
            }

            Result.Text += (tx_input.Text + "="  + MyMath.make_factorForm(num)+"\n");
            Result.ScrollToEnd();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = "";
        }

        private void BinButton_Click(object sender, RoutedEventArgs e)
        {
            hint.Content = "10진수를 2진수로 변환합니다.";
            double num;            
            
            if (double.TryParse(tx_input.Text, out num) == false) 
            {
                MessageBox.Show(tx_input.Text + "은(는) 잘못된 숫자 입력입니다.", "경고......");
                return;
            }

            if(num > long.MaxValue)
            {
                MessageBox.Show(tx_input.Text + "은(는) 너무 큰 숫자 입력입니다.", "경고......");
                return;
            }

            Result.Text += (tx_input.Text + "=" + MyMath.dectobin(num,10)+"\n");
        }

        private void PerfectButton_Click(object sender, RoutedEventArgs e)
        {
            hint.Content = "완전수란 자신을 제외한 인수들의 합이 그 수와 같은 때 완전수라고 합니다";
            long num,sum;
            string str="";
            if (long.TryParse(tx_input.Text, out num) == false)
            {
                MessageBox.Show(tx_input.Text + "은(는) 잘못된 숫자 입력입니다.", "경고......");

                return;
            }
            if (MyMath.Perfectnum(num, out str,out sum) == true )  Result.Text += (tx_input.Text + "은(는) 완전수, 인수= {" + str  +  "}\n");
            else Result.Text += (tx_input.Text + "은(는) 완전수 아님, 인수= {" + str + "}\n");
            Result.ScrollToEnd();

        }

        private void AmicableButton_Click(object sender, RoutedEventArgs e)
        {
            hint.Content = "친화수란 두 수의 쌍이 있어, 어느 한 수의 진약수를 모두 더하면 다른 수가 되는 것을 말한다.(예 220/284)";
            long num,aminum;
            
            if (long.TryParse(tx_input.Text, out num) == false)
            {
                MessageBox.Show(tx_input.Text + "은(는) 잘못된 숫자 입력입니다.", "경고......");
                return;
            }
            aminum = MyMath.Amicalblenum(num);
            if (aminum > 0) Result.Text += (tx_input.Text + "은(는) 친화수" + aminum + "이 존재 \n") ;
            else Result.Text += (tx_input.Text + "은(는) 친화수가 없다 \n" ) ;

        }


        // 골드바하의 추측
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ulong num;

            hint.Content = "골드바하의 추측은 2보다 큰 짝수는 두개의 솟수의 합으로 표시될 수 있다는 추측입니다.";

            if (ulong.TryParse(tx_input.Text, out num) == false )  // 정수아님 
            {
                MessageBox.Show(tx_input.Text + "은(는) 2보다 큰 짝수가 아닙니다", "경고......");
                return;
            }

            ulong i=0; 
            ulong j=0;            

            if (MyMath.goldbachconj(num,out i,out j) == true) Result.Text += tx_input.Text+"= " + i.ToString() + "+" + j.ToString() + "\n";
            else if(i==1 && j==1)   Result.Text += "골드바하의 추측은 4보다 작은 작수에 관한 것입니다. \n"; 
            else Result.Text += "골드바하의 추측은 틀렸군요... 이 메세지는 출력이 될 수 있을까요..? \n";
        }

        // 우박수 보이기
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            hint.Content = "짝수이면 반으로 나누고 홀수이면 곱하기3 더하기 1.. 결국은 1로 수렴하다?";
            long num;
            
            string str=""; 
            
            if (long.TryParse(tx_input.Text, out num) == true   )
            {
               
                Result.Text += tx_input.Text+"은 1이 될 때까지 " + MyMath.Collatzconj(num,out str) + "항 :" + str + "\n";
            }
            else
            {
                MessageBox.Show(tx_input.Text + "은(는) 잘못된 숫자 입력입니다.", "경고......");
                return;
            }
        }
    }
}
