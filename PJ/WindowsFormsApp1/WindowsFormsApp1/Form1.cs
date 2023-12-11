using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
// проект крутой мне нравится заканчиваем это дела
// пай чарм топ
//привет а?
//что делать 
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int lol = 1;
        ATM atm = new ATM(new WaitingState());
        public interface IATMState
        {
            void EnterPIN();
            void WithdrawMoney();
            void EndWork();
            void LoadMoney();
        }

        public class WaitingState : IATMState
        {
            public void EnterPIN() { MessageBox.Show("Вставьте карту......... Карта вставлена"); }
            public void WithdrawMoney() { MessageBox.Show("Нужно вставить карту"); }
            public void EndWork() { MessageBox.Show("Работа не была начата"); }
            public void LoadMoney() { MessageBox.Show("Нужно вставить карту"); }
        }

        public class UserAuthenticationState : IATMState
        {
            public void EnterPIN() { MessageBox.Show("Введите пароль.......... Пароль успешно введен"); }
            public void WithdrawMoney() { MessageBox.Show("Сначала нужно ввести пароль"); }
            public void EndWork() { MessageBox.Show("Работа окончена"); }
            public void LoadMoney() { MessageBox.Show("Сначала нужно ввести пароль"); }
        }

        public class OperationState : IATMState
        {
            public void EnterPIN() { MessageBox.Show("Вы уже ввели пароль"); }
            public void WithdrawMoney() { MessageBox.Show("Введите желаемую сумму....... Сумма успешно введена"); }
            public void EndWork() { MessageBox.Show("Работа окончена"); }
            public void LoadMoney() { MessageBox.Show("Встаьте купюры......... Купюра вставлена"); }
        }

        public class BlockedState : IATMState
        {
            public void EnterPIN() { MessageBox.Show("Вы уже ввели пароль"); }
            public void WithdrawMoney() { MessageBox.Show("Невозможно снять деньги(они закончились)"); }
            public void EndWork() { MessageBox.Show("Работа окончена"); }
            public void LoadMoney() { MessageBox.Show("Встаьте купюры"); }
        }

        public class ATM
        {
            public int Money = 1000;
            public int ID = 1234;
            public IATMState State { get; set; }

            public ATM(IATMState state)
            {
                State = state;
            }

            public void Request(int a)
            {
                if(a==1)
                {
                    State.EnterPIN();
                }
                if(a==2)
                { 
                    State.WithdrawMoney();
                }
                if(a==3)
                {
                    State.EndWork();
                }
                if(a==4)
                {
                    State.LoadMoney();
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lol == 1)
            {
                atm.Request(3);
            }
            else
            {
                atm.Request(3);
                atm.State = new WaitingState();
                
                lol = 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lol >=3 )
            {
                if(textBox1.Text != "")
                {
                    atm.Request(4);
                    atm.Money += Convert.ToInt32(textBox1.Text);
                    MessageBox.Show("Деньги внесены");
                    if (atm.Money > 0)
                    {
                        atm.State = new OperationState();
                        
                        lol = 3;
                    }
                }
                else
                {
                    MessageBox.Show("Введите данные");
                }
            }
            else
            {
                atm.Request(4);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lol == 3)
            {
                atm.Request(2);
                if(textBox1.Text != "" && atm.Money>=Convert.ToInt32(textBox1.Text))
                {
                    MessageBox.Show("Деньги сняты");
                    atm.Money -= Convert.ToInt32(textBox1.Text);
                    if(atm.Money == 0)
                    {
                        atm.State = new BlockedState();
                        
                        lol++;
                    }
                }
                else
                {
                    MessageBox.Show("Введите данные");
                }
            }
            else
            {
                atm.Request(2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(lol==1)
            {
                atm.Request(1);
                atm.State = new UserAuthenticationState();
                
            }
            if(lol==2)
            {
                if(textBox1.Text != "" && Convert.ToInt32(textBox1.Text)== atm.ID)
                {
                    atm.Request(1);
                    atm.State = new OperationState();
                    
                }
                else
                {
                    MessageBox.Show("Данные не верны");
                    lol--;
                }
            }
            if(lol>=3)
            {
                atm.Request(1);
            }
            if(lol<=2)
            {
                lol++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    
        private void label3_Click(object sender, EventArgs e)
        {

            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            for(int i = 0;i<textBox1.Text.Length;i++) 
            {
                if (textBox1.Text[i] == '1' || textBox1.Text[i] == '2' || textBox1.Text[i] == '3' || textBox1.Text[i] == '4' || textBox1.Text[i] == '5' || textBox1.Text[i] == '6' || textBox1.Text[i] == '7' || textBox1.Text[i] == '8' || textBox1.Text[i] == '9' || textBox1.Text[i] == '0'  )
                {
                    count++;
                }
            }
            if(count != textBox1.Text.Length) 
            {
                MessageBox.Show("Введите только числа");
                textBox1.Text = "";
            }
        }
    }
}