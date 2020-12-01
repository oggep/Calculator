using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        //Om man trycketr på en knapp hamnar man här.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (sender is Button knapp)
            {
                switch (knapp.Content)
                {
                    //beroende på vilken knapp man trycker på hamnar man på olika ställen. Här kan du trycka på vilka du vill.
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "0":
                    case "*":
                    case "+":
                    case "-":
                    case "/":
                    //Här ska det vara en punkt också fast har inte hunnit implementera den.

                        Box.Text += knapp.Content;
                    break;
                    //om man tycker på lika med hanmar man i en ny metod
                    case "=":
                        CalculateResult();
                        break;
                    default:
                        break;
                }
            }
        }
        //Detta är metoden för att räkna ut reslutatet
        private void CalculateResult()
        {
            //denna delar siffrorna och håller koll om det är +-/*
            var operations = Box.Text.Split('*', '/', '+', '-');
            //den för att sätta värdet till noll men har inte lagt till flyttal ännu.
            double result = 0.0;
            //Här delar den ut siffrorna i 2 grupper.
            var num1 = Convert.ToDouble(operations[0]);
            var num2 = Convert.ToDouble(operations[1]);

            //Här görs uträkningarna
            if (Box.Text.Contains("+"))
            {
                double addsum = num1 + num2;
                result = addsum;
            }
            else if (Box.Text.Contains("-"))
            {
                double subsum = num1 - num2;
                result = subsum;
            }
            else if (Box.Text.Contains("*"))
            {
                double mulsum = num1 * num2;
                result = mulsum;
            }
            else if (Box.Text.Contains("/"))
            {
                double divsum = num1 / num2;
                result = divsum;
                //man får inte dela med noll därför finns denna
                if (num2 == 0)
                {
                    Box.Text += " Don't divide with 0";
                    return;
                }
            }
            Box.Text += "=" + result;
        }
        //Denna rensar min miniräknare med en knapp som heter clear
        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            Box.Text = "";
        }
    }

}