using System;
using System.Windows.Forms;
using Logger;
namespace TestApp2
{
    public partial class Form1 : Form
    {
        DB db = new DB();//Создаем новый объект класса DB
        file f = new file();//Создаем новый объект класса File
        public Form1()
        {
            f.CreateLog();//Создаем новый лог для текущего запуска программы
            db.Info("Приложение запущено!");//Записываем логи и в бд и в файл
            f.Info("Приложение запущено!");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {     
            int k;
            if (textBox1.Text == "" || textBox2.Text == "")//проверяем заполнены ли поля
            {
                MessageBox.Show("Введите оба числа!");//выводим окно с предупреждением
                db.Warn("Одно или оба поля были пустыми");
                f.Warn("Одно или оба поля были пустыми");
            }
            else
            {
                try//пробуем выполнить приведенный ниже код
                {
                    k = Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text);//считаем сумму
                    label2.Text = "Результат : " + k;//вывод в метку
                    db.Debug("Число успешно посчитано, результат:" + k);
                    f.Debug("Число успешно посчитано, результат:" + k);
                }
                catch//если ловим ошибку , то выводим соответствующее сообщение
                {
                    MessageBox.Show("Неверный формат строки! Введите числа от -2147483648 до 2147483647");
                    db.Error("Неверный формат строки");
                    f.Error("Неверный формат строки");
                }
            }
        }
    }
}
