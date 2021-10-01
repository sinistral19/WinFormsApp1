using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        IWebDriver Browser;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Options = new ChromeOptions();
            Options.AddArgument("no-sandbox");
          
            Browser= new ChromeDriver(ChromeDriverService.CreateDefaultService(), Options, TimeSpan.FromMinutes(3));
          
            Browser.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
      
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("https://careers.veeam.ru/vacancies");

            IWebElement cookie = Browser.FindElement(By.CssSelector("div#cookiescript_close"));
            cookie.Click();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);


            IWebElement elemnt = Browser.FindElement(By.CssSelector("button.btn.btn-link"));
            elemnt.Click();


            IList<IWebElement> el = Browser.FindElements(By.Id("sl"));
            IWebElement el1 = el[1];
            el1.Click();
           

            IWebElement check = el[0];
            if (comboBox1.SelectedItem.ToString() == "Английский")
            {
                check = Browser.FindElement(By.CssSelector("div.form-group div div.show div div input[type=checkbox][id=lang-option-1]"));
            }
            else if (comboBox1.SelectedItem.ToString() == "Русский")
            {
                check = Browser.FindElement(By.CssSelector("div.form-group div div.show div div input[type=checkbox][id=lang-option-0]"));
            }


           // IWebElement check = Browser.FindElement(By.CssSelector("div.form-group div div.show div div input[type=checkbox][id=lang-option-1]"));
            Actions actions = new Actions(Browser);
            actions.MoveToElement(check).Perform();
            check.Click();



            IWebElement el2 = el[0];
            el2.Click();



            //    IList<IWebElement> departments= Browser.FindElements(By.CssSelector("div.form-group div.select div.show div[x-placement=bottom-start]  a[role]"));

            // By myBy = new ByChained(By.CssSelector("div.form-group div.select div.show div[x-placement=bottom-start]  a[role]"),By.LinkText("Разработка продуктов"));

            IList<IWebElement> departent = Browser.FindElements(By.CssSelector("div.form-group div.select div.show div[x-placement=bottom-start]  a[role]"));    
      
            
            
            
                foreach (IWebElement a in departent)
                {
                if (a.Text == comboBox2.SelectedItem.ToString())
                {

                    Actions actions2 = new Actions(Browser);
                    actions2.MoveToElement(a).Perform();
                    a.Click();
                    


                    break;
                }
                }


            IList<IWebElement> result = Browser.FindElements(By.CssSelector("div.container-main div.container div.row div.col-12 a.card"));


            textBox1.Text = "Количество найденных вакансий " + result.Count;
            textBox1.Text += Environment.NewLine;
            int my_date =Convert.ToInt32( textBox2.Text);

            if (my_date > result.Count)
            {
                textBox1.Text += "Количество вакансий меньше ожидаемого количества";
            }
            else if (my_date < result.Count)
            {
                textBox1.Text += "Количество вакансий больше ожидаемого количества";
            }
            else
            {
                textBox1.Text += "Количество вакансий равно ожидаемому количеству"; 
            }
            textBox1.Visible = true;


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
